#include "VRDriver.hpp"
#include <Driver/HMDDevice.hpp>
#include <Driver/TrackerDevice.hpp>
#include <Driver/ControllerDevice.hpp>

vr::EVRInitError YetAnotherDriver::VRDriver::Init(vr::IVRDriverContext *pDriverContext)
{
    // Perform driver context initialisation
    if (vr::EVRInitError init_error = vr::InitServerDriverContext(pDriverContext); init_error != vr::EVRInitError::VRInitError_None)
    {
        return init_error;
    }

    Log("Activating YAOID Driver Bridge " + version + "...");

    // Add a HMD
    // this->AddDevice(std::make_shared<HMDDevice>("Example_HMDDevice"));

    // Add a couple controllers
    // this->AddDevice(std::make_shared<ControllerDevice>("Example_ControllerDevice", ControllerDevice::Handedness::ANY));
    // this->AddDevice(std::make_shared<ControllerDevice>("Example_ControllerDevice_Right", ControllerDevice::Handedness::RIGHT));

    ipcServer.init("YAOIDvr");

    std::thread pipeThread(&YetAnotherDriver::VRDriver::PipeThread, this);
    pipeThread.detach();

    Log("YAOID Driver Loaded Successfully");

    return vr::VRInitError_None;
}

void YetAnotherDriver::VRDriver::Cleanup()
{
}

