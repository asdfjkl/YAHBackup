using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Principal;


namespace YAHBackup
{
    public partial class YAHBackup : Form
    {
        private Config _config;
        CancellationTokenSource cts;
        private Process? _process;
        private bool _initializing;

        // Import the SetThreadExecutionState function from kernel32.dll
        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);

        // Flags for SetThreadExecutionState
        const uint ES_CONTINUOUS = 0x80000000;
        const uint ES_SYSTEM_REQUIRED = 0x00000001;

        public YAHBackup()
        {
            _initializing = true;
            InitializeComponent();
            _config = Config.LoadDefault();
            LoadConfigToUI(_config);
            this.FormClosing += YAHBackup_FormClosing;
            toolStripStatusLabel.Text = "";

            _config.LogMessage += AddLog;
            _config.ProgressChanged += UpdateProgress;

            _initializing = false;

            // check if useVSS is enabled and if we are in admin mode. if not, immediatley restart
            // requesting admin rights
            if (_config.useVss && (!IsAdministrator()))
            {
                RestartAsAdministrator();
                return;
            }
            SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED);
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
            OptionsDialog dlg = new OptionsDialog();
            dlg.loadConfig(_config);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                dlg.updateConfigFromDialog(_config);
            }
        }

        private void LoadConfigToUI(Config cfg)
        {
            lvFoldersToSave.Clear();
            foreach (String dir in cfg.inputDirectories)
            {
                lvFoldersToSave.Items.Add(dir);
            }
            tbTargetDir.Text = cfg.destinationDirectory;
            cbVSS.Checked = cfg.useVss;
        }

        private Config UpdateConfigFromUI(Config cfg)
        {
            cfg.inputDirectories.Clear();
            foreach (ListViewItem item in lvFoldersToSave.Items)
            {
                cfg.inputDirectories.Add(item.Text);
            }
            cfg.destinationDirectory = tbTargetDir.Text;
            cfg.useVss = cbVSS.Checked;
            return cfg;
        }

        private void YAHBackup_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                UpdateConfigFromUI(_config);
                _config.SaveDefault();
                SetThreadExecutionState(ES_CONTINUOUS);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to save configuration:\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void lvFoldersToSave_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder to save";
                dialog.UseDescriptionForTitle = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Get absolute/full path
                    string fullPath = Path.GetFullPath(dialog.SelectedPath);

                    // Ensure list exists
                    if (_config.inputDirectories == null)
                    {
                        _config.inputDirectories = new List<string>();
                    }

                    // Avoid duplicates (optional)
                    if (!_config.inputDirectories.Contains(fullPath))
                    {
                        _config.inputDirectories.Add(fullPath);
                    }

                    // Refresh UI
                    LoadConfigToUI(_config);
                }
            }
        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvFoldersToSave.SelectedItems)
            {
                lvFoldersToSave.Items.Remove(item);
            }
            UpdateConfigFromUI(_config);
        }

        private void btnClearFolders_Click(object sender, EventArgs e)
        {
            _config.inputDirectories.Clear();
            LoadConfigToUI(_config);
        }

        private void btnSelectTargetDir_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select target folder";
                dialog.UseDescriptionForTitle = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    // Get absolute/full path
                    string fullPath = Path.GetFullPath(dialog.SelectedPath);
                    _config.destinationDirectory = fullPath;

                    // Refresh UI
                    LoadConfigToUI(_config);
                }
            }
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Load Config File (.json)";
                dialog.Filter = "JSON Config Files (*.json)|*.json";
                dialog.DefaultExt = "json";
                dialog.CheckFileExists = true;
                dialog.Multiselect = false;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _config = Config.Load(dialog.FileName);
                        _config.LogMessage += AddLog;
                        _config.ProgressChanged += UpdateProgress;
                        // Refresh UI
                        LoadConfigToUI(_config);

                        MessageBox.Show(
                            "Configuration loaded successfully.",
                            "Load Config File",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Failed to load configuration:\n\n{ex.Message}",
                            "Load Config File Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save Config File (.json)";
                dialog.Filter = "JSON Config Files (*.json)|*.json";
                dialog.DefaultExt = "json";
                dialog.AddExtension = true;
                dialog.OverwritePrompt = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _config.Save(dialog.FileName);

                        MessageBox.Show(
                            "Configuration saved successfully.",
                            "Save Config File",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Failed to save configuration:\n\n{ex.Message}",
                            "Save Config File Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AddLog(string msg)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<string>(AddLog), msg);
                return;
            }

            tbLog.AppendText(msg + Environment.NewLine);
        }

        private void UpdateProgress(int percent, string text)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int, string>(UpdateProgress),
                       percent, text);
                return;
            }

            if (pbProgressBackup.Style == ProgressBarStyle.Marquee)
            {
                pbProgressBackup.Style = ProgressBarStyle.Continuous;
            }


            pbProgressBackup.Value = Math.Min(percent, 100);

            if (text.Length > 0)
            {
                toolStripStatusLabel.Text = "Estimated Time Remaining: " + text;
            }
            else
            {
                toolStripStatusLabel.Text = "";
            }
        }

        private async void btnStartBackup_Click(object sender, EventArgs e)
        {
            cbVSS.Enabled = false;
            btnStartBackup.Enabled = false;
            btnAbortBackup.Enabled = true;
            btnAddFolder.Enabled = false;
            btnRemoveFolder.Enabled = false;
            btnClearFolders.Enabled = false;
            btnLoadSettings.Enabled = false;
            btnSaveSettings.Enabled = false;
            btnSelectTargetDir.Enabled = false;
            btnOptions.Enabled = false;
            btnAbout.Enabled = false;

            tbLog.Clear();

            cts = new CancellationTokenSource();

            _config.absInputDirectories.Clear();
            try
            {
                _config.checkConsistency();
            } catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        

            CopyModule copy = new CopyModule(_config, cts.Token);

            pbProgressBackup.Style = ProgressBarStyle.Marquee;
            await Task.Run(() =>
            {
                copy.createFileList(copy.createDirectoryList());
                copy.doCopy();
            });


            pbProgressBackup.Value = 100;
            cbVSS.Enabled = true;
            btnStartBackup.Enabled = true;
            btnAbortBackup.Enabled = false;
            btnAddFolder.Enabled = true;
            btnRemoveFolder.Enabled = true;
            btnClearFolders.Enabled = true;
            btnLoadSettings.Enabled = true;
            btnSaveSettings.Enabled = true;
            btnSelectTargetDir.Enabled = true;
            btnOptions.Enabled = true;
            btnAbout.Enabled = true;

            tbLog.AppendText(Environment.NewLine +
                              "Finished." + Environment.NewLine);
            pbProgressBackup.Value = 0;
        }

        private void btnAbortBackup_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                btnAbortBackup.Enabled = false;
                cts.Cancel();
                pbProgressBackup.Style = ProgressBarStyle.Continuous;
                pbProgressBackup.Value = 0;

            }
        }

        private void cbVSS_CheckedChanged(object sender, EventArgs e)
        {
            if (_initializing)
            {
                return;
            }

            Debug.WriteLine("is admin: " + IsAdministrator());
            if (cbVSS.Checked)
            {
                Debug.WriteLine("checked changed + checked");
                if (!IsAdministrator())
                {
                    _config.useVss = true;
                    _config.SaveDefault();
                    RestartAsAdministrator();
                }
            }

        }


        private void RestartAsAdministrator()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = Application.ExecutablePath,
                    Arguments = "", // arguments,
                    UseShellExecute = true,
                    Verb = "runas"
                });
                //Application.Exit();
                SetThreadExecutionState(ES_CONTINUOUS);
                Environment.Exit(0);

            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                // ERROR_CANCELLED (1223): user clicked "No" on the UAC prompt.
                if (ex.NativeErrorCode != 1223)
                {
                    throw;
                }
                else
                {
                    _config.useVss = false;
                    LoadConfigToUI(_config);

                }
            }
        }

        private bool IsAdministrator()
        {
            using var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);

            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FileVersionInfo version = Process.GetCurrentProcess().MainModule.FileVersionInfo;
            MessageBox.Show(
"YAHBackup " + version.FileVersion + "\n\n" +
@"Copyright (C) 2026 Dominik Klein
Licensed under GNU GPL v2.

GitHub:
https://github.com/asdfjkl/YAHBackup

Credits:
- Application icon: KDE/oxygen-icons ",
"About",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
