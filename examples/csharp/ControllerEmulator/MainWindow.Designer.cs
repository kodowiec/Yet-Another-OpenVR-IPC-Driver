namespace ControllerEmulator
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tb_IpcPipe = new TextBox();
            tb_DevId = new TextBox();
            btn_ConnectPipe = new Button();
            btn_SetPose = new Button();
            btn_AutoUpdate = new Button();
            lbl_PipeName = new Label();
            lbl_DevID = new Label();
            pb_Preview = new PictureBox();
            gb_ControllerCreation = new GroupBox();
            lbl_AddControllerStatus = new Label();
            btn_AddController = new Button();
            radio_Right = new RadioButton();
            radio_Left = new RadioButton();
            gb_Rotation = new GroupBox();
            lbl_Roll = new Label();
            lbl_Pitch = new Label();
            lbl_Yaw = new Label();
            track_Roll = new TrackBar();
            track_Pitch = new TrackBar();
            track_Yaw = new TrackBar();
            statusStrip1 = new StatusStrip();
            lbl_Status = new ToolStripStatusLabel();
            gb_Position = new GroupBox();
            lbl_PosZ = new Label();
            lbl_PosY = new Label();
            lbl_PosX = new Label();
            track_PosZ = new TrackBar();
            track_PosY = new TrackBar();
            track_PosX = new TrackBar();
            gb_Buttons = new GroupBox();
            btn_BtnSYSTEM = new Button();
            btn_BtnMENU = new Button();
            btn_BtnRIGHT = new Button();
            btn_BtnLEFT = new Button();
            btn_BtnDOWN = new Button();
            btn_BtnUP = new Button();
            btn_BtnY = new Button();
            btn_BtnX = new Button();
            btn_BtnB = new Button();
            btn_BtnA = new Button();
            gb_Analog = new GroupBox();
            btn_AnalogReset = new Button();
            panel_AnalogPreview = new Panel();
            pnl_AnalogPointer = new Panel();
            track_AnalogY = new TrackBar();
            track_AnalogX = new TrackBar();
            radio_Joystick = new RadioButton();
            radio_Touchpad = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)pb_Preview).BeginInit();
            gb_ControllerCreation.SuspendLayout();
            gb_Rotation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)track_Roll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)track_Pitch).BeginInit();
            ((System.ComponentModel.ISupportInitialize)track_Yaw).BeginInit();
            statusStrip1.SuspendLayout();
            gb_Position.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)track_PosZ).BeginInit();
            ((System.ComponentModel.ISupportInitialize)track_PosY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)track_PosX).BeginInit();
            gb_Buttons.SuspendLayout();
            gb_Analog.SuspendLayout();
            panel_AnalogPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)track_AnalogY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)track_AnalogX).BeginInit();
            SuspendLayout();
            // 
            // tb_IpcPipe
            // 
            tb_IpcPipe.Location = new Point(79, 22);
            tb_IpcPipe.Name = "tb_IpcPipe";
            tb_IpcPipe.PlaceholderText = "YAOIDvr";
            tb_IpcPipe.Size = new Size(125, 23);
            tb_IpcPipe.TabIndex = 0;
            // 
            // tb_DevId
            // 
            tb_DevId.Location = new Point(79, 51);
            tb_DevId.Name = "tb_DevId";
            tb_DevId.PlaceholderText = "0";
            tb_DevId.Size = new Size(125, 23);
            tb_DevId.TabIndex = 1;
            // 
            // btn_ConnectPipe
            // 
            btn_ConnectPipe.Location = new Point(210, 22);
            btn_ConnectPipe.Name = "btn_ConnectPipe";
            btn_ConnectPipe.Size = new Size(75, 23);
            btn_ConnectPipe.TabIndex = 2;
            btn_ConnectPipe.Text = "Connect";
            btn_ConnectPipe.UseVisualStyleBackColor = true;
            btn_ConnectPipe.Click += btn_ConnectPipe_Click;
            // 
            // btn_SetPose
            // 
            btn_SetPose.Location = new Point(12, 382);
            btn_SetPose.Name = "btn_SetPose";
            btn_SetPose.Size = new Size(130, 23);
            btn_SetPose.TabIndex = 3;
            btn_SetPose.Text = "Update pose";
            btn_SetPose.UseVisualStyleBackColor = true;
            btn_SetPose.Click += get_current_pose;
            // 
            // btn_AutoUpdate
            // 
            btn_AutoUpdate.Location = new Point(148, 382);
            btn_AutoUpdate.Name = "btn_AutoUpdate";
            btn_AutoUpdate.Size = new Size(137, 23);
            btn_AutoUpdate.TabIndex = 4;
            btn_AutoUpdate.Text = "Enable auto update";
            btn_AutoUpdate.UseVisualStyleBackColor = true;
            btn_AutoUpdate.Click += btn_AutoUpdate_Click;
            // 
            // lbl_PipeName
            // 
            lbl_PipeName.AutoSize = true;
            lbl_PipeName.Location = new Point(12, 26);
            lbl_PipeName.Name = "lbl_PipeName";
            lbl_PipeName.Size = new Size(54, 15);
            lbl_PipeName.TabIndex = 5;
            lbl_PipeName.Text = "IPC Pipe:";
            // 
            // lbl_DevID
            // 
            lbl_DevID.AutoSize = true;
            lbl_DevID.Location = new Point(12, 54);
            lbl_DevID.Name = "lbl_DevID";
            lbl_DevID.Size = new Size(59, 15);
            lbl_DevID.TabIndex = 6;
            lbl_DevID.Text = "Device ID:";
            // 
            // pb_Preview
            // 
            pb_Preview.Location = new Point(2, 175);
            pb_Preview.Name = "pb_Preview";
            pb_Preview.Size = new Size(283, 216);
            pb_Preview.TabIndex = 7;
            pb_Preview.TabStop = false;
            // 
            // gb_ControllerCreation
            // 
            gb_ControllerCreation.Controls.Add(lbl_AddControllerStatus);
            gb_ControllerCreation.Controls.Add(btn_AddController);
            gb_ControllerCreation.Controls.Add(radio_Right);
            gb_ControllerCreation.Controls.Add(radio_Left);
            gb_ControllerCreation.Location = new Point(13, 85);
            gb_ControllerCreation.Name = "gb_ControllerCreation";
            gb_ControllerCreation.Size = new Size(279, 70);
            gb_ControllerCreation.TabIndex = 10;
            gb_ControllerCreation.TabStop = false;
            gb_ControllerCreation.Text = "Add controller";
            // 
            // lbl_AddControllerStatus
            // 
            lbl_AddControllerStatus.Location = new Point(81, 15);
            lbl_AddControllerStatus.Name = "lbl_AddControllerStatus";
            lbl_AddControllerStatus.Size = new Size(192, 23);
            lbl_AddControllerStatus.TabIndex = 3;
            lbl_AddControllerStatus.Text = "xxx";
            lbl_AddControllerStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btn_AddController
            // 
            btn_AddController.Location = new Point(198, 41);
            btn_AddController.Name = "btn_AddController";
            btn_AddController.Size = new Size(75, 23);
            btn_AddController.TabIndex = 2;
            btn_AddController.Text = "Create";
            btn_AddController.UseVisualStyleBackColor = true;
            btn_AddController.Click += btn_AddController_Click;
            // 
            // radio_Right
            // 
            radio_Right.AutoSize = true;
            radio_Right.Location = new Point(10, 43);
            radio_Right.Name = "radio_Right";
            radio_Right.Size = new Size(53, 19);
            radio_Right.TabIndex = 1;
            radio_Right.TabStop = true;
            radio_Right.Text = "Right";
            radio_Right.UseVisualStyleBackColor = true;
            // 
            // radio_Left
            // 
            radio_Left.AutoSize = true;
            radio_Left.Location = new Point(10, 21);
            radio_Left.Name = "radio_Left";
            radio_Left.Size = new Size(45, 19);
            radio_Left.TabIndex = 0;
            radio_Left.TabStop = true;
            radio_Left.Text = "Left";
            radio_Left.UseVisualStyleBackColor = true;
            // 
            // gb_Rotation
            // 
            gb_Rotation.Controls.Add(pb_Preview);
            gb_Rotation.Controls.Add(lbl_Roll);
            gb_Rotation.Controls.Add(lbl_Pitch);
            gb_Rotation.Controls.Add(lbl_Yaw);
            gb_Rotation.Controls.Add(track_Roll);
            gb_Rotation.Controls.Add(track_Pitch);
            gb_Rotation.Controls.Add(track_Yaw);
            gb_Rotation.Location = new Point(306, 12);
            gb_Rotation.Name = "gb_Rotation";
            gb_Rotation.Size = new Size(287, 393);
            gb_Rotation.TabIndex = 11;
            gb_Rotation.TabStop = false;
            gb_Rotation.Text = "Rotation";
            // 
            // lbl_Roll
            // 
            lbl_Roll.AutoSize = true;
            lbl_Roll.Location = new Point(6, 154);
            lbl_Roll.Name = "lbl_Roll";
            lbl_Roll.Size = new Size(27, 15);
            lbl_Roll.TabIndex = 13;
            lbl_Roll.Text = "Roll";
            // 
            // lbl_Pitch
            // 
            lbl_Pitch.AutoSize = true;
            lbl_Pitch.Location = new Point(6, 103);
            lbl_Pitch.Name = "lbl_Pitch";
            lbl_Pitch.Size = new Size(34, 15);
            lbl_Pitch.TabIndex = 12;
            lbl_Pitch.Text = "Pitch";
            // 
            // lbl_Yaw
            // 
            lbl_Yaw.AutoSize = true;
            lbl_Yaw.Location = new Point(6, 52);
            lbl_Yaw.Name = "lbl_Yaw";
            lbl_Yaw.Size = new Size(28, 15);
            lbl_Yaw.TabIndex = 11;
            lbl_Yaw.Text = "Yaw";
            // 
            // track_Roll
            // 
            track_Roll.Location = new Point(6, 124);
            track_Roll.Maximum = 1800;
            track_Roll.Minimum = -1800;
            track_Roll.Name = "track_Roll";
            track_Roll.Size = new Size(275, 45);
            track_Roll.SmallChange = 10;
            track_Roll.TabIndex = 10;
            track_Roll.TickFrequency = 10;
            track_Roll.Scroll += track_Roll_Scroll;
            // 
            // track_Pitch
            // 
            track_Pitch.Location = new Point(6, 73);
            track_Pitch.Maximum = 1800;
            track_Pitch.Minimum = -1800;
            track_Pitch.Name = "track_Pitch";
            track_Pitch.Size = new Size(275, 45);
            track_Pitch.SmallChange = 10;
            track_Pitch.TabIndex = 9;
            track_Pitch.TickFrequency = 10;
            track_Pitch.Scroll += track_Pitch_Scroll;
            // 
            // track_Yaw
            // 
            track_Yaw.Location = new Point(6, 22);
            track_Yaw.Maximum = 1800;
            track_Yaw.Minimum = -1800;
            track_Yaw.Name = "track_Yaw";
            track_Yaw.Size = new Size(275, 45);
            track_Yaw.TabIndex = 8;
            track_Yaw.TickFrequency = 10;
            track_Yaw.Scroll += track_Yaw_Scroll;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lbl_Status });
            statusStrip1.Location = new Point(0, 423);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(786, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // lbl_Status
            // 
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(39, 17);
            lbl_Status.Text = "Ready";
            // 
            // gb_Position
            // 
            gb_Position.Controls.Add(lbl_PosZ);
            gb_Position.Controls.Add(lbl_PosY);
            gb_Position.Controls.Add(lbl_PosX);
            gb_Position.Controls.Add(track_PosZ);
            gb_Position.Controls.Add(track_PosY);
            gb_Position.Controls.Add(track_PosX);
            gb_Position.Location = new Point(13, 191);
            gb_Position.Name = "gb_Position";
            gb_Position.Size = new Size(278, 185);
            gb_Position.TabIndex = 13;
            gb_Position.TabStop = false;
            gb_Position.Text = "Position";
            // 
            // lbl_PosZ
            // 
            lbl_PosZ.AutoSize = true;
            lbl_PosZ.Location = new Point(6, 154);
            lbl_PosZ.Name = "lbl_PosZ";
            lbl_PosZ.Size = new Size(14, 15);
            lbl_PosZ.TabIndex = 13;
            lbl_PosZ.Text = "Z";
            // 
            // lbl_PosY
            // 
            lbl_PosY.AutoSize = true;
            lbl_PosY.Location = new Point(6, 103);
            lbl_PosY.Name = "lbl_PosY";
            lbl_PosY.Size = new Size(14, 15);
            lbl_PosY.TabIndex = 12;
            lbl_PosY.Text = "Y";
            // 
            // lbl_PosX
            // 
            lbl_PosX.AutoSize = true;
            lbl_PosX.Location = new Point(6, 52);
            lbl_PosX.Name = "lbl_PosX";
            lbl_PosX.Size = new Size(14, 15);
            lbl_PosX.TabIndex = 11;
            lbl_PosX.Text = "X";
            // 
            // track_PosZ
            // 
            track_PosZ.Location = new Point(6, 124);
            track_PosZ.Maximum = 200;
            track_PosZ.Minimum = -200;
            track_PosZ.Name = "track_PosZ";
            track_PosZ.Size = new Size(266, 45);
            track_PosZ.SmallChange = 5;
            track_PosZ.TabIndex = 10;
            track_PosZ.TickFrequency = 5;
            track_PosZ.Value = 20;
            track_PosZ.Scroll += track_PosZ_Scroll;
            // 
            // track_PosY
            // 
            track_PosY.Location = new Point(6, 73);
            track_PosY.Maximum = 200;
            track_PosY.Minimum = -200;
            track_PosY.Name = "track_PosY";
            track_PosY.Size = new Size(266, 45);
            track_PosY.SmallChange = 5;
            track_PosY.TabIndex = 9;
            track_PosY.TickFrequency = 5;
            track_PosY.Value = 130;
            track_PosY.Scroll += track_PosY_Scroll;
            // 
            // track_PosX
            // 
            track_PosX.Location = new Point(6, 22);
            track_PosX.Maximum = 200;
            track_PosX.Minimum = -200;
            track_PosX.Name = "track_PosX";
            track_PosX.Size = new Size(266, 45);
            track_PosX.SmallChange = 5;
            track_PosX.TabIndex = 8;
            track_PosX.TickFrequency = 5;
            track_PosX.Value = -20;
            track_PosX.Scroll += track_PosX_Scroll;
            // 
            // gb_Buttons
            // 
            gb_Buttons.Controls.Add(btn_BtnSYSTEM);
            gb_Buttons.Controls.Add(btn_BtnMENU);
            gb_Buttons.Controls.Add(btn_BtnRIGHT);
            gb_Buttons.Controls.Add(btn_BtnLEFT);
            gb_Buttons.Controls.Add(btn_BtnDOWN);
            gb_Buttons.Controls.Add(btn_BtnUP);
            gb_Buttons.Controls.Add(btn_BtnY);
            gb_Buttons.Controls.Add(btn_BtnX);
            gb_Buttons.Controls.Add(btn_BtnB);
            gb_Buttons.Controls.Add(btn_BtnA);
            gb_Buttons.Location = new Point(599, 12);
            gb_Buttons.Name = "gb_Buttons";
            gb_Buttons.Size = new Size(179, 169);
            gb_Buttons.TabIndex = 14;
            gb_Buttons.TabStop = false;
            gb_Buttons.Text = "Buttons";
            // 
            // btn_BtnSYSTEM
            // 
            btn_BtnSYSTEM.Location = new Point(92, 138);
            btn_BtnSYSTEM.Name = "btn_BtnSYSTEM";
            btn_BtnSYSTEM.Size = new Size(80, 23);
            btn_BtnSYSTEM.TabIndex = 9;
            btn_BtnSYSTEM.Text = "SYSTEM";
            btn_BtnSYSTEM.UseVisualStyleBackColor = true;
            btn_BtnSYSTEM.Click += ButtonEmuClick;
            btn_BtnSYSTEM.MouseDown += ButtonEmuDown;
            btn_BtnSYSTEM.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnMENU
            // 
            btn_BtnMENU.Location = new Point(6, 138);
            btn_BtnMENU.Name = "btn_BtnMENU";
            btn_BtnMENU.Size = new Size(80, 23);
            btn_BtnMENU.TabIndex = 8;
            btn_BtnMENU.Text = "MENU";
            btn_BtnMENU.UseVisualStyleBackColor = true;
            btn_BtnMENU.Click += ButtonEmuClick;
            btn_BtnMENU.MouseDown += ButtonEmuDown;
            btn_BtnMENU.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnRIGHT
            // 
            btn_BtnRIGHT.Location = new Point(92, 109);
            btn_BtnRIGHT.Name = "btn_BtnRIGHT";
            btn_BtnRIGHT.Size = new Size(80, 23);
            btn_BtnRIGHT.TabIndex = 7;
            btn_BtnRIGHT.Text = "RIGHT";
            btn_BtnRIGHT.UseVisualStyleBackColor = true;
            btn_BtnRIGHT.Click += ButtonEmuClick;
            btn_BtnRIGHT.MouseDown += ButtonEmuDown;
            btn_BtnRIGHT.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnLEFT
            // 
            btn_BtnLEFT.Location = new Point(6, 109);
            btn_BtnLEFT.Name = "btn_BtnLEFT";
            btn_BtnLEFT.Size = new Size(80, 23);
            btn_BtnLEFT.TabIndex = 6;
            btn_BtnLEFT.Text = "LEFT";
            btn_BtnLEFT.UseVisualStyleBackColor = true;
            btn_BtnLEFT.Click += ButtonEmuClick;
            btn_BtnLEFT.MouseDown += ButtonEmuDown;
            btn_BtnLEFT.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnDOWN
            // 
            btn_BtnDOWN.Location = new Point(92, 80);
            btn_BtnDOWN.Name = "btn_BtnDOWN";
            btn_BtnDOWN.Size = new Size(80, 23);
            btn_BtnDOWN.TabIndex = 5;
            btn_BtnDOWN.Text = "DOWN";
            btn_BtnDOWN.UseVisualStyleBackColor = true;
            btn_BtnDOWN.Click += ButtonEmuClick;
            btn_BtnDOWN.MouseDown += ButtonEmuDown;
            btn_BtnDOWN.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnUP
            // 
            btn_BtnUP.Location = new Point(6, 80);
            btn_BtnUP.Name = "btn_BtnUP";
            btn_BtnUP.Size = new Size(80, 23);
            btn_BtnUP.TabIndex = 4;
            btn_BtnUP.Text = "UP";
            btn_BtnUP.UseVisualStyleBackColor = true;
            btn_BtnUP.Click += ButtonEmuClick;
            btn_BtnUP.MouseDown += ButtonEmuDown;
            btn_BtnUP.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnY
            // 
            btn_BtnY.Location = new Point(92, 51);
            btn_BtnY.Name = "btn_BtnY";
            btn_BtnY.Size = new Size(80, 23);
            btn_BtnY.TabIndex = 3;
            btn_BtnY.Text = "Y";
            btn_BtnY.UseVisualStyleBackColor = true;
            btn_BtnY.Click += ButtonEmuClick;
            btn_BtnY.MouseDown += ButtonEmuDown;
            btn_BtnY.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnX
            // 
            btn_BtnX.Location = new Point(6, 51);
            btn_BtnX.Name = "btn_BtnX";
            btn_BtnX.Size = new Size(80, 23);
            btn_BtnX.TabIndex = 2;
            btn_BtnX.Text = "X";
            btn_BtnX.UseVisualStyleBackColor = true;
            btn_BtnX.Click += ButtonEmuClick;
            btn_BtnX.MouseDown += ButtonEmuDown;
            btn_BtnX.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnB
            // 
            btn_BtnB.Location = new Point(92, 22);
            btn_BtnB.Name = "btn_BtnB";
            btn_BtnB.Size = new Size(80, 23);
            btn_BtnB.TabIndex = 1;
            btn_BtnB.Text = "B";
            btn_BtnB.UseVisualStyleBackColor = true;
            btn_BtnB.Click += ButtonEmuClick;
            btn_BtnB.MouseDown += ButtonEmuDown;
            btn_BtnB.MouseUp += ButtonEmuUp;
            // 
            // btn_BtnA
            // 
            btn_BtnA.Location = new Point(6, 22);
            btn_BtnA.Name = "btn_BtnA";
            btn_BtnA.Size = new Size(80, 23);
            btn_BtnA.TabIndex = 0;
            btn_BtnA.Text = "A";
            btn_BtnA.UseVisualStyleBackColor = true;
            btn_BtnA.Click += ButtonEmuClick;
            btn_BtnA.MouseDown += ButtonEmuDown;
            btn_BtnA.MouseUp += ButtonEmuUp;
            // 
            // gb_Analog
            // 
            gb_Analog.Controls.Add(btn_AnalogReset);
            gb_Analog.Controls.Add(panel_AnalogPreview);
            gb_Analog.Controls.Add(track_AnalogY);
            gb_Analog.Controls.Add(track_AnalogX);
            gb_Analog.Controls.Add(radio_Joystick);
            gb_Analog.Controls.Add(radio_Touchpad);
            gb_Analog.Location = new Point(599, 187);
            gb_Analog.Name = "gb_Analog";
            gb_Analog.Size = new Size(179, 216);
            gb_Analog.TabIndex = 15;
            gb_Analog.TabStop = false;
            gb_Analog.Text = "Analog";
            // 
            // btn_AnalogReset
            // 
            btn_AnalogReset.Location = new Point(9, 52);
            btn_AnalogReset.Name = "btn_AnalogReset";
            btn_AnalogReset.Size = new Size(20, 23);
            btn_AnalogReset.TabIndex = 13;
            btn_AnalogReset.Text = "0";
            btn_AnalogReset.UseVisualStyleBackColor = true;
            btn_AnalogReset.Click += btn_AnalogReset_Click;
            // 
            // panel_AnalogPreview
            // 
            panel_AnalogPreview.BorderStyle = BorderStyle.Fixed3D;
            panel_AnalogPreview.Controls.Add(pnl_AnalogPointer);
            panel_AnalogPreview.Location = new Point(36, 77);
            panel_AnalogPreview.Name = "panel_AnalogPreview";
            panel_AnalogPreview.Size = new Size(136, 136);
            panel_AnalogPreview.TabIndex = 12;
            // 
            // pnl_AnalogPointer
            // 
            pnl_AnalogPointer.BackColor = Color.Red;
            pnl_AnalogPointer.Location = new Point(65, 65);
            pnl_AnalogPointer.Name = "pnl_AnalogPointer";
            pnl_AnalogPointer.Size = new Size(4, 4);
            pnl_AnalogPointer.TabIndex = 0;
            // 
            // track_AnalogY
            // 
            track_AnalogY.Location = new Point(6, 77);
            track_AnalogY.Maximum = 100;
            track_AnalogY.Minimum = -100;
            track_AnalogY.Name = "track_AnalogY";
            track_AnalogY.Orientation = Orientation.Vertical;
            track_AnalogY.Size = new Size(45, 136);
            track_AnalogY.TabIndex = 11;
            track_AnalogY.Scroll += track_AnalogY_Scroll;
            // 
            // track_AnalogX
            // 
            track_AnalogX.Location = new Point(36, 47);
            track_AnalogX.Maximum = 100;
            track_AnalogX.Minimum = -100;
            track_AnalogX.Name = "track_AnalogX";
            track_AnalogX.Size = new Size(136, 45);
            track_AnalogX.TabIndex = 10;
            track_AnalogX.Scroll += track_AnalogX_Scroll;
            // 
            // radio_Joystick
            // 
            radio_Joystick.AutoSize = true;
            radio_Joystick.Location = new Point(92, 22);
            radio_Joystick.Name = "radio_Joystick";
            radio_Joystick.Size = new Size(66, 19);
            radio_Joystick.TabIndex = 1;
            radio_Joystick.TabStop = true;
            radio_Joystick.Text = "Joystick";
            radio_Joystick.UseVisualStyleBackColor = true;
            // 
            // radio_Touchpad
            // 
            radio_Touchpad.AutoSize = true;
            radio_Touchpad.Location = new Point(9, 22);
            radio_Touchpad.Name = "radio_Touchpad";
            radio_Touchpad.Size = new Size(77, 19);
            radio_Touchpad.TabIndex = 0;
            radio_Touchpad.TabStop = true;
            radio_Touchpad.Text = "Touchpad";
            radio_Touchpad.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 445);
            Controls.Add(gb_Analog);
            Controls.Add(gb_Buttons);
            Controls.Add(gb_Position);
            Controls.Add(statusStrip1);
            Controls.Add(gb_Rotation);
            Controls.Add(gb_ControllerCreation);
            Controls.Add(lbl_DevID);
            Controls.Add(lbl_PipeName);
            Controls.Add(btn_AutoUpdate);
            Controls.Add(btn_SetPose);
            Controls.Add(btn_ConnectPipe);
            Controls.Add(tb_DevId);
            Controls.Add(tb_IpcPipe);
            Name = "MainWindow";
            Text = "Yet Another Controller Emulator";
            Load += MainWindow_Load;
            ((System.ComponentModel.ISupportInitialize)pb_Preview).EndInit();
            gb_ControllerCreation.ResumeLayout(false);
            gb_ControllerCreation.PerformLayout();
            gb_Rotation.ResumeLayout(false);
            gb_Rotation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)track_Roll).EndInit();
            ((System.ComponentModel.ISupportInitialize)track_Pitch).EndInit();
            ((System.ComponentModel.ISupportInitialize)track_Yaw).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            gb_Position.ResumeLayout(false);
            gb_Position.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)track_PosZ).EndInit();
            ((System.ComponentModel.ISupportInitialize)track_PosY).EndInit();
            ((System.ComponentModel.ISupportInitialize)track_PosX).EndInit();
            gb_Buttons.ResumeLayout(false);
            gb_Analog.ResumeLayout(false);
            gb_Analog.PerformLayout();
            panel_AnalogPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)track_AnalogY).EndInit();
            ((System.ComponentModel.ISupportInitialize)track_AnalogX).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_IpcPipe;
        private TextBox tb_DevId;
        private Button btn_ConnectPipe;
        private Button btn_SetPose;
        private Button btn_AutoUpdate;
        private Label lbl_PipeName;
        private Label lbl_DevID;
        private PictureBox pb_Preview;
        private GroupBox gb_ControllerCreation;
        private RadioButton radio_Right;
        private RadioButton radio_Left;
        private Button btn_AddController;
        private Label lbl_AddControllerStatus;
        private GroupBox gb_Rotation;
        private TrackBar track_Yaw;
        private TrackBar track_Roll;
        private TrackBar track_Pitch;
        private Label lbl_Roll;
        private Label lbl_Pitch;
        private Label lbl_Yaw;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lbl_Status;
        private GroupBox gb_Position;
        private Label lbl_PosZ;
        private Label lbl_PosY;
        private Label lbl_PosX;
        private TrackBar track_PosZ;
        private TrackBar track_PosY;
        private TrackBar track_PosX;
        private GroupBox gb_Buttons;
        private Button btn_BtnA;
        private Button btn_BtnSYSTEM;
        private Button btn_BtnMENU;
        private Button btn_BtnRIGHT;
        private Button btn_BtnLEFT;
        private Button btn_BtnDOWN;
        private Button btn_BtnUP;
        private Button btn_BtnY;
        private Button btn_BtnX;
        private Button btn_BtnB;
        private GroupBox gb_Analog;
        private TrackBar track_AnalogY;
        private TrackBar track_AnalogX;
        private RadioButton radio_Joystick;
        private RadioButton radio_Touchpad;
        private Button btn_AnalogReset;
        private Panel panel_AnalogPreview;
        private Panel pnl_AnalogPointer;
    }
}
