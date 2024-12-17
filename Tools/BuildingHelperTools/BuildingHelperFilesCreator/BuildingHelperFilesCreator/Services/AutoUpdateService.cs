using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHelperFilesCreator.Services
{
	public static class AutoUpdateService
	{
        private const string RepositoryLink = "https://raw.githubusercontent.com/RdesT/kam_remake_scripting/";
        private const string ExecutableFolderPath = "/Tools/BuildingHelperTools/BuildingHelperFilesCreator/Executable/";
        private const string MasterBranchName = "main";
        private const string VersionFileName = "version.txt";
        private const string ExecutableFileName = "BuildingHelper.exe";

        public static void CheckUpdates()
		{
            using (WebClient wc = new WebClient())
            {
                try
                {
                    var latestVersion = wc.DownloadString(RepositoryLink + MasterBranchName + ExecutableFolderPath + VersionFileName);
                    if (latestVersion != Assembly.GetEntryAssembly().GetName().Version.ToString())
					{
                        var parts = latestVersion.Split('.');
                        var latestBranchName = $"{parts[0]}.{parts[1]}";
                        var tempFolder = Path.GetTempPath();

                        wc.DownloadFile(RepositoryLink + latestBranchName + ExecutableFolderPath + ExecutableFileName, tempFolder + ExecutableFileName);

                        //Download file.
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }          
		}
	}
}
