# Yet Another OpenVR IPC Driver

Just another attempt to make a OpenVR bridge driver, built upon [Simple OpenVR Driver Bridge](https://github.com/ju1ce/Simple-OpenVR-Bridge-Driver).
This one focuses on emulating controllers instead of just trackers.

This is by no means any viable alternative to real VR controllers.

### Driver itself
Driver itself is under `./driver` where building and installation instructions are in readme.

### Client examples
Currently there are three C# client examples in `./examples/csharp`
- **HmdRotation** - (windows only) simple gui to track positional data of hmd/other device
- **IpcCmd** - even simpler cli allowing to send commands and receive responses
- **ControllerEmulator** - GUI app to change position and rotation of virtual controller

### Available commands

#### general
- ```getdevicepose 'id'``` : useful to get position of HMD, which is id 0. You should be able to get positions of controllers, but is very unreliable so other methods are prefered.
returns device id, position in x y z, rotation in quaternion and euler``
- ```synctime``` : returns avarage frametime and time since last frame, useful if you need to sync something to the HMD refresh rate
- ```settings 'numOfValues' 'smoothingWindow' 'additionalSmoothing'``` : update the drivers smoothing and interpolation settings.
#### trackers
- ```addtracker 'name' 'role'``` : add another tracker with the name and role. Only needs to be done on first connect to prevent duplicates.
- ```numtrackers``` : the driver will return the number of trackers currently connected. Used to check how many trackers you need to connect and how many are already connected
- ```gettrackerpose 'id'```: same as getdevicepose
- ```updatepose 'id' 'type' 'x' 'y' 'z' 'qw' 'qx' 'qy' 'qz' 'delay'``` : update pose of tracker with id to position x y z and rotation quaternion qw qx qy qz. You can also send how old the pose is, but you can also just send 0
types: tracker(t)
#### controllers
- ```addcontroller 'serial' 'hand'```: spawn controller, serial must be unique, hand must be either LEFT or RIGHT
- ```caxis 'id' 'joystickX' 'joystickY' 'trackpadX' 'trackpadY'```: set controller axis state
- ```cbutton 'id' 'button_code' 'pressed'```: set state of button with button_code
- ```cfixedpose 'id'```: enable fixed position mode for controller
- ```cdefpose 'id'```: call MakeDefaultPose() upon controller
- ```setpose 'id' 'type' 'x' 'y' 'z' 'qw' 'qx' 'qy' 'qz'```: directly sets the pose of device
types: controller (c); tracker(t)


To see how the smoothing and delay values affect tracking, you can check the graphs [here](https://github.com/ju1ce/April-Tag-VR-FullBody-Tracker/wiki/Refining-parameters).

#### References
and other useful things i discovered trying to learn how to handle openvr
- [Simple OpenVR Driver Bridge](https://github.com/ju1ce/Simple-OpenVR-Bridge-Driver)
- [Simple OpenVR Driver Tutorial](https://github.com/terminal29/[Simple-OpenVR-Driver-Tutorial)
- [OpenVR Inspector](https://github.com/matzman666/OpenVR-Inspector/)