void YetAnotherDriver::VRDriver::PipeThread()
{
    char buffer[1024];

    for (;;)
    {
        Ipc::Connection ipcConnection = ipcServer.accept();

        // we go and read it into our buffer
        if (ipcConnection.recv(buffer, sizeof(buffer)))
        {
            // convert our buffer to string

            std::string rec = buffer;

            std::istringstream iss(rec);
            std::string word;

            std::string s = "";

            while (iss >> word)
            {
                if (word == "addtracker")
                {
                    std::string name, role;

                    iss >> name;
                    iss >> role;

                    if (name == "")
                    {
                        name = "UnnamedTracker" + std::to_string(this->trackers_.size());
                        role = "TrackerRole_Waist"; // should be "vive_tracker_left_foot" or "vive_tracker_right_foot" or "vive_tracker_waist"
                    }

                    auto addtracker = std::make_shared<TrackerDevice>(name, role);
                    this->AddDevice(addtracker);
                    this->trackers_.push_back(addtracker);
                    addtracker->reinit(tracker_max_saved, tracker_max_time, tracker_smoothing);
                    s = s + " added";
                }
                else if (word == "addcontroller")
                {
                    std::string name, hand;
                    iss >> name;
                    iss >> hand;
                    bool isRight = hand == "RIGHT";

                    auto adddevice = std::make_shared<ControllerDevice>("YAOI_" + name + "_" + (isRight ? "RIGHT" : "LEFT"), isRight ? ControllerDevice::Handedness::RIGHT : ControllerDevice::Handedness::LEFT);
                    this->AddDevice(adddevice);
                    this->controllers_.push_back(adddevice);
                }
                else if (word == "cbutton")
                {
                    int idx;
                    int button;
                    bool state;
                    iss >> idx;
                    iss >> button;
                    iss >> state;

                    if (idx < this->controllers_.size())
                    {
                        this->controllers_[idx]->SetButton((ButtonEmu)button, state);
                        s = s + " updated";
                    }
                    else
                    {
                        s = s + " idinvalid";
                    }
                }
                else if (word == "caxis")
                {
                    int idx;
                    float jx; float jy; float tx; float ty;
                    iss >> idx; iss >> jx; iss >> jy; iss >> tx; iss >> ty;

                    if (idx < this->controllers_.size())
                    {
                        this->controllers_[idx]->SetDirection(jx, jy, tx, ty);
                        s = s + " updated";
                    }
                    else
                    {
                        s = s + " idinvalid";
                    }
                }
                else if (word == "cfixedpose")
                {
                    int idx;
                    iss >> idx;

                    if (idx < this->controllers_.size())
                    {
                        this->controllers_[idx]->EnableFixedPosition();
                        this->controllers_[idx]->MakeDefaultPose();
                        this->controllers_[idx]->Update();
                        s = s + " updated";
                    }
                    else
                    {
                        s = s + " idinvalid";
                    }
                }
                else if (word == "cdefpose")
                {
                    int idx;
                    iss >> idx;

                    if (idx < this->controllers_.size())
                    {
                        this->controllers_[idx]->MakeDefaultPose();
                        this->controllers_[idx]->Update();
                        s = s + " updated";
                    }
                    else
                    {
                        s = s + " idinvalid";
                    }
                }
                else if (word == "synctime")
                {
                    std::chrono::system_clock::time_point now = std::chrono::system_clock::now();
                    s = s + " " + std::to_string(this->frame_timing_avg_);
                    s = s + " " + std::to_string(std::chrono::duration_cast<std::chrono::milliseconds>(now - this->last_frame_time_).count());
                }
                else if (word == "setpose")
                {
                    int idx;
                    std::string type;
                    double a, b, c, qw, qx, qy, qz, time, smoothing;
                    iss >> idx;
                    iss >> type;
                    iss >> a;
                    iss >> b;
                    iss >> c;
                    iss >> qw;
                    iss >> qx;
                    iss >> qy;
                    iss >> qz;
                    if (idx < ((type == "controller" || type == "c") ? this->controllers_.size() : this->trackers_.size()))
                    {
                        if (type == "tracker" || type == "t")
                        {
                            this->trackers_[idx]->save_current_pose(a, b, c, qw, qx, qy, qz, 1);
                        }
                        else if (type == "controller" || type == "c")
                        {
                            this->controllers_[idx]->SetPose(a, b, c, qw, qx, qy, qz);
                            this->controllers_[idx]->Update();
                        }
                        s = s + " updated";
                    }
                    else
                    {
                        s = s + " idinvalid";
                    }
                }
                else if (word == "updatepose")
                {
                    int idx;
                    std::string type;
                    double a, b, c, qw, qx, qy, qz, time, smoothing;
                    iss >> idx;
                    iss >> type;
                    iss >> a;
                    iss >> b;
                    iss >> c;
                    iss >> qw;
                    iss >> qx;
                    iss >> qy;
                    iss >> qz;
                    iss >> time;
                    iss >> smoothing;

                    if (idx < ((type == "controller" || type == "c") ? this->controllers_.size() : this->trackers_.size()))
                    {
                        if (time < 0)
                            time = -time;

                        if (type == "tracker" || type == "t")
                        {
                            this->trackers_[idx]->save_current_pose(a, b, c, qw, qx, qy, qz, time);
                        }
                        s = s + " updated";
                    }
                    else
                    {
                        s = s + " idinvalid";
                    }
                }
                else if (word == "getdevicepose")
                {
                    // works with all devices currently active in OpenVR
                    int idx;
                    iss >> idx;

                    vr::TrackedDevicePose_t hmd_pose[10];
                    vr::VRServerDriverHost()->GetRawTrackedDevicePoses(1, hmd_pose, 10);

                    vr::HmdQuaternion_t q = GetRotation(hmd_pose[idx].mDeviceToAbsoluteTracking);
                    vr::HmdVector3_t pos = GetPosition(hmd_pose[idx].mDeviceToAbsoluteTracking);
                    vr::HmdVector3_t ypr = GetEuler(hmd_pose[idx].mDeviceToAbsoluteTracking);

                    s = s + " devicepose " + std::to_string(idx);
                    s = s + " " + std::to_string(pos.v[0]) +
                        " " + std::to_string(pos.v[1]) +
                        " " + std::to_string(pos.v[2]) +
                        " " + std::to_string(q.w) +
                        " " + std::to_string(q.x) +
                        " " + std::to_string(q.y) +
                        " " + std::to_string(q.z);
                    s = s + " " + std::to_string(ypr.v[0]) +
                        " " + std::to_string(ypr.v[1]) +
                        " " + std::to_string(ypr.v[2]);
                }
                else if (word == "gettrackerpose")
                {
                    int idx;
                    double time_offset;
                    iss >> idx;
                    iss >> time_offset;

                    if (idx < this->devices_.size())
                    {
                        s = s + " trackerpose " + std::to_string(idx);

                        double pose[7];
                        int statuscode = this->trackers_[idx]->get_next_pose(time_offset, pose);

                        s = s + " " + std::to_string(pose[0]) +
                            " " + std::to_string(pose[1]) +
                            " " + std::to_string(pose[2]) +
                            " " + std::to_string(pose[3]) +
                            " " + std::to_string(pose[4]) +
                            " " + std::to_string(pose[5]) +
                            " " + std::to_string(pose[6]) +
                            " " + std::to_string(statuscode);
                    }
                    else
                    {
                        s = s + " idinvalid";
                    }
                }
                else if (word == "numtrackers")
                {
                    s = s + " numtrackers " + std::to_string(this->trackers_.size()) + " " + version;
                }
                else if (word == "settings")
                {
                    int msaved;
                    double mtime;
                    double msmooth;
                    iss >> msaved;
                    iss >> mtime;
                    iss >> msmooth;

                    for (auto &device : this->trackers_)
                        device->reinit(msaved, mtime, msmooth);

                    tracker_max_saved = msaved;
                    tracker_max_time = mtime;
                    tracker_smoothing = msmooth;

                    s = s + "  changed";
                }
                else
                {
                    s = s + "  unrecognized";
                }
            }

            s = s + "  OK\0";

            // = length of string + terminating '\0' !!!
            ipcConnection.send(s.c_str(), (s.length() + 1));
        }
    }
}

