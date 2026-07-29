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
    public partial class OptionsDialog : Form
    {
        public OptionsDialog()
        {
            InitializeComponent();
        }

        public void loadConfig(Config cfg)
        {
            lvMatchFiles.Clear();
            foreach (String matchFileString in cfg.fileEndings)
            {
                lvMatchFiles.Items.Add(matchFileString);
            }

            lvExcludeFiles.Clear();
            foreach (String fileToIgnore in cfg.filePatternsToIgnore)
            {
                lvExcludeFiles.Items.Add(fileToIgnore);
            }

            lvExcludeDirs.Clear();
            foreach (String dirToIgnore in cfg.directoriesToIgnore)
            {
                lvExcludeDirs.Items.Add(dirToIgnore);
            }

            cbJustList.Checked = cfg.dryRun;
            cbIncludeSubdirs.Checked = cfg.copySubDirectories;
            cbVerbose.Checked = cfg.verboseMode;

        }

        public void updateConfigFromDialog(Config cfg)
        {
            cfg.fileEndings.Clear();
            foreach (ListViewItem itmFileEnding in lvMatchFiles.Items)
            {
                cfg.fileEndings.Add(itmFileEnding.Text);
            }

            cfg.filePatternsToIgnore.Clear();
            foreach (ListViewItem itmFileIgnore in lvExcludeFiles.Items)
            {
                cfg.filePatternsToIgnore.Add(itmFileIgnore.Text);
            }

            cfg.directoriesToIgnore.Clear();
            foreach (ListViewItem itmDirToIgnore in lvExcludeDirs.Items)
            {
                cfg.directoriesToIgnore.Add(itmDirToIgnore.Text);
            }

            cfg.dryRun = cbJustList.Checked;
            cfg.copySubDirectories = cbIncludeSubdirs.Checked;
            cfg.verboseMode = cbVerbose.Checked;
        }

        private void btnResetDefault_Click(object sender, EventArgs e)
        {
            Config cfg = new Config();
            loadConfig(cfg);
        }

        private void lvExcludeDirs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddExcludeDirs_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder to exclude";
                dialog.UseDescriptionForTitle = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Get absolute/full path
                    string fullPath = Path.GetFullPath(dialog.SelectedPath);

                    lvExcludeDirs.Items.Add(fullPath);
                }
            }
        }

        private void btnRemoveExcludeDirs_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvExcludeDirs.SelectedItems)
            {
                lvExcludeDirs.Items.Remove(item);
            }
        }

        private void btnClearExcludeDirs_Click(object sender, EventArgs e)
        {
            lvExcludeDirs.Clear();
        }

        private void btnAddMatchFiles_Click(object sender, EventArgs e)
        {
            using (var dialog = new FilePatternDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Get pattern
                    string pattern = dialog.getFilePattern();
                    lvMatchFiles.Items.Add(pattern);
                }
            }
        }

        private void btnRemoveMatchFiles_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvMatchFiles.SelectedItems)
            {
                lvMatchFiles.Items.Remove(item);
            }
        }

        private void btnClearMatchFiles_Click(object sender, EventArgs e)
        {
            lvMatchFiles.Clear();
        }

        private void btnAddExcludeFiles_Click(object sender, EventArgs e)
        {
            using (var dialog = new FilePatternDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Get pattern
                    string pattern = dialog.getFilePattern();
                    lvExcludeFiles.Items.Add(pattern);
                }
            }
        }

        private void btnRemoveExcludeFiles_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvExcludeFiles.SelectedItems)
            {
                lvExcludeFiles.Items.Remove(item);
            }
        }

        private void btnClearExcludeFiles_Click(object sender, EventArgs e)
        {
            lvExcludeFiles.Clear();
        }
    }
}
