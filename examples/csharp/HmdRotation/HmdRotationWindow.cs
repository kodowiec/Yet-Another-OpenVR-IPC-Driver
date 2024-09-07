using System.Diagnostics;
using System.IO.Pipes;

namespace HmdRotation
{
    public partial class HmdRotationWindow : Form
    {
        static NamedPipeClientStream? namedPipeClient;
        static string pipeName = "YAOIDvr";
        static string devId = "0";
        Point drawOrigin;
        Math3D.Math3D.Cube? drawing;

        DevicePose? currentPose;

        float lastX = 0.0f;
        float lastY = 0.0f;
        float lastZ = 0.0f;

        public HmdRotationWindow()
        {
            InitializeComponent();
        }

        void ReconnectPipe(bool initial = false)
        {
            lbl_LastSync.Text = $"Connecting to {pipeName}...";
            Debug.WriteLine(lbl_LastSync.Text);
            SendIpc("bumpinthat");
            if (initial)
            {
                Debug.WriteLine("Connected!");
                lbl_LastSync.Text = "Connected!";
            }
            ReceiveIpc();
            return;
        }

        static bool SendIpc(string message)
        {
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(message);
            try
            {
                namedPipeClient = new NamedPipeClientStream(pipeName);
                namedPipeClient.Connect();
                namedPipeClient.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return false;
            }
        }

        static string ReceiveIpc()
        {
            byte[] buffer = new byte[1024];
            int byteFromClient = namedPipeClient!.Read(buffer, 0, 1024);
            var str = System.Text.Encoding.Default.GetString(buffer);
            namedPipeClient.Close();
            return str;
        }


        private void HmdRotationWindow_Load(object sender, EventArgs e)
        {
            lbl_LastSync.Text = "Not connected";
            lbl_HmdData.Text = "";
        }

        private void btn_ConnectPipe_Click(object sender, EventArgs e)
        {
            pipeName = (tb_IpcPipe.Text == string.Empty) ? "YAOIDvr" : tb_IpcPipe.Text;
            ReconnectPipe(true);
        }

        private void btn_GetDeviceId_Click(object sender, EventArgs e)
        {
            devId = (tb_DevId.Text == string.Empty) ? "0" : tb_DevId.Text;
            if (SendIpc($"getdevicepose {devId}"))
            {
                string msg = ReceiveIpc();
                if (msg.Length < 10) return;

                if (currentPose == null) currentPose = new DevicePose(msg);
                else currentPose.Update(msg);

                UpdateDataLabel();
            }
        }

        private void UpdateDataLabel()
        {

            lbl_LastSync.Text = $"Last updated: {DateTime.Now}";
            if (currentPose == null) return;
            lbl_HmdData.Text = $"""
                X: {currentPose.Position.X} Y: {currentPose.Position.Y} Z: {currentPose.Position.Z}
                [ W: {currentPose.Rotation.W}  X: {currentPose.Rotation.X}  Y: {currentPose.Rotation.Y}  Z: {currentPose.Rotation.Z} ] 
                Yaw: {currentPose.EulerAngles.Z * 180.0f / Math.PI} Pitch: {currentPose.EulerAngles.Y * 180.0f / Math.PI} 
                Roll: {currentPose.EulerAngles.X * 180.0f / Math.PI}
                """;
        }

        private void btn_SwitchPolling_Click(object sender, EventArgs e)
        {
            if (!timer_updater.Enabled)
            {
                drawOrigin = new Point(pb_Preview.Width / 2, pb_Preview.Height / 2);
                drawing = new Math3D.Math3D.Cube(200, 100, 20);
                drawing.InitializeCube();

                ReconnectPipe(true);
            }
            timer_updater.Enabled = !timer_updater.Enabled;
            ((Button)sender).Text = (timer_updater.Enabled ? "Stop" : "Start") + " polling";
        }

        private void timer_updater_Tick(object sender, EventArgs e)
        {
            try
            {
                if (SendIpc($"getdevicepose {devId}"))
                {
                    string msg = ReceiveIpc();
                    if (msg.Length < 10) return;

                    if (currentPose == null) currentPose = new DevicePose(msg);
                    else currentPose.Update(msg);

                    var nextX = -(float)(currentPose.EulerAngles.X * 180.0f / Math.PI);
                    var nextY = (float)(currentPose.EulerAngles.Y * 180.0f / Math.PI);
                    var nextZ = (float)(currentPose.EulerAngles.Z * 180.0f / Math.PI);

                    // recentering button?
                    if (drawing == null || Math.Abs(currentPose.EulerAngles.Z) < 0.2 && Math.Abs(nextZ - currentPose.EulerAngles.Z) > 20)
                    {
                        lastY = (float)(currentPose.EulerAngles.Y * 180.0f / Math.PI);
                        lastZ = (float)(currentPose.EulerAngles.Z * 180.0f / Math.PI);
                        lastX = (float)(currentPose.EulerAngles.X * 180.0f / Math.PI);
                        drawing = null;
                        drawOrigin = new Point(pb_Preview.Width / 2, pb_Preview.Height / 2);
                        drawing = new Math3D.Math3D.Cube(200, 100, 20);
                        drawing.InitializeCube();
                    }

                    drawing.RotateZ = (nextX - lastX);
                    drawing.RotateX = (nextY - lastY);
                    drawing.RotateY = (nextZ - lastZ);

                    lastX = nextX;
                    lastY = nextY;
                    lastZ = nextZ;

                    pb_Preview.Image = drawing.DrawCube(drawOrigin);
                    UpdateDataLabel();
                }
            }
            catch { }
        }
    }
}
