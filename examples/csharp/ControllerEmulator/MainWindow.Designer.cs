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
            pb_Preview.Location = new Point(0, 175);
            pb_Preview.Name = "pb_Preview";
            pb_Preview.Size = new Size(287, 218);
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
            statusStrip1.Size = new Size(605, 22);
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
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(605, 445);
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
    }
}
