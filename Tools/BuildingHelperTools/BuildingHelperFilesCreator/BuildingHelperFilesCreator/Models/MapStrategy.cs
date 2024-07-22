using BuildingHelperFilesCreator.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHelperFilesCreator.Models
{
	public class MapStrategy
	{
		public BuildingStrategyEnum DefaultStrategy { get; set; }
		public Dictionary <int, BuildingStrategyEnum> CustomStrategies = new Dictionary<int, BuildingStrategyEnum>();
	}
}
