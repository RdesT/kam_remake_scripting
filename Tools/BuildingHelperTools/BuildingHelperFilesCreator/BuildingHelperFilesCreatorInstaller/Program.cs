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
			if (args.Length > 2)
			{
				//We wait for main application to be closed.
				Task.Delay(500);
				File.Copy(args[1], args[2], true);
				Process.Start(args[2], "-u");
			}
		}
	}
}
