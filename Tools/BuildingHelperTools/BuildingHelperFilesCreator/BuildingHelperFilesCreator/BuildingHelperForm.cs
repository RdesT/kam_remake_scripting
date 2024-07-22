using BuildingHelperFilesCreator.Extensions;
using BuildingHelperFilesCreator.Models;
using BuildingHelperFilesCreator.Models.Enums;
using BuildingHelperFilesCreator.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;

namespace BuildingHelperFilesCreator
{
	public partial class BuildingHelperForm : Form
	{
		private readonly FolderBrowserDialog _folderBrowserDialog = new FolderBrowserDialog();
		private readonly BuildHelperFilesService _filesService = new BuildHelperFilesService();
		private readonly LocalizationService _localizationService = new LocalizationService("en");
		private readonly TempConfigService _tempConfigService = new TempConfigService();
		private MapInfo _mapInfo;
		private MapLocation _defaultMapLocation = new MapLocation(new LocalizationService("en"));

		private readonly Dictionary<PeaceTimeEnum, string> _ptValues = new Dictionary<PeaceTimeEnum, string>
		{
			{ PeaceTimeEnum.PeaceTime60, "60" }, { PeaceTimeEnum.PeaceTime35, "35" }
		};
		private readonly Dictionary<BuildingStrategyEnum, string> _defaultStrategyValues = new Dictionary<BuildingStrategyEnum, string>();

		public BuildingHelperForm()
		{
			var config = _tempConfigService.ReadConfig();

			if (config != null && !string.IsNullOrEmpty(config.SelectedLanguage))
			{
				_localizationService.CurrentLanguage = config.SelectedLanguage;
			}

			InitializeComponent();

			Localize();

			PeaceTimeComboBox.DataSource = new BindingSource(_ptValues, null);
			PeaceTimeComboBox.DisplayMember = "Value";
			PeaceTimeComboBox.ValueMember = "Key";
			PeaceTimeComboBox.Enabled = false;

			if (config != null && config.LastFolder != null && Directory.Exists(config.LastFolder))
			{
				TryToOpenMap(config.LastFolder);
			}
		}

		private void CreateCustomLocationsControls(MapStrategy mapStrategy)
		{
			BotPannel.Controls.Clear();

			for (int i = 0; i<_mapInfo.PlayersCount; i++)
			{
				var mapLocation = new MapLocation(_localizationService);
				mapLocation.LocationId = i;
				if (mapStrategy != null && mapStrategy.CustomStrategies.ContainsKey(i))
				{
					mapLocation.Strategy = mapStrategy.CustomStrategies[i];
				}
				else
				{
					mapLocation.Strategy = (BuildingStrategyEnum)DefaultStrategyComboBox.SelectedValue;
				}
			
				BotPannel.Controls.Add(mapLocation);

				int x = mapLocation.LocationId % 5 * (mapLocation.Width + 20);
				int y = mapLocation.LocationId / 5 * mapLocation.Height;
				mapLocation.Location = new Point(30 + x, y);
			}
		}

		private void SaveConfig()
		{
			_tempConfigService.SaveConfig(new BuildHelperConfig
			{
				LastFolder = CurrentDirrectoryTextBox.Text,
				SelectedLanguage = _localizationService.CurrentLanguage
			});
		}

		private bool TryToOpenMap(string folderPath)
		{
			_mapInfo = _filesService.GetMapInfo(folderPath);

			if (_mapInfo != null)
			{
				CurrentDirrectoryTextBox.Text = folderPath;
				MapNameTextBox.Text = _mapInfo.Name;

				var mapStrategy = _filesService.ParseStrategyFile(folderPath);

				CreateCustomLocationsControls(mapStrategy);

				if (mapStrategy != null)
				{
					if (mapStrategy.CustomStrategies.Keys.Count > 0)
					{
						CustomStrategiesCheckBox.Checked = true;
					}
					DefaultStrategyComboBox.SelectedValue = mapStrategy.DefaultStrategy;
				}

				BotPannel.Visible = true;
				TopPannel.Visible = true;
				return true;
			}

			BotPannel.Visible = false;
			TopPannel.Visible = false;
			return false;
		}

		private void CreateLanguageMenu()
		{
			LanguageToolStrip.DropDownItems.Clear();
			AddLanguageMenuItem("en");
			AddLanguageMenuItem("ru");
			AddLanguageMenuItem("de");
			AddLanguageMenuItem("pl");
		}

		private void AddLanguageMenuItem(string language)
		{
			var item = new ToolStripMenuItem();

			item.Tag = language;
			item.Checked = language == _localizationService.CurrentLanguage;
			item.Click += LanguageItem_Click;
			item.Text = _localizationService.GetLocalizedString($"Language.{language}");

			LanguageToolStrip.DropDownItems.Add(item);
		}

		private void FillComboBoxDataSourses()
		{
			var selectedValue = DefaultStrategyComboBox.SelectedValue ?? BuildingStrategyEnum.Default60;

			_defaultStrategyValues.Clear();
			_defaultStrategyValues.Add(BuildingStrategyEnum.Default60, _localizationService.GetLocalizedString("Strategy.BS_Default_60"));
			_defaultStrategyValues.Add(BuildingStrategyEnum.IronStoring60, _localizationService.GetLocalizedString("Strategy.BS_IronStoring_60"));
			_defaultStrategyValues.Add(BuildingStrategyEnum.LeatherOnly60, _localizationService.GetLocalizedString("Strategy.BS_LeatherOnly_60"));
			//_defaultStrategyValues.Add(BuildingStrategyEnum.LeatherOnly60, GetLocalizedString("Strategy.DoubleStable"));
			//_defaultStrategyValues.Add(BuildingStrategyEnum.LeatherOnly60, GetLocalizedString("Strategy.IronRush"));

			DefaultStrategyComboBox.DataSource = new BindingSource(_defaultStrategyValues, null);
			DefaultStrategyComboBox.DisplayMember = "Value";
			DefaultStrategyComboBox.ValueMember = "Key";

			DefaultStrategyComboBox.SelectedValue = selectedValue;
		}

