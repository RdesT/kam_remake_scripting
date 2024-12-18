using BuildingHelperFilesCreator.Models.Enums;
using BuildingHelperFilesCreator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildingHelperFilesCreator
{
	public partial class MapLocation : UserControl
	{
		private readonly LocalizationService _localizationService;

		public BuildingStrategyEnum Strategy
		{
			get
			{
				return (BuildingStrategyEnum)StrategyComboBox.SelectedValue;
			}
			set { StrategyComboBox.SelectedValue = value; }
		}
		public int LocationId
		{
			get { return _locationId; }
			set
			{
				_locationId = value;
				LocationValueLabel.Text = (value + 1).ToString();
			}
		}

		public void Localize()
		{
			LocationLabel.Text = _localizationService.GetLocalizedString("Location");

			var selectedValue = StrategyComboBox.SelectedValue ?? BuildingStrategyEnum.Default60;

			_strategyValues.Clear();
			_strategyValues.Add(BuildingStrategyEnum.None, _localizationService.GetLocalizedString("Strategy.BS_Null"));
			_strategyValues.Add(BuildingStrategyEnum.Default60, _localizationService.GetLocalizedString("Strategy.BS_Default_60"));
			_strategyValues.Add(BuildingStrategyEnum.IronStoring60, _localizationService.GetLocalizedString("Strategy.BS_IronStoring_60"));
			//_strategyValues.Add(BuildingStrategyEnum.LeatherOnly60, _localizationService.GetLocalizedString("Strategy.BS_LeatherOnly_60"));

			StrategyComboBox.DataSource = new BindingSource(_strategyValues, null);
			StrategyComboBox.DisplayMember = "Value";
			StrategyComboBox.ValueMember = "Key";

			StrategyComboBox.SelectedValue = selectedValue;

		}

		private void FillComboBoxDataSourses()
		{
			
		}

		public MapLocation(LocalizationService localizationService)
		{
			_localizationService = localizationService;
			
			InitializeComponent();
			Localize();
		}

		private int _locationId;

		private readonly Dictionary<BuildingStrategyEnum, string> _strategyValues = new Dictionary<BuildingStrategyEnum, string>
		{
			{ BuildingStrategyEnum.None, "None" }, { BuildingStrategyEnum.Default60, "Default" }, { BuildingStrategyEnum.IronStoring60, "Iron storing" }//, { BuildingStrategyEnum.LeatherOnly60, "LeatherOnly" }
		};
	}
}
