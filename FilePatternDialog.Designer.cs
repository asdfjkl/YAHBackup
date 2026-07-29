namespace YAHBackup
{
    partial class FilePatternDialog
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtPatternBox = new TextBox();
            lbInvalidChars = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter a file name pattern.";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 39);
            label2.Name = "label2";
            label2.Size = new Size(207, 15);
            label2.TabIndex = 1;
            label2.Text = "'*' matches any number of characters.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 54);
            label3.Name = "label3";
            label3.Size = new Size(183, 15);
            label3.TabIndex = 2;
            label3.Text = "'?' matches exactly one character.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 84);
            label4.Name = "label4";
            label4.Size = new Size(48, 15);
            label4.TabIndex = 3;
            label4.Text = "Pattern:";
            // 
            // txtPatternBox
            // 
            txtPatternBox.Location = new Point(12, 102);
            txtPatternBox.Name = "txtPatternBox";
            txtPatternBox.Size = new Size(252, 23);
            txtPatternBox.TabIndex = 4;
            txtPatternBox.Text = "*.txt";
            // 
            // lbInvalidChars
            // 
            lbInvalidChars.AutoSize = true;
            lbInvalidChars.Location = new Point(12, 128);
            lbInvalidChars.Name = "lbInvalidChars";
            lbInvalidChars.Size = new Size(104, 15);
            lbInvalidChars.TabIndex = 5;
            lbInvalidChars.Text = "Invalid Characters:";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(108, 183);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 23);
            btnOK.TabIndex = 6;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(189, 183);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FilePatternDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 220);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lbInvalidChars);
            Controls.Add(txtPatternBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FilePatternDialog";
            Text = "Add File Pattern";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtPatternBox;
        private Label lbInvalidChars;
        private Button btnOK;
        private Button btnCancel;
    }
}