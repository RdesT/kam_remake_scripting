using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHelperFilesCreator.Models
{
	public class MapInfo
	{
		public MapInfo(string name, int playersCount)
		{
			Name = name;
			PlayersCount = playersCount;
		}

		public string Name { get; private set; }
		public int PlayersCount { get; private set; }
	}
}