		private void UpsertDefaultStrategyDictionaryValue(BuildingStrategyEnum key, string value)
		{
			if (_defaultStrategyValues.ContainsKey(key))
			{
				_defaultStrategyValues[key] = value;
			}
			else
			{
				_defaultStrategyValues.Add(key, value);
			}
		}

		#region Localization

		private void Localize()
		{
			var sizeString = _localizationService.GetLocalizedString($"{Name}.Size");

			if (sizeString != null)
			{
				var size = sizeString.Split(';');
				Size = new Size(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));

				if (CustomStrategiesCheckBox.Checked && _mapInfo != null)
				{
					Height = Height + (_mapInfo.PlayersCount / 5 + 1) * _defaultMapLocation.Height;
				}				
			}

			foreach (Control control in BotPannel.Controls)
			{ 
				if (control is MapLocation)
				{
					((MapLocation)control).Localize();
				}
			}

			LocalizeControls(Controls);
			CreateLanguageMenu();
			FillComboBoxDataSourses();
		}

		private void LocalizeControls(Control.ControlCollection controls)
		{
			foreach(Control control in controls)
			{
				if (control is MenuStrip)
				{
					LocalizeToolStrip(((MenuStrip)control).Items);
				}
				else
				{
					LocalizeControls(control.Controls);
				}

				LocalizeControl(control);
			}
		}

		private void LocalizeToolStrip(ToolStripItemCollection itemCollection)
		{
			foreach (ToolStripMenuItem item in itemCollection)
			{
				LocalizeToolStripMenuItem(item);
			}
		}

		private void LocalizeControl(Control control)
		{
			var textString = _localizationService.GetLocalizedString($"Control.{control.Name}.Text");
			var sizeString = _localizationService.GetLocalizedString($"Control.{control.Name}.Size");
			var locationString = _localizationService.GetLocalizedString($"Control.{control.Name}.Location");

			if (textString != null)
			{
				control.Text = textString;
			}

			if (sizeString != null)
			{
				var size = sizeString.Split(';');
				control.Size = new Size(Convert.ToInt32(size[0]), Convert.ToInt32(size[1]));
			}

			if (locationString != null)
			{
				var location = locationString.Split(';');
				control.Location = new Point(Convert.ToInt32(location[0]), Convert.ToInt32(location[1]));
			}
		}

		private void LocalizeToolStripMenuItem(ToolStripMenuItem item)
		{
			var textString = _localizationService.GetLocalizedString($"Control.{item.Name}.Text");

			if (textString != null)
			{
				item.Text = textString;
			}
		}	

		#endregion

		#region Events

		private void HelpToolStrip_Click(object sender, EventArgs e)
		{

		}

		private void CreateFilesButton_Click(object sender, EventArgs e)
		{

			try
			{
				var mapStrategy = new MapStrategy();

				mapStrategy.DefaultStrategy = (BuildingStrategyEnum)DefaultStrategyComboBox.SelectedValue;

				if (CustomStrategiesCheckBox.Checked)
				{
					foreach (var control in BotPannel.Controls)
					{
						var mapLocation = control as MapLocation;
						if (mapLocation == null)
						{
							continue;
						}

						mapStrategy.CustomStrategies.Add(mapLocation.LocationId, mapLocation.Strategy);
					}
				}

				_filesService.CreateBuildHelperFiles(CurrentDirrectoryTextBox.Text, _mapInfo.Name, mapStrategy);

				MessageBox.Show("Files were successfully created!");
			}
			catch (Exception exc)
			{
				MessageBox.Show("Unexpected error in file creating process. " + exc.Message);
			}
		}

		private void BuildingHelperForm_Shown(object sender, EventArgs e)
		{
		}

		private void OpenMapFolderToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (_folderBrowserDialog.ShowDialog() == DialogResult.OK)
			{
				_mapInfo = _filesService.GetMapInfo(_folderBrowserDialog.SelectedPath);

				if (!TryToOpenMap(_folderBrowserDialog.SelectedPath))
				{
					MessageBox.Show("Map files were not found. Select other folder.");
				}
			}
		}

		private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BuildingHelperForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			SaveConfig();
		}

		private void LanguageItem_Click(object sender, EventArgs e)
		{
			var item = sender as ToolStripMenuItem;

			if (item.Tag.ToString() != _localizationService.CurrentLanguage)
			{
				_localizationService.CurrentLanguage = item.Tag.ToString();
				Localize();
			}		
		}

		private void CustomStrategiesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (CustomStrategiesCheckBox.Checked)
			{
				BotPannel.Visible = true;
				Height = Height + (_mapInfo.PlayersCount / 5 + 1) * _defaultMapLocation.Height;
			}
			else
			{
				BotPannel.Visible = false;
				Height = Height - (_mapInfo.PlayersCount / 5 + 1) * _defaultMapLocation.Height;
			}
		}
		
		#endregion
	}
}
