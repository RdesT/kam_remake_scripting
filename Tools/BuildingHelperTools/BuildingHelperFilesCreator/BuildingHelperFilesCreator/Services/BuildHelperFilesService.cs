using BuildingHelperFilesCreator.Models;
using BuildingHelperFilesCreator.Models.Enums;
using BuildingHelperFilesCreator.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace BuildingHelperFilesCreator.Services
{
	public sealed class BuildHelperFilesService
	{
		private const string ScriptResoursePath = "BuildingHelperFilesCreator.Scripts.";
		private const string LocalizationsResoursePath = "BuildingHelperFilesCreator.Localizations.";
		private const string DefaultLocalizationFileName = "BuildHelper";
		private const string StrategyFileName = "BuildHelperStrategy.script";
		private const string MapInfoFileExtention = ".dat";
		private const string PlayersCountParameter = "!SET_MAX_PLAYER";

		public BuildHelperFilesService()
		{
		}

		public void CreateBuildHelperFiles(string folderName, string mapName, MapStrategy mapStrategy)
		{
			var assembly = Assembly.GetExecutingAssembly();

			foreach (var resourceName in assembly.GetManifestResourceNames())
			{
				if (resourceName.StartsWith(ScriptResoursePath))
				{
					using (var stream = assembly.GetManifestResourceStream(resourceName))
					{
						var fileName = Path.Combine(folderName, resourceName.Substring(ScriptResoursePath.Length));
						CreateFile(stream, fileName);
					}				
				}

				if (resourceName.StartsWith(LocalizationsResoursePath))
				{
					using (var stream = assembly.GetManifestResourceStream(resourceName))
					{
						var fileName = Path.Combine(folderName, mapName + resourceName.Substring(LocalizationsResoursePath.Length + DefaultLocalizationFileName.Length));
						CreateFile(stream, fileName);
					}
				}
			}

			GenerateStrategyFile(folderName, mapStrategy);
			IncludeToMapScriptFile(Path.Combine(folderName, mapName + ".script"));
		}

		public MapInfo GetMapInfo(string folderName)
		{
			var fileNames = Directory.GetFiles(folderName);

			foreach(var fileName in fileNames)
			{
				if (Path.GetExtension(fileName) == MapInfoFileExtention)
				{
					var playersCount = SearchPlayersCount(fileName);
					if (playersCount > 0)
					{
						return new MapInfo(Path.GetFileNameWithoutExtension(fileName), playersCount);
					}
				}
			}

			return null;
		}

		private void CreateFile(Stream stream, string fileName)
		{
			using (var fileStream = File.Create(fileName))
			{
				stream.CopyTo(fileStream);
			}		
		}

		private int SearchPlayersCount(string fileName)
		{
			var playersCountLine = File.ReadLines(fileName).SkipWhile(line => !line.Contains(PlayersCountParameter)).Take(1);
			if (playersCountLine != null && playersCountLine.Any())
			{
				var parameters = playersCountLine.First().Split(' ');
				if (parameters.Length > 1)
				{
					return Convert.ToInt32(parameters[1]);
				}
			}

			return -1;
		}

		private void GenerateStrategyFile(string folderName, MapStrategy mapStrategy)
		{
			var filePath = Path.Combine(folderName, StrategyFileName);

			using (StreamWriter writer = new StreamWriter(filePath))
			{
				writer.WriteLine("{$IFNDEF BuildHelperCore}");
				writer.WriteLine("	{$INCLUDE BuildHelperCore.script}");
				writer.WriteLine("{$ENDIF}");
				writer.WriteLine();
				writer.WriteLine("procedure BH_InitStrategy();");
				writer.WriteLine("begin");
				writer.WriteLine($"\tBH_GlobalBuildingStrategy := {mapStrategy.DefaultStrategy.DescriptionAttr()};");
				writer.WriteLine();

				foreach (var playerId in mapStrategy.CustomStrategies.Keys)
				{
					if (mapStrategy.DefaultStrategy != mapStrategy.CustomStrategies[playerId])
					{
						writer.WriteLine($"\tBH_AddPlayerStrategy({playerId}, {mapStrategy.CustomStrategies[playerId].DescriptionAttr()});");
					}
					
				}

				writer.WriteLine();
				writer.WriteLine("end;");
			}			
		}

		private void IncludeToMapScriptFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				var includeLine = File.ReadLines(filePath).SkipWhile(line =>
				{
					var lowCaseLine = line.ToLower();
					return !(lowCaseLine.Contains(@"{$INCLUDE BuildHelper.script}".ToLower()) || lowCaseLine.Contains(@"{$I BuildHelper.script}".ToLower()));
				}).Take(1);

				if (includeLine != null && !includeLine.Any())
				{
					var currentContent = File.ReadAllText(filePath);
					File.WriteAllText(filePath, "{$INCLUDE BuildHelper.script}\n" + currentContent);
				}
			}
			else
			{
				using (StreamWriter writer = new StreamWriter(filePath))
				{
					writer.WriteLine("{$INCLUDE BuildHelper.script}");
				}
			}
		}

		public MapStrategy ParseStrategyFile(string folderName)
		{
			var filePath = Path.Combine(folderName, StrategyFileName);

			if (!File.Exists(filePath))
			{
				return null;
			}

			var result = new MapStrategy();

			using (StreamReader reader = new StreamReader(filePath))
			{
				var line = reader.ReadLine();

				while (line != null)
				{
					if (line.Contains("BH_GlobalBuildingStrategy"))
					{
						var assignmentLocation = line.IndexOf(":=");
						var endOfAssignmentLocation = line.IndexOf(";");

						if (assignmentLocation > 0 || endOfAssignmentLocation > 0)
						{
							//2 is := length.
							var globalStrategyString = line.Substring(assignmentLocation + 2, endOfAssignmentLocation - assignmentLocation - 2).Trim();

							BuildingStrategyEnum defaultStrategy;

							if (EnumReflection.TryGetEnumByDescription(globalStrategyString, true, out defaultStrategy))
							{
								result.DefaultStrategy = defaultStrategy;
							}
						}								
					}
					else if (line.Contains("BH_AddPlayerStrategy"))
					{
						var assignmentLocation = line.IndexOf("(");
						var endOfAssignmentLocation = line.IndexOf(")");

						if (assignmentLocation > 0 || endOfAssignmentLocation > 0)
						{
							var parametersString = line.Substring(assignmentLocation + 1, endOfAssignmentLocation - assignmentLocation - 1).Trim();
							var parameters = parametersString.Split(',');

							if (parameters.Length == 2)
							{
								BuildingStrategyEnum strategy;

								if (EnumReflection.TryGetEnumByDescription(parameters[1].Trim(), true, out strategy))
								{
									result.CustomStrategies.Add(Convert.ToInt32(parameters[0].Trim()), strategy);
								}								
							}
						}							
					}

					line = reader.ReadLine();
				}
				
			}
			return result;
		}		
	}
}
