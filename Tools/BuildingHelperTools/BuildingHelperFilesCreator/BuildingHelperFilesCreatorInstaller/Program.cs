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
			if (args.Length > 1)
			{
				try
				{
					//We wait for main application to be closed.
					Task.Delay(500);
					File.Copy(args[0], args[1], true);
					var processInfo = new ProcessStartInfo()
					{
						FileName = args[1],
						WorkingDirectory = new FileInfo(args[1]).Directory.FullName,
						Arguments = "-u"
					};
					Process.Start(processInfo);
				
				}
				catch (Exception exc)
				{
					Console.WriteLine(exc);
				}
			}
		}
	}
}
