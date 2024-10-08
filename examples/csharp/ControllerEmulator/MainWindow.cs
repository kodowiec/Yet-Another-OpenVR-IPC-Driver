using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Pipes;
using System.Numerics;

namespace ControllerEmulator
{
    public partial class MainWindow : Form
    {
        static string devId = "0";
        Point drawOrigin;
        Math3D.Math3D.Cube? drawing;

        bool autoUpdate = false;

        DevicePose currentPose = new();
        Ipc? ipc;

        float currentRoll = 0.0f;
        float currentPitch = 0.0f;
        float currentYaw = 0.0f;

        float currentX = -0.21f;
        float currentY = 1.30f;
        float currentZ = 0.20f;

        int startId = 0;

        enum ButtonEmu
        {
            A,
            B,
            X,
            Y,
            UP,
            DOWN,
            LEFT,
            RIGHT,
            GRIP,
            MENU,
            SYSTEM
        };

        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            drawOrigin = new Point(pb_Preview.Width / 2, pb_Preview.Height / 2);
            drawing = new Math3D.Math3D.Cube(50, 150, 20);
            drawing.InitializeCube();
            pb_Preview.Image = drawing.DrawCube(drawOrigin);
        }

        private void btn_ConnectPipe_Click(object sender, EventArgs e)
        {
            UpdateStatus("Connecting!");
            ipc = new((tb_IpcPipe.Text == string.Empty) ? "YAOIDvr" : tb_IpcPipe.Text);
            Debug.WriteLine($"Connecting to {ipc.pipeName}");
            ipc.Connect();
            UpdateStatus("Connected!");
        }

        private void get_current_pose(object sender, EventArgs e)
        {
            SendPose();
            //if (ipc == null) { return; }
            //devId = (tb_DevId.Text == string.Empty) ? "0" : tb_DevId.Text;
            //if (ipc.Send($"getdevicepose {devId}"))
            //{
            //    string msg = ipc.Receive();
            //    if (msg.Length < 10) return;

            //    currentPose.UpdateFromIpc(msg);
            //}
        }

        private void btn_AutoUpdate_Click(object sender, EventArgs e)
        {
            autoUpdate = !autoUpdate;
            ((Button)sender).Text = (!autoUpdate ? "Enable" : "Disable") + " auto update";
        }

        private void track_Yaw_Scroll(object sender, EventArgs e)
        {
            float currentValue = ((TrackBar)sender).Value / 10f;
            var nextZ = currentValue;

            drawing!.RotateY = (nextZ - currentYaw);

            currentYaw = nextZ;

            lbl_Yaw.Text = $"Yaw: {currentValue}";

            pb_Preview.Image = drawing.DrawCube(drawOrigin);

            if (autoUpdate) SendPose();
        }

        private void track_Pitch_Scroll(object sender, EventArgs e)
        {
            float currentValue = ((TrackBar)sender).Value / 10f;
            var nextY = currentValue;

            drawing!.RotateX = (nextY - currentPitch);

            currentPitch = nextY;

            lbl_Pitch.Text = $"Pitch: {currentValue}";

            pb_Preview.Image = drawing.DrawCube(drawOrigin);

            if (autoUpdate) SendPose();
        }

        private void track_Roll_Scroll(object sender, EventArgs e)
        {
            float currentValue = ((TrackBar)sender).Value / 10f;
            var nextX = currentValue;

            drawing!.RotateZ = (nextX - currentRoll);

            currentRoll = nextX;

            lbl_Roll.Text = $"Roll: {currentValue}";

            pb_Preview.Image = drawing.DrawCube(drawOrigin);

            if (autoUpdate) SendPose();
        }

        private void track_PosX_Scroll(object sender, EventArgs e)
        {
            float currentValue = ((TrackBar)sender).Value / 100f;
            lbl_PosX.Text = $"X: {currentValue}";
            currentX = currentValue;

            if (autoUpdate) SendPose();
        }

