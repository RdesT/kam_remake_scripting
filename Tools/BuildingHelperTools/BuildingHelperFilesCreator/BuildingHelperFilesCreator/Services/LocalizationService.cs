using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHelperFilesCreator.Services
{
	public sealed class LocalizationService
	{
		public LocalizationService(string currentLanguage)
		{
			CurrentLanguage = currentLanguage;
		}

		public string CurrentLanguage { get; set; }

		public string GetLocalizedString(string key)
		{
			var resourceFileName = $"BuildingHelperFilesCreator.Resources.{CurrentLanguage}";
			ResourceManager rm = new ResourceManager(resourceFileName, Assembly.GetExecutingAssembly());
			return rm.GetString(key);
		}
	}
}
