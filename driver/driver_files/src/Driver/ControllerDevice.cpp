#include <algorithm>

#include "ControllerDevice.hpp"
#include "Key.hpp"

inline vr::HmdQuaternion_t HmdQuaternion_Init(double w, double x, double y, double z)
{
    vr::HmdQuaternion_t quat;
    quat.w = w;
    quat.x = x;
    quat.y = y;
    quat.z = z;
    return quat;
}

YetAnotherDriver::ControllerDevice::ControllerDevice(std::string serial, ControllerDevice::Handedness handedness) : serial_(serial),
                                                                                                                    handedness_(handedness)
{
    std::vector<double> temp(std::vector<double>(8, -1));
    this->nextpose_ = temp;
}

vr::HmdVector3_t YetAnotherDriver::ControllerDevice::EnableFixedPosition()
{
    this->fixed_pos_ = true;

    this->pos_override_.v[0] = (this->handedness_ == Handedness::LEFT) ? -0.2 : 0.2;
    this->pos_override_.v[1] = 1.3;
    this->pos_override_.v[2] = -0.2;

    this->nextpose_[0] = this->pos_override_.v[0];
    this->nextpose_[1] = this->pos_override_.v[1];
    this->nextpose_[2] = this->pos_override_.v[2];
    this->nextpose_[3] = 0.105385;
    this->nextpose_[4] = 0.463532;
    this->nextpose_[5] = -0.061287;
    this->nextpose_[6] = 0.877654;

    return this->pos_override_;
}

std::string YetAnotherDriver::ControllerDevice::GetSerial()
{
    return this->serial_;
}

long long counter = 0;

void YetAnotherDriver::ControllerDevice::SetButton(YetAnotherDriver::ControllerDevice::ButtonEmu button, bool state)
{
    switch (button)
    {
    case YetAnotherDriver::ControllerDevice::ButtonEmu::A:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->a_button_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::B:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->b_button_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::X:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->x_button_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::Y:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->y_button_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::UP:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->up_button_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::DOWN:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->down_button_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::LEFT:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->left_button_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::RIGHT:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->right_button_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::GRIP:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->grip_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::MENU:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->menu_click_component_, state, 0);
        break;
    case YetAnotherDriver::ControllerDevice::ButtonEmu::SYSTEM:
        GetDriver()->GetInput()->UpdateBooleanComponent(this->system_click_component_, state, 0);
        break;
    default:
        break;
    }
}

void YetAnotherDriver::ControllerDevice::SetDirection(float x, float y, float rx, float ry)
{
    if (x == 0.0f && y == 0.0f)
        GetDriver()->GetInput()->UpdateBooleanComponent(this->joystick_touch_component_, false, 0);
    else
        GetDriver()->GetInput()->UpdateBooleanComponent(this->joystick_touch_component_, true, 0);

    GetDriver()->GetInput()->UpdateScalarComponent(this->joystick_x_component_, x, 0);
    GetDriver()->GetInput()->UpdateScalarComponent(this->joystick_y_component_, y, 0);

    if (rx == 0.0f && ry == 0.0f)
        GetDriver()->GetInput()->UpdateBooleanComponent(this->trackpad_touch_component_, false, 0);
    else
        GetDriver()->GetInput()->UpdateBooleanComponent(this->trackpad_touch_component_, true, 0);

    GetDriver()->GetInput()->UpdateScalarComponent(this->trackpad_x_component_, rx, 0);
    GetDriver()->GetInput()->UpdateScalarComponent(this->trackpad_y_component_, ry, 0);
}

