﻿using BuildingHelperFilesCreator.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingHelperFilesCreator
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			var args = Environment.GetCommandLineArgs();
			Console.WriteLine("Opened");
			if (args.Length > 1 && args[1] == "-v")
			{
				using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "version.txt")))
				{
					sw.Write(Assembly.GetEntryAssembly().GetName().Version);
				};
				return;
			}

			if (args.Length > 1 && args[1] == "-u")
			{
				MessageBox.Show("Application was successfully updated to new version.");
			}
			else
			{
				if (AutoUpdateService.CheckUpdates())
				{
					return;
				}
			}

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new BuildingHelperForm());
		}
	}
}
