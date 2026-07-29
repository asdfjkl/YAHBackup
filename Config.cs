using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Security.Principal;
using System.Text.Json;

namespace YAHBackup
{
    [DataContract]
    public class Config
    {        
        public string fnLogFile { get; set; } = GetDefaultLogPath();
        public bool overwriteLogFile { get; set; } = true;        
        public bool writeToLogAndConsole { get; set; } = false;
        public bool showHelp { get; set; } = false;
        public List<String> fileEndings { get; set; } = new List<string>();
        public bool copyAll { get; set; } = false;
        public bool logToFile { get; set; } = false;
        public bool pauseAtEnd { get; set; } = false;
        public string destinationDirectory { get; set; } = "";
        public bool copySubDirectories { get; set; } = true;        
        public List<string> inputDirectories { get; set; } = new List<string>();
        public List<string> absInputDirectories { get; set; } = new List<string>();
        public bool useVss { get; set; } = false;
        public List<string> filePatternsToIgnore { get; set; } = new List<string>();
        public List<string> directoriesToIgnore { get; set; } = new List<string>();
        public bool dryRun { get; set; } = false;
        public bool verboseMode { get; set; } = false;
        public List<string> commonDirsToIgnore { get; set; } = new List<string>()
        {
            "System Volume Information",
            "AppData\\Local\\Temp",
            "AppData\\Local\\Microsoft\\Windows\\INetCache",
            "C:\\Windows",
            "$Recycle.Bin"
        };
        public List<string> commonFilePatternsToIgnore { get; set; } = new List<string>()
        {
            "hiberfil.sys",
            "pagefile.sys",
            "swapfile.sys",
            "*.~",
            "*.tmp"
        };
        //private int logsCached;
        private const char _block = '#';
        private int maxLvel { get; set; } = int.MaxValue;
        
        public event Action<string> LogMessage;
        public event Action<int, string> ProgressChanged;