        private void track_PosY_Scroll(object sender, EventArgs e)
        {
            float currentValue = ((TrackBar)sender).Value / 100f;
            lbl_PosY.Text = $"Y: {currentValue}";
            currentY = currentValue;

            if (autoUpdate) SendPose();
        }

        private void track_PosZ_Scroll(object sender, EventArgs e)
        {
            float currentValue = ((TrackBar)sender).Value / 100f;
            lbl_PosZ.Text = $"Z: {currentValue}";
            currentZ = currentValue;

            if (autoUpdate) SendPose();
        }

        void UpdateStatus(string text) => lbl_Status.Text = text;

        void SendPose()
        {
            if (ipc == null) return;
            Quaternion quaternion = new Quaternion();
            quaternion = Quaternion.CreateFromYawPitchRoll(currentYaw / 57.2958f, currentPitch / 57.2958f, currentRoll / 57.2958f);
            UpdateStatus(
                ipc.SendRecv($"setpose {tb_DevId.Text} c {currentX} {currentY} {currentZ} {quaternion.W} {quaternion.X} {quaternion.Y} {quaternion.Z}")
            );
        }

        private void btn_AddController_Click(object sender, EventArgs e)
        {
            if (ipc == null) return;
            string controllerStr = (radio_Left.Checked ? "LEFT" : "RIGHT");
            string serial = $"CE00{startId}_" + controllerStr;

            UpdateStatus(ipc.SendRecv($"addcontroller {serial} {controllerStr}"));
            UpdateStatus(ipc.SendRecv($"cfixedpose 0"));

            startId += 1;
        }

        private void ButtonEmuClick(object sender, EventArgs e)
        {
        }

        private void ButtonEmuDown(object sender, MouseEventArgs e)
        {
            if (ipc == null) return;
            Enum.TryParse(((Button)sender).Text, out ButtonEmu buttonValue);
            ipc.Send($"cbutton {tb_DevId.Text} {(int)buttonValue} 1");
            Debug.WriteLine(ipc.Receive());
        }

        private void ButtonEmuUp(object sender, MouseEventArgs e)
        {
            if (ipc == null) return;
            Enum.TryParse(((Button)sender).Text, out ButtonEmu buttonValue);
            ipc.SendRecv($"cbutton {tb_DevId.Text} {(int)buttonValue} 0");
        }

        private void btn_AnalogReset_Click(object sender, EventArgs e)
        {
            if (ipc == null) return;    
            ipc.SendRecv($"caxis {tb_DevId.Text} 0.0 0.0 0.0 0.0");
            track_AnalogX.Value = 0;
            track_AnalogY.Value = 0;
            pnl_AnalogPointer.Location = new Point(65, 65);
        }

        private void track_AnalogX_Scroll(object sender, EventArgs e)
        {
            float value = ((TrackBar)sender).Value / 100.0f;
            int x = (int)(value * 65.0f) + 65;
            pnl_AnalogPointer.Location = new Point(x, pnl_AnalogPointer.Location.Y);
            UpdateAnalog();

        }

        private void track_AnalogY_Scroll(object sender, EventArgs e)
        {
            float value = -((TrackBar)sender).Value / 100.0f;
            int y = (int)(value * 65.0f) + 65;
            pnl_AnalogPointer.Location = new Point(pnl_AnalogPointer.Location.X, y);
            UpdateAnalog();
        }

        void UpdateAnalog()
        {
            if (ipc == null) return;
            if (radio_Joystick.Checked)
            {
                ipc.SendRecv($"caxis {tb_DevId.Text} {track_AnalogX.Value / 100f} {track_AnalogY.Value / 100f} 0.0 0.0");
            } 
            else if (radio_Touchpad.Checked)
            {
                ipc.SendRecv($"caxis {tb_DevId.Text} 0.0 0.0 {track_AnalogX.Value / 100.0f} {track_AnalogY.Value / 100.0f}");
            }
        }
    }
}