void YetAnotherDriver::VRDriver::RunFrame()
{
    // Collect events
    vr::VREvent_t event;
    std::vector<vr::VREvent_t> events;
    while (vr::VRServerDriverHost()->PollNextEvent(&event, sizeof(event)))
    {
        events.push_back(event);
    }
    this->openvr_events_ = events;

    // Update frame timing
    std::chrono::system_clock::time_point now = std::chrono::system_clock::now();
    this->frame_timing_ = std::chrono::duration_cast<std::chrono::milliseconds>(now - this->last_frame_time_);
    this->last_frame_time_ = now;

    this->frame_timing_avg_ = this->frame_timing_avg_ * 0.9 + ((double)this->frame_timing_.count()) * 0.1;

    for (auto &device : this->trackers_)
        device->Update();
}

bool YetAnotherDriver::VRDriver::ShouldBlockStandbyMode()
{
    return false;
}

void YetAnotherDriver::VRDriver::EnterStandby()
{
}

void YetAnotherDriver::VRDriver::LeaveStandby()
{
}

std::vector<std::shared_ptr<YetAnotherDriver::IVRDevice>> YetAnotherDriver::VRDriver::GetDevices()
{
    return this->devices_;
}

std::vector<vr::VREvent_t> YetAnotherDriver::VRDriver::GetOpenVREvents()
{
    return this->openvr_events_;
}

std::chrono::milliseconds YetAnotherDriver::VRDriver::GetLastFrameTime()
{
    return this->frame_timing_;
}

bool YetAnotherDriver::VRDriver::AddDevice(std::shared_ptr<IVRDevice> device)
{
    vr::ETrackedDeviceClass openvr_device_class;
    // Remember to update this switch when new device types are added
    switch (device->GetDeviceType())
    {
    case DeviceType::CONTROLLER:
        openvr_device_class = vr::ETrackedDeviceClass::TrackedDeviceClass_Controller;
        break;
    case DeviceType::HMD:
        openvr_device_class = vr::ETrackedDeviceClass::TrackedDeviceClass_HMD;
        break;
    case DeviceType::TRACKER:
        openvr_device_class = vr::ETrackedDeviceClass::TrackedDeviceClass_GenericTracker;
        break;
    case DeviceType::TRACKING_REFERENCE:
        openvr_device_class = vr::ETrackedDeviceClass::TrackedDeviceClass_TrackingReference;
        break;
    default:
        return false;
    }
    bool result = vr::VRServerDriverHost()->TrackedDeviceAdded(device->GetSerial().c_str(), openvr_device_class, device.get());
    if (result)
        this->devices_.push_back(device);
    return result;
}

YetAnotherDriver::SettingsValue YetAnotherDriver::VRDriver::GetSettingsValue(std::string key)
{
    vr::EVRSettingsError err = vr::EVRSettingsError::VRSettingsError_None;
    int int_value = vr::VRSettings()->GetInt32(settings_key_.c_str(), key.c_str(), &err);
    if (err == vr::EVRSettingsError::VRSettingsError_None)
    {
        return int_value;
    }
    err = vr::EVRSettingsError::VRSettingsError_None;
    float float_value = vr::VRSettings()->GetFloat(settings_key_.c_str(), key.c_str(), &err);
    if (err == vr::EVRSettingsError::VRSettingsError_None)
    {
        return float_value;
    }
    err = vr::EVRSettingsError::VRSettingsError_None;
    bool bool_value = vr::VRSettings()->GetBool(settings_key_.c_str(), key.c_str(), &err);
    if (err == vr::EVRSettingsError::VRSettingsError_None)
    {
        return bool_value;
    }
    std::string str_value;
    str_value.reserve(1024);
    vr::VRSettings()->GetString(settings_key_.c_str(), key.c_str(), str_value.data(), 1024, &err);
    if (err == vr::EVRSettingsError::VRSettingsError_None)
    {
        return str_value;
    }
    err = vr::EVRSettingsError::VRSettingsError_None;

    return SettingsValue();
}

