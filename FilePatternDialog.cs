using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YAHBackup
{
    public partial class FilePatternDialog : Form
    {
        public FilePatternDialog()
        {
            InitializeComponent();
            lbInvalidChars.Visible = false;
        }

        public String getFilePattern()
        {
            return txtPatternBox.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string pattern = txtPatternBox.Text;

            var invalidChars = Path.GetInvalidFileNameChars()
                       .Except(new[] { '*', '?' })
                       .ToHashSet();

            var illegal = pattern
                .Where(c => invalidChars.Contains(c))
                .Distinct()
                .ToArray();

            if (illegal.Any())
            {
                Console.WriteLine("foooo");
                lbInvalidChars.Text =
                    "Invalid characters: " +
                    string.Join(" ", illegal);

                lbInvalidChars.Visible = true;
                txtPatternBox.Focus();
                txtPatternBox.SelectAll();
                return;
            } else
            {
                lbInvalidChars.Visible = false;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
