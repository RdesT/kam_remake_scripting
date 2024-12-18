using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingHelperFilesCreator.Services
{
	public static class AutoUpdateService
	{
        private const string ExecutableUrl = "https://raw.githubusercontent.com/RdesT/kam_remake_scripting/main/Tools/BuildingHelperTools/BuildingHelperFilesCreator/Executable/";
        private const string VersionFileName = "version.txt";
        private const string ExecutableFileName = "BuildHelper.exe";
        private const string InstallerFileName = "BuildingHelperFilesCreatorInstaller.exe";

        public static bool CheckUpdates()
		{
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var latestVersion = wc.DownloadString(ExecutableUrl + VersionFileName);
                    var tempFolder = Path.GetTempPath();
                    var tempInstallerExePath = Path.Combine(tempFolder, "BuildHelperInstaller.exe");
                    var latestExecutableFilePath = Path.Combine(tempFolder, ExecutableFileName);

                    if (latestVersion != Assembly.GetEntryAssembly().GetName().Version.ToString())
					{                       
                        //Download file.
                        wc.DownloadFile(ExecutableUrl + ExecutableFileName, latestExecutableFilePath);
                        
                        var installerResourceName = Assembly.GetExecutingAssembly().GetManifestResourceNames().FirstOrDefault(f => f == $"BuildingHelperFilesCreator.{InstallerFileName}");

                        using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(installerResourceName))
                        {
                            using (var fileStream = File.Create(tempInstallerExePath))
                            {
                                stream.CopyTo(fileStream);
                            }
                        }

                        Process.Start(tempInstallerExePath, $"-latestExePath \"{latestExecutableFilePath}\" -appExePath \"{Environment.GetCommandLineArgs()[0]}\"");
                        return true;             
                    }
					else
					{
                        //Remove all garbage from temp folder.

                        if (File.Exists(tempInstallerExePath))
                        {
                            File.Delete(tempInstallerExePath);
						}
                        if (File.Exists(latestExecutableFilePath))
                        {
                            File.Delete(latestExecutableFilePath);
                        }

                        return false;
					}
                }
                catch (Exception ex)
                {
                    return false;
                }
            }          
		}
	}
}
