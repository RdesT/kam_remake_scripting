using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingHelperFilesCreator.Models.Enums
{
	public enum BuildingStrategyEnum
	{
		[Description("BS_Null")]
		None,
		[Description("BS_Default_60")]
		Default60,
		[Description("BS_IronStoring_60")]
		IronStoring60,
		[Description("BS_LeatherOnly_60")]
		LeatherOnly60,
	}
}
