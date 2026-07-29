namespace YAHBackup
{
    partial class OptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpMatchesFiles = new GroupBox();
            btnClearMatchFiles = new Button();
            btnRemoveMatchFiles = new Button();
            btnAddMatchFiles = new Button();
            lvMatchFiles = new ListView();
            grpOptions = new GroupBox();
            cbVerbose = new CheckBox();
            cbIncludeSubdirs = new CheckBox();
            cbJustList = new CheckBox();
            grpExcludeFiles = new GroupBox();
            btnClearExcludeFiles = new Button();
            btnRemoveExcludeFiles = new Button();
            btnAddExcludeFiles = new Button();
            lvExcludeFiles = new ListView();
            grpExcludeDirs = new GroupBox();
            btnClearExcludeDirs = new Button();
            btnRemoveExcludeDirs = new Button();
            btnAddExcludeDirs = new Button();
            lvExcludeDirs = new ListView();
            btnOk = new Button();
            btnCancel = new Button();
            btnResetDefault = new Button();
            grpMatchesFiles.SuspendLayout();
            grpOptions.SuspendLayout();
            grpExcludeFiles.SuspendLayout();
            grpExcludeDirs.SuspendLayout();
            SuspendLayout();
            // 
            // grpMatchesFiles
            // 
            grpMatchesFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpMatchesFiles.Controls.Add(btnClearMatchFiles);
            grpMatchesFiles.Controls.Add(btnRemoveMatchFiles);
            grpMatchesFiles.Controls.Add(btnAddMatchFiles);
            grpMatchesFiles.Controls.Add(lvMatchFiles);
            grpMatchesFiles.Location = new Point(12, 12);
            grpMatchesFiles.Name = "grpMatchesFiles";
            grpMatchesFiles.Size = new Size(610, 180);
            grpMatchesFiles.TabIndex = 0;
            grpMatchesFiles.TabStop = false;
            grpMatchesFiles.Text = "Copy only matching files";
            // 
            // btnClearMatchFiles
            // 
            btnClearMatchFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClearMatchFiles.Location = new Point(168, 153);
            btnClearMatchFiles.Name = "btnClearMatchFiles";
            btnClearMatchFiles.Size = new Size(75, 23);
            btnClearMatchFiles.TabIndex = 4;
            btnClearMatchFiles.Text = "Clear";
            btnClearMatchFiles.UseVisualStyleBackColor = true;
            btnClearMatchFiles.Click += btnClearMatchFiles_Click;
            // 
            // btnRemoveMatchFiles
            // 
            btnRemoveMatchFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveMatchFiles.Location = new Point(87, 153);
            btnRemoveMatchFiles.Name = "btnRemoveMatchFiles";
            btnRemoveMatchFiles.Size = new Size(75, 23);
            btnRemoveMatchFiles.TabIndex = 3;
            btnRemoveMatchFiles.Text = "Remove";
            btnRemoveMatchFiles.UseVisualStyleBackColor = true;
            btnRemoveMatchFiles.Click += btnRemoveMatchFiles_Click;
            // 
            // btnAddMatchFiles
            // 
            btnAddMatchFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddMatchFiles.Location = new Point(6, 153);
            btnAddMatchFiles.Name = "btnAddMatchFiles";
            btnAddMatchFiles.Size = new Size(75, 23);
            btnAddMatchFiles.TabIndex = 2;
            btnAddMatchFiles.Text = "Add...";
            btnAddMatchFiles.UseVisualStyleBackColor = true;
            btnAddMatchFiles.Click += btnAddMatchFiles_Click;
            // 
            // lvMatchFiles
            // 
            lvMatchFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lvMatchFiles.FullRowSelect = true;
            lvMatchFiles.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvMatchFiles.Location = new Point(6, 22);
            lvMatchFiles.MultiSelect = false;
            lvMatchFiles.Name = "lvMatchFiles";
            lvMatchFiles.Size = new Size(598, 125);
            lvMatchFiles.TabIndex = 1;
            lvMatchFiles.UseCompatibleStateImageBehavior = false;
            lvMatchFiles.View = View.List;
            // 
            // grpOptions
            // 
            grpOptions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpOptions.Controls.Add(cbVerbose);
            grpOptions.Controls.Add(cbIncludeSubdirs);
            grpOptions.Controls.Add(cbJustList);
            grpOptions.Location = new Point(12, 198);
            grpOptions.Name = "grpOptions";
            grpOptions.Size = new Size(610, 98);
            grpOptions.TabIndex = 1;
            grpOptions.TabStop = false;
            grpOptions.Text = "General Options";
            // 
            // cbVerbose
            // 
            cbVerbose.AutoSize = true;
            cbVerbose.Location = new Point(6, 72);
            cbVerbose.Name = "cbVerbose";
            cbVerbose.Size = new Size(111, 19);
            cbVerbose.TabIndex = 2;
            cbVerbose.Text = "Verbose logging";
            cbVerbose.UseVisualStyleBackColor = true;
            // 
            // cbIncludeSubdirs
            // 
            cbIncludeSubdirs.AutoSize = true;
            cbIncludeSubdirs.Location = new Point(6, 47);
            cbIncludeSubdirs.Name = "cbIncludeSubdirs";
            cbIncludeSubdirs.Size = new Size(142, 19);
            cbIncludeSubdirs.TabIndex = 1;
            cbIncludeSubdirs.Text = "Include subdirectories";
            cbIncludeSubdirs.UseVisualStyleBackColor = true;
            // 
            // cbJustList
            // 
            cbJustList.AutoSize = true;
            cbJustList.Location = new Point(6, 22);
            cbJustList.Name = "cbJustList";
            cbJustList.Size = new Size(151, 19);
            cbJustList.TabIndex = 0;
            cbJustList.Text = "Don't copy, just list files";
            cbJustList.UseVisualStyleBackColor = true;
            // 
            // grpExcludeFiles
            // 
            grpExcludeFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpExcludeFiles.Controls.Add(btnClearExcludeFiles);
            grpExcludeFiles.Controls.Add(btnRemoveExcludeFiles);
            grpExcludeFiles.Controls.Add(btnAddExcludeFiles);
            grpExcludeFiles.Controls.Add(lvExcludeFiles);
            grpExcludeFiles.Location = new Point(12, 302);
            grpExcludeFiles.Name = "grpExcludeFiles";
            grpExcludeFiles.Size = new Size(610, 181);
            grpExcludeFiles.TabIndex = 2;
            grpExcludeFiles.TabStop = false;
            grpExcludeFiles.Text = "Exclude files containing";
            // 
            // btnClearExcludeFiles
            // 
            btnClearExcludeFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClearExcludeFiles.Location = new Point(168, 151);
            btnClearExcludeFiles.Name = "btnClearExcludeFiles";
            btnClearExcludeFiles.Size = new Size(75, 23);
            btnClearExcludeFiles.TabIndex = 4;
            btnClearExcludeFiles.Text = "Clear";
            btnClearExcludeFiles.UseVisualStyleBackColor = true;
            btnClearExcludeFiles.Click += btnClearExcludeFiles_Click;
            // 
            // btnRemoveExcludeFiles
            // 
            btnRemoveExcludeFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveExcludeFiles.Location = new Point(87, 151);
            btnRemoveExcludeFiles.Name = "btnRemoveExcludeFiles";
            btnRemoveExcludeFiles.Size = new Size(75, 23);
            btnRemoveExcludeFiles.TabIndex = 3;
            btnRemoveExcludeFiles.Text = "Remove";
            btnRemoveExcludeFiles.UseVisualStyleBackColor = true;
            btnRemoveExcludeFiles.Click += btnRemoveExcludeFiles_Click;
            // 
            // btnAddExcludeFiles
            // 
            btnAddExcludeFiles.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddExcludeFiles.Location = new Point(6, 151);
            btnAddExcludeFiles.Name = "btnAddExcludeFiles";
            btnAddExcludeFiles.Size = new Size(75, 23);
            btnAddExcludeFiles.TabIndex = 2;
            btnAddExcludeFiles.Text = "Add...";
            btnAddExcludeFiles.UseVisualStyleBackColor = true;
            btnAddExcludeFiles.Click += btnAddExcludeFiles_Click;
            // 
            // lvExcludeFiles
            // 
            lvExcludeFiles.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lvExcludeFiles.Location = new Point(6, 22);
            lvExcludeFiles.Name = "lvExcludeFiles";
            lvExcludeFiles.Size = new Size(598, 123);
            lvExcludeFiles.TabIndex = 1;
            lvExcludeFiles.UseCompatibleStateImageBehavior = false;
            lvExcludeFiles.View = View.List;
            // 
            // grpExcludeDirs
            // 
            grpExcludeDirs.Controls.Add(btnClearExcludeDirs);
            grpExcludeDirs.Controls.Add(btnRemoveExcludeDirs);
            grpExcludeDirs.Controls.Add(btnAddExcludeDirs);
            grpExcludeDirs.Controls.Add(lvExcludeDirs);
            grpExcludeDirs.Location = new Point(12, 489);
            grpExcludeDirs.Name = "grpExcludeDirs";
            grpExcludeDirs.Size = new Size(610, 182);
            grpExcludeDirs.TabIndex = 3;
            grpExcludeDirs.TabStop = false;
            grpExcludeDirs.Text = "Exclude directories";
            // 
            // btnClearExcludeDirs
            // 
            btnClearExcludeDirs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClearExcludeDirs.Location = new Point(168, 151);
            btnClearExcludeDirs.Name = "btnClearExcludeDirs";
            btnClearExcludeDirs.Size = new Size(75, 23);
            btnClearExcludeDirs.TabIndex = 4;
            btnClearExcludeDirs.Text = "Clear";
            btnClearExcludeDirs.UseVisualStyleBackColor = true;
            btnClearExcludeDirs.Click += btnClearExcludeDirs_Click;
            // 
            // btnRemoveExcludeDirs
            // 
            btnRemoveExcludeDirs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemoveExcludeDirs.Location = new Point(87, 151);
            btnRemoveExcludeDirs.Name = "btnRemoveExcludeDirs";
            btnRemoveExcludeDirs.Size = new Size(75, 23);
            btnRemoveExcludeDirs.TabIndex = 3;
            btnRemoveExcludeDirs.Text = "Remove";
            btnRemoveExcludeDirs.UseVisualStyleBackColor = true;
            btnRemoveExcludeDirs.Click += btnRemoveExcludeDirs_Click;
            // 
            // btnAddExcludeDirs
            // 
            btnAddExcludeDirs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAddExcludeDirs.Location = new Point(6, 151);
            btnAddExcludeDirs.Name = "btnAddExcludeDirs";
            btnAddExcludeDirs.Size = new Size(75, 23);
            btnAddExcludeDirs.TabIndex = 2;
            btnAddExcludeDirs.Text = "Add...";
            btnAddExcludeDirs.UseVisualStyleBackColor = true;
            btnAddExcludeDirs.Click += btnAddExcludeDirs_Click;
            // 
            // lvExcludeDirs
            // 
            lvExcludeDirs.Location = new Point(6, 22);
            lvExcludeDirs.Name = "lvExcludeDirs";
            lvExcludeDirs.Size = new Size(598, 123);
            lvExcludeDirs.TabIndex = 1;
            lvExcludeDirs.UseCompatibleStateImageBehavior = false;
            lvExcludeDirs.View = View.List;
            lvExcludeDirs.SelectedIndexChanged += lvExcludeDirs_SelectedIndexChanged;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(547, 694);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(75, 23);
            btnOk.TabIndex = 5;
            btnOk.Text = "Ok";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(466, 694);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnResetDefault
            // 
            btnResetDefault.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnResetDefault.Location = new Point(12, 694);
            btnResetDefault.Name = "btnResetDefault";
            btnResetDefault.Size = new Size(75, 23);
            btnResetDefault.TabIndex = 7;
            btnResetDefault.Text = "Set Default";
            btnResetDefault.UseVisualStyleBackColor = true;
            btnResetDefault.Click += btnResetDefault_Click;
            // 
            // OptionsDialog
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(634, 729);
            Controls.Add(btnResetDefault);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(grpExcludeDirs);
            Controls.Add(grpExcludeFiles);
            Controls.Add(grpOptions);
            Controls.Add(grpMatchesFiles);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(650, 700);
            Name = "OptionsDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Options";
            grpMatchesFiles.ResumeLayout(false);
            grpOptions.ResumeLayout(false);
            grpOptions.PerformLayout();
            grpExcludeFiles.ResumeLayout(false);
            grpExcludeDirs.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpMatchesFiles;
        private ListView lvMatchFiles;
        private Button btnClearMatchFiles;
        private Button btnRemoveMatchFiles;
        private Button btnAddMatchFiles;
        private GroupBox grpOptions;
        private CheckBox cbVerbose;
        private CheckBox cbIncludeSubdirs;
        private CheckBox cbJustList;
        private GroupBox grpExcludeFiles;
        private Button btnAddExcludeFiles;
        private ListView lvExcludeFiles;
        private Button btnClearExcludeFiles;
        private Button btnRemoveExcludeFiles;
        private GroupBox grpExcludeDirs;
        private Button btnClearExcludeDirs;
        private Button btnRemoveExcludeDirs;
        private Button btnAddExcludeDirs;
        private ListView lvExcludeDirs;
        private Button btnOk;
        private Button btnCancel;
        private Button btnResetDefault;
    }
}