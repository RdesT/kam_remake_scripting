using BuildingHelperFilesCreator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHelperFilesCreator.Services
{
	public sealed class TempConfigService
	{
		private const string TempFileName = "BuildingHelperFilesCreator.tmp"; 

		public void SaveConfig(BuildHelperConfig config)
		{
			var filePath = Path.Combine(Path.GetTempPath(), TempFileName);

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine(config.LastFolder);
				writer.WriteLine(config.SelectedLanguage);
			}
		}

		public BuildHelperConfig ReadConfig()
		{
			var filePath = Path.Combine(Path.GetTempPath(), TempFileName);

			if (!File.Exists(filePath))
			{
				return null;
			}

			using (StreamReader reader = new StreamReader(filePath))
			{
				var result = new BuildHelperConfig()
				{
					LastFolder = reader.ReadLine(),
					SelectedLanguage = reader.ReadLine(),
				};

				return result;
			}
		}
	}
}