void YetAnotherDriver::ControllerDevice::Update()
{
    if (this->device_index_ == vr::k_unTrackedDeviceIndexInvalid)
        return;

    // Check if this device was asked to be identified
    auto events = GetDriver()->GetOpenVREvents();
    for (auto event : events)
    {
        // Note here, event.trackedDeviceIndex does not necissarily equal this->device_index_, not sure why, but the component handle will match so we can just use that instead
        // if (event.trackedDeviceIndex == this->device_index_) {
        if (event.eventType == vr::EVREventType::VREvent_Input_HapticVibration)
        {
            if (event.data.hapticVibration.componentHandle == this->haptic_component_)
            {
                this->did_vibrate_ = true;
            }
        }
        //}
    }

    // Check if we need to keep vibrating
    if (this->did_vibrate_)
    {
        this->vibrate_anim_state_ += (GetDriver()->GetLastFrameTime().count() / 1000.f);
        if (this->vibrate_anim_state_ > 1.0f)
        {
            this->did_vibrate_ = false;
            this->vibrate_anim_state_ = 0.0f;
        }
    }

    // Setup pose for this frame
    auto pose = IVRDevice::MakeDefaultPose();

    // Post pose
    if (fixed_pos_)
    {
        pose.vecPosition[0] = this->pos_override_.v[0];
        pose.vecPosition[1] = this->pos_override_.v[1];
        pose.vecPosition[2] = this->pos_override_.v[2];
        pose.poseTimeOffset = 0;
        pose.poseIsValid = true;
        pose.result = vr::TrackingResult_Running_OK;
        pose.deviceIsConnected = true;

        pose.qRotation.w = 0.105385;
        pose.qRotation.x = 0.463532;
        pose.qRotation.y = -0.061287;
        pose.qRotation.z = 0.877654;

        pose.qWorldFromDriverRotation = HmdQuaternion_Init(1, 0, 0, 0);
        pose.qDriverFromHeadRotation = HmdQuaternion_Init(1, 0, 0, 0);
    }
    else
    {
        pose.vecPosition[0] = this->nextpose_[0];
        pose.vecPosition[1] = this->nextpose_[1];
        pose.vecPosition[2] = this->nextpose_[2];
        pose.poseTimeOffset = 0;
        pose.poseIsValid = true;
        pose.result = vr::TrackingResult_Running_OK;
        pose.deviceIsConnected = true;

        pose.qRotation.w = this->nextpose_[3];
        pose.qRotation.x = this->nextpose_[4];
        pose.qRotation.y = this->nextpose_[5];
        pose.qRotation.z = this->nextpose_[6];

        pose.qWorldFromDriverRotation = HmdQuaternion_Init(1, 0, 0, 0);
        pose.qDriverFromHeadRotation = HmdQuaternion_Init(1, 0, 0, 0);
    }
    GetDriver()->GetDriverHost()->TrackedDevicePoseUpdated(this->device_index_, pose, sizeof(vr::DriverPose_t));
    this->last_pose_ = pose;
}

void YetAnotherDriver::ControllerDevice::SetPose(double px, double py, double pz, double qw, double qx, double qy, double qz)
{
    this->fixed_pos_ = false;
    this->nextpose_[0] = px;
    this->nextpose_[1] = py;
    this->nextpose_[2] = pz;
    this->nextpose_[3] = qw;
    this->nextpose_[4] = qx;
    this->nextpose_[5] = qy;
    this->nextpose_[6] = qz;
}

DeviceType YetAnotherDriver::ControllerDevice::GetDeviceType()
{
    return DeviceType::CONTROLLER;
}

YetAnotherDriver::ControllerDevice::Handedness YetAnotherDriver::ControllerDevice::GetHandedness()
{
    return this->handedness_;
}

vr::TrackedDeviceIndex_t YetAnotherDriver::ControllerDevice::GetDeviceIndex()
{
    return this->device_index_;
}