void YetAnotherDriver::VRDriver::Log(std::string message)
{
    std::string message_endl = message + "\n";
    vr::VRDriverLog()->Log(message_endl.c_str());
}

vr::IVRDriverInput *YetAnotherDriver::VRDriver::GetInput()
{
    return vr::VRDriverInput();
}

vr::CVRPropertyHelpers *YetAnotherDriver::VRDriver::GetProperties()
{
    return vr::VRProperties();
}

vr::IVRServerDriverHost *YetAnotherDriver::VRDriver::GetDriverHost()
{
    return vr::VRServerDriverHost();
}

//-----------------------------------------------------------------------------
// Purpose: Calculates quaternion (qw,qx,qy,qz) representing the rotation
// from: https://github.com/Omnifinity/OpenVR-Tracking-Example/blob/master/HTC%20Lighthouse%20Tracking%20Example/LighthouseTracking.cpp
//-----------------------------------------------------------------------------

vr::HmdQuaternion_t YetAnotherDriver::VRDriver::GetRotation(vr::HmdMatrix34_t matrix)
{
    vr::HmdQuaternion_t q;

    q.w = sqrt(fmax(0, 1 + matrix.m[0][0] + matrix.m[1][1] + matrix.m[2][2])) / 2;
    q.x = sqrt(fmax(0, 1 + matrix.m[0][0] - matrix.m[1][1] - matrix.m[2][2])) / 2;
    q.y = sqrt(fmax(0, 1 - matrix.m[0][0] + matrix.m[1][1] - matrix.m[2][2])) / 2;
    q.z = sqrt(fmax(0, 1 - matrix.m[0][0] - matrix.m[1][1] + matrix.m[2][2])) / 2;
    q.x = copysign(q.x, matrix.m[2][1] - matrix.m[1][2]);
    q.y = copysign(q.y, matrix.m[0][2] - matrix.m[2][0]);
    q.z = copysign(q.z, matrix.m[1][0] - matrix.m[0][1]);
    return q;
}
//-----------------------------------------------------------------------------
// Purpose: Extracts position (x,y,z).
// from: https://github.com/Omnifinity/OpenVR-Tracking-Example/blob/master/HTC%20Lighthouse%20Tracking%20Example/LighthouseTracking.cpp
//-----------------------------------------------------------------------------

vr::HmdVector3_t YetAnotherDriver::VRDriver::GetPosition(vr::HmdMatrix34_t matrix)
{
    vr::HmdVector3_t vector;

    vector.v[0] = matrix.m[0][3];
    vector.v[1] = matrix.m[1][3];
    vector.v[2] = matrix.m[2][3];

    return vector;
}

vr::HmdVector3_t YetAnotherDriver::VRDriver::GetEuler(vr::HmdMatrix34_t matrix)
{
    // from:  https://github.com/matzman666/OpenVR-Inspector/blob/master/src/model/itemviewmodel.cpp
    // Hmd Rotation //
    /*
    | Intrinsic y-x'-z" rotation matrix:
    | cr*cy+sp*sr*sy | cr*sp*sy-cy*sr | cp*sy |
    | cp*sr          | cp*cr          |-sp    |
    | cy*sp*sr-cr*sy | cr*cy*sp+sr*sy | cp*cy |

    yaw = atan2(cp*sy, cp*cy) [pi, -pi], CCW
    pitch = -asin(-sp) [pi/2, -pi/2]
    roll = atan2(cp*sr, cp*cr) [pi, -pi], CW
    */
    // auto yaw = std::atan2(pose->mDeviceToAbsoluteTracking.m[0][2], pose->mDeviceToAbsoluteTracking.m[2][2]);
    // auto pitch = -std::asin(pose->mDeviceToAbsoluteTracking.m[1][2]);
    // auto roll = std::atan2(pose->mDeviceToAbsoluteTracking.m[1][0], pose->mDeviceToAbsoluteTracking.m[1][1]);
    vr::HmdVector3_t vector;

    vector.v[0] = std::atan2(matrix.m[0][2], matrix.m[2][2]); // yaw
    vector.v[1] = -std::asin(matrix.m[1][2]);                 // pitch
    vector.v[2] = std::atan2(matrix.m[1][0], matrix.m[1][1]); // roll

    return vector;
}
