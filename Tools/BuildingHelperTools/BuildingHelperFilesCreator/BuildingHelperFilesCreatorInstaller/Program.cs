using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuildingHelperFilesCreatorInstaller
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			var latestExePath = string.Empty;
			var appExePath = string.Empty;

			for (int i = 0; i < args.Length; i++)
			{
				if (args[i] == "-latestExePath")
				{
					latestExePath = args[i + 1];
				}
				if (args[i] == "-appExePath")
				{
					appExePath = args[i + 1];
				}
			}

			if (string.IsNullOrEmpty(latestExePath) || string.IsNullOrEmpty(appExePath))
			{
				Console.WriteLine("Wrong arguments");
				return;
			}

			var processInfo = new ProcessStartInfo()
			{
				FileName = appExePath,
				WorkingDirectory = new FileInfo(appExePath).Directory.FullName,
			};

			try
			{
				//We wait for main application to be closed.
				Task.Delay(2000);

				File.Copy(latestExePath, appExePath, true);

				processInfo.Arguments = "-update";

				Process.Start(processInfo);
			}
			catch(Exception exc)
			{
				//Starting process once again if we failed to update for some reason.
				Console.WriteLine(exc);
				processInfo.Arguments = "-updateFailed";
				Process.Start(processInfo);
			}
		}
	}
}
