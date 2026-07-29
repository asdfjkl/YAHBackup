namespace YAHBackup
{
    partial class YAHBackup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YAHBackup));
            grpSettings = new GroupBox();
            btnAbout = new Button();
            btnSaveSettings = new Button();
            btnLoadSettings = new Button();
            grpFoldersToSave = new GroupBox();
            btnClearFolders = new Button();
            btnRemoveFolder = new Button();
            btnAddFolder = new Button();
            lvFoldersToSave = new ListView();
            grpTargetDir = new GroupBox();
            btnSelectTargetDir = new Button();
            tbTargetDir = new TextBox();
            btnOptions = new Button();
            btnStartBackup = new Button();
            btnAbortBackup = new Button();
            pbProgressBackup = new ProgressBar();
            grpLog = new GroupBox();
            tbLog = new TextBox();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            cbVSS = new CheckBox();
            grpSettings.SuspendLayout();
            grpFoldersToSave.SuspendLayout();
            grpTargetDir.SuspendLayout();
            grpLog.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // grpSettings
            // 
            grpSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpSettings.Controls.Add(btnAbout);
            grpSettings.Controls.Add(btnSaveSettings);
            grpSettings.Controls.Add(btnLoadSettings);
            grpSettings.Location = new Point(12, 9);
            grpSettings.Name = "grpSettings";
            grpSettings.Size = new Size(854, 53);
            grpSettings.TabIndex = 0;
            grpSettings.TabStop = false;
            grpSettings.Text = "Settings";
            // 
            // btnAbout
            // 
            btnAbout.Location = new Point(790, 22);
            btnAbout.Name = "btnAbout";
            btnAbout.Size = new Size(58, 23);
            btnAbout.TabIndex = 13;
            btnAbout.Text = "About";
            btnAbout.UseVisualStyleBackColor = true;
            btnAbout.Click += btnAbout_Click;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(87, 22);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(75, 23);
            btnSaveSettings.TabIndex = 2;
            btnSaveSettings.Text = "Save...";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // btnLoadSettings
            // 
            btnLoadSettings.Location = new Point(6, 22);
            btnLoadSettings.Name = "btnLoadSettings";
            btnLoadSettings.Size = new Size(75, 23);
            btnLoadSettings.TabIndex = 1;
            btnLoadSettings.Text = "Load...";
            btnLoadSettings.UseVisualStyleBackColor = true;
            btnLoadSettings.Click += btnLoadSettings_Click;
            // 
            // grpFoldersToSave
            // 
            grpFoldersToSave.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpFoldersToSave.Controls.Add(btnClearFolders);
            grpFoldersToSave.Controls.Add(btnRemoveFolder);
            grpFoldersToSave.Controls.Add(btnAddFolder);
            grpFoldersToSave.Controls.Add(lvFoldersToSave);
            grpFoldersToSave.Location = new Point(12, 68);
            grpFoldersToSave.Name = "grpFoldersToSave";
            grpFoldersToSave.Size = new Size(860, 232);
            grpFoldersToSave.TabIndex = 1;
            grpFoldersToSave.TabStop = false;
            grpFoldersToSave.Text = "Folders To Save";
            // 
            // btnClearFolders
            // 
            btnClearFolders.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClearFolders.Location = new Point(168, 201);
            btnClearFolders.Name = "btnClearFolders";
            btnClearFolders.Size = new Size(75, 23);
            btnClearFolders.TabIndex = 3;
            btnClearFolders.Text = "Clear";
            btnClearFolders.UseVisualStyleBackColor = true;
            btnClearFolders.Click += btnClearFolders_Click;
            // 
            // btnRemoveFolder
            // 
            btnRemoveFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveFolder.Location = new Point(87, 201);
            btnRemoveFolder.Name = "btnRemoveFolder";
            btnRemoveFolder.Size = new Size(75, 23);
            btnRemoveFolder.TabIndex = 2;
            btnRemoveFolder.Text = "Remove";
            btnRemoveFolder.UseVisualStyleBackColor = true;
            btnRemoveFolder.Click += btnRemoveFolder_Click;
            // 
            // btnAddFolder
            // 
            btnAddFolder.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddFolder.Location = new Point(6, 201);
            btnAddFolder.Name = "btnAddFolder";
            btnAddFolder.Size = new Size(75, 23);
            btnAddFolder.TabIndex = 2;
            btnAddFolder.Text = "Add...";
            btnAddFolder.UseVisualStyleBackColor = true;
            btnAddFolder.Click += btnAddFolder_Click;
            // 
            // lvFoldersToSave
            // 
            lvFoldersToSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lvFoldersToSave.LabelWrap = false;
            lvFoldersToSave.Location = new Point(6, 22);
            lvFoldersToSave.Name = "lvFoldersToSave";
            lvFoldersToSave.Size = new Size(848, 173);
            lvFoldersToSave.TabIndex = 0;
            lvFoldersToSave.UseCompatibleStateImageBehavior = false;
            lvFoldersToSave.View = View.List;
            lvFoldersToSave.SelectedIndexChanged += lvFoldersToSave_SelectedIndexChanged;
            // 
            // grpTargetDir
            // 
            grpTargetDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpTargetDir.Controls.Add(btnSelectTargetDir);
            grpTargetDir.Controls.Add(tbTargetDir);
            grpTargetDir.Location = new Point(12, 306);
            grpTargetDir.Name = "grpTargetDir";
            grpTargetDir.Size = new Size(860, 57);
            grpTargetDir.TabIndex = 2;
            grpTargetDir.TabStop = false;
            grpTargetDir.Text = "Target Folder";
            // 
            // btnSelectTargetDir
            // 
            btnSelectTargetDir.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectTargetDir.Location = new Point(779, 22);
            btnSelectTargetDir.Name = "btnSelectTargetDir";
            btnSelectTargetDir.Size = new Size(75, 23);
            btnSelectTargetDir.TabIndex = 1;
            btnSelectTargetDir.Text = "Select...";
            btnSelectTargetDir.UseVisualStyleBackColor = true;
            btnSelectTargetDir.Click += btnSelectTargetDir_Click;
            // 
            // tbTargetDir
            // 
            tbTargetDir.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbTargetDir.Location = new Point(6, 22);
            tbTargetDir.Name = "tbTargetDir";
            tbTargetDir.Size = new Size(767, 23);
            tbTargetDir.TabIndex = 0;
            // 
            // btnOptions
            // 
            btnOptions.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnOptions.Location = new Point(791, 369);
            btnOptions.Name = "btnOptions";
            btnOptions.Size = new Size(75, 23);
            btnOptions.TabIndex = 3;
            btnOptions.Text = "Options";
            btnOptions.UseVisualStyleBackColor = true;
            btnOptions.Click += btnOptions_Click;
            // 
            // btnStartBackup
            // 
            btnStartBackup.Location = new Point(18, 398);
            btnStartBackup.Name = "btnStartBackup";
            btnStartBackup.Size = new Size(89, 23);
            btnStartBackup.TabIndex = 4;
            btnStartBackup.Text = "Start Backup";
            btnStartBackup.UseVisualStyleBackColor = true;
            btnStartBackup.Click += btnStartBackup_Click;
            // 
            // btnAbortBackup
            // 
            btnAbortBackup.Location = new Point(113, 398);
            btnAbortBackup.Name = "btnAbortBackup";
            btnAbortBackup.Size = new Size(75, 23);
            btnAbortBackup.TabIndex = 5;
            btnAbortBackup.Text = "Abort";
            btnAbortBackup.UseVisualStyleBackColor = true;
            btnAbortBackup.Click += btnAbortBackup_Click;
            // 
            // pbProgressBackup
            // 
            pbProgressBackup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pbProgressBackup.Location = new Point(194, 398);
            pbProgressBackup.Name = "pbProgressBackup";
            pbProgressBackup.Size = new Size(672, 23);
            pbProgressBackup.TabIndex = 6;
            // 
            // grpLog
            // 
            grpLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpLog.Controls.Add(tbLog);
            grpLog.Location = new Point(12, 427);
            grpLog.Name = "grpLog";
            grpLog.Size = new Size(860, 209);
            grpLog.TabIndex = 7;
            grpLog.TabStop = false;
            grpLog.Text = "Log";
            // 
            // tbLog
            // 
            tbLog.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tbLog.Location = new Point(6, 22);
            tbLog.Multiline = true;
            tbLog.Name = "tbLog";
            tbLog.ScrollBars = ScrollBars.Vertical;
            tbLog.Size = new Size(848, 181);
            tbLog.TabIndex = 0;
            tbLog.WordWrap = false;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 639);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(884, 22);
            statusStrip.TabIndex = 11;
            statusStrip.Text = "statusStrip";
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(118, 17);
            toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // cbVSS
            // 
            cbVSS.AutoSize = true;
            cbVSS.Location = new Point(18, 373);
            cbVSS.Name = "cbVSS";
            cbVSS.Size = new Size(302, 19);
            cbVSS.TabIndex = 12;
            cbVSS.Text = "Copy Currently Opened Files (requires Admin rights)";
            cbVSS.UseVisualStyleBackColor = true;
            cbVSS.CheckedChanged += cbVSS_CheckedChanged;
            // 
            // YAHBackup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 661);
            Controls.Add(cbVSS);
            Controls.Add(statusStrip);
            Controls.Add(grpLog);
            Controls.Add(pbProgressBackup);
            Controls.Add(btnAbortBackup);
            Controls.Add(btnStartBackup);
            Controls.Add(btnOptions);
            Controls.Add(grpTargetDir);
            Controls.Add(grpFoldersToSave);
            Controls.Add(grpSettings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(700, 550);
            Name = "YAHBackup";
            Text = "YAHBackup";
            grpSettings.ResumeLayout(false);
            grpFoldersToSave.ResumeLayout(false);
            grpTargetDir.ResumeLayout(false);
            grpTargetDir.PerformLayout();
            grpLog.ResumeLayout(false);
            grpLog.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpSettings;
        private Button btnSaveSettings;
        private Button btnLoadSettings;
        private GroupBox grpFoldersToSave;
        private ListView lvFoldersToSave;
        private Button btnClearFolders;
        private Button btnRemoveFolder;
        private Button btnAddFolder;
        private GroupBox grpTargetDir;
        private Button btnSelectTargetDir;
        private TextBox tbTargetDir;
        private Button btnOptions;
        private Button btnStartBackup;
        private Button btnAbortBackup;
        private ProgressBar pbProgressBackup;
        private GroupBox grpLog;
        private TextBox tbLog;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private CheckBox cbVSS;
        private Button btnAbout;
    }
}