        public void checkConsistency()
        {
            // check if we have at least one input directory
            bool hasInput = false;

            // check if the supplied list of input directories (if any) is valid
            if (!(inputDirectories.Count == 0))
            {
                try
                {
                    foreach (string inDir in inputDirectories)
                    {
                        if (!System.IO.Directory.Exists(inDir))
                        {
                            throw new ArgumentException("error: " + inDir + " is not a valid directory");
                        }
                        // create full path from relative path
                        String absLine = System.IO.Path.GetFullPath(inDir);
                        this.absInputDirectories.Add(absLine);
                    }
                    hasInput = true;
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Error: invalid input directory specified: " + e.Message);
                }
            }

            if (!hasInput)
            {
                throw new ArgumentException("error: no valid input directory defined");
            }

            // check if we have a valid destination directory
            if (string.IsNullOrEmpty(this.destinationDirectory) || !System.IO.Directory.Exists(this.destinationDirectory))
            {
                throw new ArgumentException("error: no valid output directory defined or directory " +
                    "does not exist");
            }

            // create full path from relative path
            this.destinationDirectory = System.IO.Path.GetFullPath(this.destinationDirectory);

            if (this.destinationDirectory.EndsWith(":"))
            {
                this.destinationDirectory += "\\";
            }

            // check if we can create hardlinks at the destination directory
            string fn_now = DateTime.Now.ToString("yyyy'_'MM'_'dd_HH'_'mm'_'ss");
            string fn_txt = fn_now + ".txt";
            string fn_lnk = fn_now + ".lnk";
            try
            {
                System.IO.File.WriteAllText(fn_txt, "hardlink creation test");
            }
            catch (Exception e)
            {
                throw new ArgumentException("error: unable to create hardlinks on destination: " + e.Message);
            }
            if (!(CreateHardLink(fn_lnk, fn_txt, IntPtr.Zero)))
            {
                System.IO.File.Delete(fn_txt);
                throw new ArgumentException("error: unable to create hardlinks on destination.");
            }
            System.IO.File.Delete(fn_txt);
            System.IO.File.Delete(fn_lnk);


            if (this.useVss && !this.IsAdministrator())
            {
                throw new ArgumentException("error: shadow copy /vss requested, but program is not run with admin rights!");
            }

            // check if we have a valid log-file path
            if (!string.IsNullOrEmpty(this.fnLogFile))
            {
                // try to write or append log file
                // write time-stamp in header
                string now = DateTime.Now.ToString("yyyy'_'MM'_'dd_HH'_'mm'_'ss'Z'");
                if (this.overwriteLogFile)
                {
                    try
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.fnLogFile))
                        {
                            file.WriteLine("########################################");
                            file.WriteLine("# Copying started@ " + now);
                            file.WriteLine("########################################");
                        }
                        this.logToFile = true;

                    }
                    catch (System.IO.IOException)
                    {
                        throw new ArgumentException("error: IO exception writing to log file " + this.fnLogFile);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException("error: general exception writing to log file " + this.fnLogFile);
                    }

                }
                else
                {
                    try
                    {
                        using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.fnLogFile, append: true))
                        {
                            file.WriteLine("########################################");
                            file.WriteLine("# Copying started@ " + now);
                            file.WriteLine("########################################");
                        }
                        this.logToFile = true;
                    }
                    catch (System.IO.IOException)
                    {
                        throw new ArgumentException("error: IO exception appending to log file " + this.fnLogFile);
                    }
                    catch (Exception ex)
                    {
                        throw new ArgumentException("error: general exception appending to log file " + this.fnLogFile);
                    }

                }
            }
        }
       

        public void addToLog(string message)
        {
            LogMessage?.Invoke(message);

            if (this.logToFile)
            {
                using (System.IO.StreamWriter file =
                       new System.IO.StreamWriter(this.fnLogFile, append: true))
                {
                    file.WriteLine(message);
                }
            }
        }

        public void Save(string filePath)
        {
            string? dir = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(this, options);
            File.WriteAllText(filePath, json);
        }

        public static Config Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Config file not found", filePath);
            }

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<Config>(json)
                   ?? throw new InvalidDataException("Failed to deserialize config file.");
        }


        public void WriteProgressBar(string pre, string post, int percent, bool update = false)
        {
            ProgressChanged?.Invoke(percent, post);
        }

        public bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(
        string lpFileName,
        string lpExistingFileName,
        IntPtr lpSecurityAttributes
        );

        public static string GetDefaultConfigPath()
        {
            string appData = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData);

            return Path.Combine(appData, "YAHBackup", "config.json");
        }

        public static string GetDefaultLogPath()
        {
            string appData = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData);

            return Path.Combine(appData, "YAHBackup", "log.txt");
        }

        public void SaveDefault()
        {
            Save(GetDefaultConfigPath());
        }

        public static Config LoadDefault()
        {
            string path = GetDefaultConfigPath();

            if (!File.Exists(path))
            {
                return new Config();
            }

            return Load(path);
        }

        public override string ToString()
        {
            string currentCfg = "";
            currentCfg += "source dir(s)........: " + String.Join(", ", this.inputDirectories) + "\n";
            currentCfg += "destination dir......: " + this.destinationDirectory + "\n";
            currentCfg += "file endings.........: " + String.Join(", ", this.fileEndings) + "\n";
            currentCfg += "copy sub dirs........: " + this.copySubDirectories + "\n";
            currentCfg += "max dir level........: " + this.maxLvel + "\n";
            currentCfg += "use vss..............: " + this.useVss + "\n";
            currentCfg += "ignore patterns......: " + String.Join(", ", this.filePatternsToIgnore) + "\n";
            currentCfg += "ignore dirs..........: " + String.Join(", ", this.directoriesToIgnore) + "\n";
            currentCfg += "list only............: " + this.dryRun + "\n";
            currentCfg += "verbose mode.........: " + this.verboseMode + "\n";
            currentCfg += "log file name........: " + this.fnLogFile + "\n";
            currentCfg += "overwrite log........: " + this.overwriteLogFile + "\n";
            currentCfg += "write log and console: " + this.writeToLogAndConsole + "\n";
            currentCfg += "show help............: " + this.showHelp + "\n";
            return currentCfg;
        }
    }
}