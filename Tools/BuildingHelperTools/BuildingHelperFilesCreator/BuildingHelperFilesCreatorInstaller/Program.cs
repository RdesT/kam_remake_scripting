using CommandLine;
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
		public class Options
		{
			[Option("latestExePath", Required = true, HelpText = "Path to latest executable that was downloaded")]
			public string LatestExePath { get; set; }
			[Option("appExePath", Required = true, HelpText = "Path to application where we want to update executable.")]
			public string AppExePath { get; set; }
		}

		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;

			Parser.Default.ParseArguments<Options>(args).WithParsed(opts =>
			{
				if (string.IsNullOrWhiteSpace(opts.LatestExePath))
					throw new Exception(
						"Wrong arguments! Check latestExePath parameter!");
				if (string.IsNullOrWhiteSpace(opts.AppExePath))
					throw new Exception(
						"Wrong arguments! Check appExePath parameter!");
				
				var processInfo = new ProcessStartInfo()
				{
					FileName = opts.AppExePath,
					WorkingDirectory = new FileInfo(opts.AppExePath).Directory.FullName,
				};
				
				try
				{
					//We wait for main application to be closed.
					Task.Delay(1500);

					File.Copy(opts.LatestExePath, opts.AppExePath, true);

					processInfo.Arguments = "";

					Process.Start(processInfo);
				}		
				catch
				{
					//Starting process once again if we failed to update for some reason.
					processInfo.Arguments = "";
					Process.Start(processInfo);
				}
			});			
		}
	}
}