vr::EVRInitError YetAnotherDriver::ControllerDevice::Activate(uint32_t unObjectId)
{
    this->device_index_ = unObjectId;

    GetDriver()->Log("Activating controller " + this->serial_);

    // Get the properties handle
    auto props = GetDriver()->GetProperties()->TrackedDeviceToPropertyContainer(this->device_index_);

    // Setup inputs and outputs

    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/joystick/click", &this->joystick_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/joystick/touch", &this->joystick_touch_component_);
    GetDriver()->GetInput()->CreateScalarComponent(props, "/input/joystick/x", &this->joystick_x_component_, vr::EVRScalarType::VRScalarType_Absolute, vr::EVRScalarUnits::VRScalarUnits_NormalizedTwoSided);
    GetDriver()->GetInput()->CreateScalarComponent(props, "/input/joystick/y", &this->joystick_y_component_, vr::EVRScalarType::VRScalarType_Absolute, vr::EVRScalarUnits::VRScalarUnits_NormalizedTwoSided);

    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/trackpad/click", &this->trackpad_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/trackpad/touch", &this->trackpad_touch_component_);
    GetDriver()->GetInput()->CreateScalarComponent(props, "/input/trackpad/x", &this->trackpad_x_component_, vr::EVRScalarType::VRScalarType_Absolute, vr::EVRScalarUnits::VRScalarUnits_NormalizedTwoSided);
    GetDriver()->GetInput()->CreateScalarComponent(props, "/input/trackpad/y", &this->trackpad_y_component_, vr::EVRScalarType::VRScalarType_Absolute, vr::EVRScalarUnits::VRScalarUnits_NormalizedTwoSided);

    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/a/click", &this->a_button_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/b/click", &this->b_button_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/x/click", &this->x_button_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/y/click", &this->y_button_click_component_);

    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/up/click", &this->up_button_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/down/click", &this->down_button_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/left/click", &this->left_button_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/right/click", &this->right_button_click_component_);

    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/application_menu/click", &this->menu_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/system/click", &this->system_click_component_);
    GetDriver()->GetInput()->CreateBooleanComponent(props, "/input/grip/click", &this->grip_click_component_);
    GetDriver()->GetInput()->CreateScalarComponent(props, "/input/trigger/value", &this->trigger_value_component_, vr::EVRScalarType::VRScalarType_Absolute, vr::EVRScalarUnits::VRScalarUnits_NormalizedOneSided);

    GetDriver()->GetInput()->CreateHapticComponent(props, "/output/haptic", &haptic_component_);

    // Set some universe ID (Must be 2 or higher)
    GetDriver()->GetProperties()->SetUint64Property(props, vr::Prop_CurrentUniverseId_Uint64, 2);

    // Set up a model "number" (not needed but good to have)
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_ModelNumber_String, "yaoid_controller");

    // Set up a render model path
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_RenderModelName_String, "vr_controller_vive_1_5");

    // Give SteamVR a hint at what hand this controller is for

    GetDriver()->GetProperties()->SetInt32Property(props, vr::Prop_ControllerRoleHint_Int32, ((this->handedness_ == Handedness::LEFT) ? vr::ETrackedControllerRole::TrackedControllerRole_LeftHand : vr::ETrackedControllerRole::TrackedControllerRole_RightHand));

    // Set controller profile
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_InputProfilePath_String, "{yaoidvr}/input/example_controller_bindings.json");

    // Change the icon depending on which handedness this controller is using (ANY uses right)
    std::string controller_handedness_str = this->handedness_ == Handedness::LEFT ? "left" : "right";
    std::string controller_ready_file = "{yaoidvr}/icons/controller_ready_" + controller_handedness_str + ".png";
    std::string controller_not_ready_file = "{yaoidvr}/icons/controller_not_ready_" + controller_handedness_str + ".png";

    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_NamedIconPathDeviceReady_String, controller_ready_file.c_str());

    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_NamedIconPathDeviceOff_String, controller_not_ready_file.c_str());
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_NamedIconPathDeviceSearching_String, controller_not_ready_file.c_str());
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_NamedIconPathDeviceSearchingAlert_String, controller_not_ready_file.c_str());
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_NamedIconPathDeviceReadyAlert_String, controller_not_ready_file.c_str());
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_NamedIconPathDeviceNotReady_String, controller_not_ready_file.c_str());
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_NamedIconPathDeviceStandby_String, controller_not_ready_file.c_str());
    GetDriver()->GetProperties()->SetStringProperty(props, vr::Prop_NamedIconPathDeviceAlertLow_String, controller_not_ready_file.c_str());

    return vr::EVRInitError::VRInitError_None;
}

void YetAnotherDriver::ControllerDevice::Deactivate()
{
    this->device_index_ = vr::k_unTrackedDeviceIndexInvalid;
}

void YetAnotherDriver::ControllerDevice::EnterStandby()
{
}

void *YetAnotherDriver::ControllerDevice::GetComponent(const char *pchComponentNameAndVersion)
{
    return nullptr;
}

void YetAnotherDriver::ControllerDevice::DebugRequest(const char *pchRequest, char *pchResponseBuffer, uint32_t unResponseBufferSize)
{
    if (unResponseBufferSize >= 1)
        pchResponseBuffer[0] = 0;
}

vr::DriverPose_t YetAnotherDriver::ControllerDevice::GetPose()
{
    return last_pose_;
}
