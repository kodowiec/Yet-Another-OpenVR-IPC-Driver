namespace HmdRotation
{
    partial class HmdRotationWindow
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
            components = new System.ComponentModel.Container();
            tb_IpcPipe = new TextBox();
            tb_DevId = new TextBox();
            btn_ConnectPipe = new Button();
            btn_GetDeviceId = new Button();
            timer_updater = new System.Windows.Forms.Timer(components);
            btn_SwitchPolling = new Button();
            lbl_PipeName = new Label();
            lbl_DevID = new Label();
            pb_Preview = new PictureBox();
            lbl_HmdData = new Label();
            lbl_LastSync = new Label();
            ((System.ComponentModel.ISupportInitialize)pb_Preview).BeginInit();
            SuspendLayout();
            // 
            // tb_IpcPipe
            // 
            tb_IpcPipe.Location = new Point(79, 12);
            tb_IpcPipe.Name = "tb_IpcPipe";
            tb_IpcPipe.PlaceholderText = "YAOIDvr";
            tb_IpcPipe.Size = new Size(228, 23);
            tb_IpcPipe.TabIndex = 0;
            // 
            // tb_DevId
            // 
            tb_DevId.Location = new Point(79, 41);
            tb_DevId.Name = "tb_DevId";
            tb_DevId.PlaceholderText = "0";
            tb_DevId.Size = new Size(228, 23);
            tb_DevId.TabIndex = 1;
            // 
            // btn_ConnectPipe
            // 
            btn_ConnectPipe.Location = new Point(313, 12);
            btn_ConnectPipe.Name = "btn_ConnectPipe";
            btn_ConnectPipe.Size = new Size(75, 23);
            btn_ConnectPipe.TabIndex = 2;
            btn_ConnectPipe.Text = "Connect";
            btn_ConnectPipe.UseVisualStyleBackColor = true;
            btn_ConnectPipe.Click += btn_ConnectPipe_Click;
            // 
            // btn_GetDeviceId
            // 
            btn_GetDeviceId.Location = new Point(313, 43);
            btn_GetDeviceId.Name = "btn_GetDeviceId";
            btn_GetDeviceId.Size = new Size(75, 23);
            btn_GetDeviceId.TabIndex = 3;
            btn_GetDeviceId.Text = "Get pos";
            btn_GetDeviceId.UseVisualStyleBackColor = true;
            btn_GetDeviceId.Click += btn_GetDeviceId_Click;
            // 
            // timer_updater
            // 
            timer_updater.Interval = 10;
            timer_updater.Tick += timer_updater_Tick;
            // 
            // btn_SwitchPolling
            // 
            btn_SwitchPolling.Location = new Point(233, 334);
            btn_SwitchPolling.Name = "btn_SwitchPolling";
            btn_SwitchPolling.Size = new Size(155, 23);
            btn_SwitchPolling.TabIndex = 4;
            btn_SwitchPolling.Text = "Start polling";
            btn_SwitchPolling.UseVisualStyleBackColor = true;
            btn_SwitchPolling.Click += btn_SwitchPolling_Click;
            // 
            // lbl_PipeName
            // 
            lbl_PipeName.AutoSize = true;
            lbl_PipeName.Location = new Point(12, 16);
            lbl_PipeName.Name = "lbl_PipeName";
            lbl_PipeName.Size = new Size(54, 15);
            lbl_PipeName.TabIndex = 5;
            lbl_PipeName.Text = "IPC Pipe:";
            // 
            // lbl_DevID
            // 
            lbl_DevID.AutoSize = true;
            lbl_DevID.Location = new Point(14, 43);
            lbl_DevID.Name = "lbl_DevID";
            lbl_DevID.Size = new Size(59, 15);
            lbl_DevID.TabIndex = 6;
            lbl_DevID.Text = "Device ID:";
            // 
            // pb_Preview
            // 
            pb_Preview.Location = new Point(14, 146);
            pb_Preview.Name = "pb_Preview";
            pb_Preview.Size = new Size(374, 182);
            pb_Preview.TabIndex = 7;
            pb_Preview.TabStop = false;
            // 
            // lbl_HmdData
            // 
            lbl_HmdData.Location = new Point(14, 67);
            lbl_HmdData.Name = "lbl_HmdData";
            lbl_HmdData.Size = new Size(374, 76);
            lbl_HmdData.TabIndex = 8;
            lbl_HmdData.Text = "x: 0.958180 y: 0.206746 z: 3.010259 \r\nQw: 0.105385  Qx: 0.463532  Qy: -0.061287 Qz:  0.877654\r\nyaw: 0.958180 pitch: 0.206746 roll: 3.010259 ";
            lbl_HmdData.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_LastSync
            // 
            lbl_LastSync.AutoSize = true;
            lbl_LastSync.Location = new Point(14, 338);
            lbl_LastSync.Name = "lbl_LastSync";
            lbl_LastSync.Size = new Size(92, 15);
            lbl_LastSync.TabIndex = 9;
            lbl_LastSync.Text = "Last sync: {date}";
            // 
            // HmdRotationWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 366);
            Controls.Add(lbl_LastSync);
            Controls.Add(lbl_HmdData);
            Controls.Add(pb_Preview);
            Controls.Add(lbl_DevID);
            Controls.Add(lbl_PipeName);
            Controls.Add(btn_SwitchPolling);
            Controls.Add(btn_GetDeviceId);
            Controls.Add(btn_ConnectPipe);
            Controls.Add(tb_DevId);
            Controls.Add(tb_IpcPipe);
            Name = "HmdRotationWindow";
            Text = "Yet Another OpenVR HMD Rotation Data Receiver";
            Load += HmdRotationWindow_Load;
            ((System.ComponentModel.ISupportInitialize)pb_Preview).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tb_IpcPipe;
        private TextBox tb_DevId;
        private Button btn_ConnectPipe;
        private Button btn_GetDeviceId;
        private System.Windows.Forms.Timer timer_updater;
        private Button btn_SwitchPolling;
        private Label lbl_PipeName;
        private Label lbl_DevID;
        private PictureBox pb_Preview;
        private Label lbl_HmdData;
        private Label lbl_LastSync;
    }
}
