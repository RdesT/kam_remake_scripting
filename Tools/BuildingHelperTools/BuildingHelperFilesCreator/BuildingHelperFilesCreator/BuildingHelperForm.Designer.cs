
namespace BuildingHelperFilesCreator
{
	partial class BuildingHelperForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildingHelperForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.OpenMapFolderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.LanguageToolStrip = new System.Windows.Forms.ToolStripMenuItem();
			this.HelpToolStrip = new System.Windows.Forms.ToolStripMenuItem();
			this.ExitToolStrip = new System.Windows.Forms.ToolStripMenuItem();
			this.TopPannel = new System.Windows.Forms.Panel();
			this.PeaceTimeComboBox = new System.Windows.Forms.ComboBox();
			this.PeaceTimeLabel = new System.Windows.Forms.Label();
			this.CustomStrategiesCheckBox = new System.Windows.Forms.CheckBox();
			this.DefaultStrategyComboBox = new System.Windows.Forms.ComboBox();
			this.DefaultStrategyLabel = new System.Windows.Forms.Label();
			this.CreateFilesButton = new System.Windows.Forms.Button();
			this.MapNameTextBox = new System.Windows.Forms.TextBox();
			this.MapNameLabel = new System.Windows.Forms.Label();
			this.CurrentDirrectoryTextBox = new System.Windows.Forms.TextBox();
			this.CurrentDirrectoryLabel = new System.Windows.Forms.Label();
			this.BotPannel = new System.Windows.Forms.Panel();
			this.menuStrip1.SuspendLayout();
			this.TopPannel.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenMapFolderMenuItem,
            this.LanguageToolStrip,
            this.HelpToolStrip,
            this.ExitToolStrip});
			resources.ApplyResources(this.menuStrip1, "menuStrip1");
			this.menuStrip1.Name = "menuStrip1";
			// 
			// OpenMapFolderMenuItem
			// 
			this.OpenMapFolderMenuItem.Name = "OpenMapFolderMenuItem";
			resources.ApplyResources(this.OpenMapFolderMenuItem, "OpenMapFolderMenuItem");
			this.OpenMapFolderMenuItem.Click += new System.EventHandler(this.OpenMapFolderToolStripMenuItem_Click);
			// 
			// LanguageToolStrip
			// 
			this.LanguageToolStrip.Name = "LanguageToolStrip";
			resources.ApplyResources(this.LanguageToolStrip, "LanguageToolStrip");
			// 
			// HelpToolStrip
			// 
			this.HelpToolStrip.Name = "HelpToolStrip";
			resources.ApplyResources(this.HelpToolStrip, "HelpToolStrip");
			this.HelpToolStrip.Click += new System.EventHandler(this.HelpToolStrip_Click);
			// 
			// ExitToolStrip
			// 
			this.ExitToolStrip.Name = "ExitToolStrip";
			resources.ApplyResources(this.ExitToolStrip, "ExitToolStrip");
			this.ExitToolStrip.Click += new System.EventHandler(this.ExitToolStripMenuItem1_Click);
			// 
			// TopPannel
			// 
			this.TopPannel.Controls.Add(this.PeaceTimeComboBox);
			this.TopPannel.Controls.Add(this.PeaceTimeLabel);
			this.TopPannel.Controls.Add(this.CustomStrategiesCheckBox);
			this.TopPannel.Controls.Add(this.DefaultStrategyComboBox);
			this.TopPannel.Controls.Add(this.DefaultStrategyLabel);
			this.TopPannel.Controls.Add(this.CreateFilesButton);
			this.TopPannel.Controls.Add(this.MapNameTextBox);
			this.TopPannel.Controls.Add(this.MapNameLabel);
			this.TopPannel.Controls.Add(this.CurrentDirrectoryTextBox);
			this.TopPannel.Controls.Add(this.CurrentDirrectoryLabel);
			resources.ApplyResources(this.TopPannel, "TopPannel");
			this.TopPannel.Name = "TopPannel";
			// 
			// PeaceTimeComboBox
			// 
			this.PeaceTimeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.PeaceTimeComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.PeaceTimeComboBox, "PeaceTimeComboBox");
			this.PeaceTimeComboBox.Name = "PeaceTimeComboBox";
			// 
			// PeaceTimeLabel
			// 
			resources.ApplyResources(this.PeaceTimeLabel, "PeaceTimeLabel");
			this.PeaceTimeLabel.Name = "PeaceTimeLabel";
			// 
			// CustomStrategiesCheckBox
			// 
			resources.ApplyResources(this.CustomStrategiesCheckBox, "CustomStrategiesCheckBox");
			this.CustomStrategiesCheckBox.Name = "CustomStrategiesCheckBox";
			this.CustomStrategiesCheckBox.UseVisualStyleBackColor = true;
			this.CustomStrategiesCheckBox.CheckedChanged += new System.EventHandler(this.CustomStrategiesCheckBox_CheckedChanged);
			// 
			// DefaultStrategyComboBox
			// 
			this.DefaultStrategyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.DefaultStrategyComboBox.FormattingEnabled = true;
			resources.ApplyResources(this.DefaultStrategyComboBox, "DefaultStrategyComboBox");
			this.DefaultStrategyComboBox.Name = "DefaultStrategyComboBox";
			// 
			// DefaultStrategyLabel
			// 
			resources.ApplyResources(this.DefaultStrategyLabel, "DefaultStrategyLabel");
			this.DefaultStrategyLabel.Name = "DefaultStrategyLabel";
			// 
			// CreateFilesButton
			// 
			resources.ApplyResources(this.CreateFilesButton, "CreateFilesButton");
			this.CreateFilesButton.Name = "CreateFilesButton";
			this.CreateFilesButton.UseVisualStyleBackColor = true;
			this.CreateFilesButton.Click += new System.EventHandler(this.CreateFilesButton_Click);
			// 
			// MapNameTextBox
			// 
			resources.ApplyResources(this.MapNameTextBox, "MapNameTextBox");
			this.MapNameTextBox.Name = "MapNameTextBox";
			// 
			// MapNameLabel
			// 
			resources.ApplyResources(this.MapNameLabel, "MapNameLabel");
			this.MapNameLabel.Name = "MapNameLabel";
			// 
			// CurrentDirrectoryTextBox
			// 
			resources.ApplyResources(this.CurrentDirrectoryTextBox, "CurrentDirrectoryTextBox");
			this.CurrentDirrectoryTextBox.Name = "CurrentDirrectoryTextBox";
			// 
			// CurrentDirrectoryLabel
			// 
			resources.ApplyResources(this.CurrentDirrectoryLabel, "CurrentDirrectoryLabel");
			this.CurrentDirrectoryLabel.Name = "CurrentDirrectoryLabel";
			// 
			// BotPannel
			// 
			resources.ApplyResources(this.BotPannel, "BotPannel");
			this.BotPannel.Name = "BotPannel";
			// 
			// BuildingHelperForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.BotPannel);
			this.Controls.Add(this.TopPannel);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "BuildingHelperForm";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BuildingHelperForm_FormClosed);
			this.Shown += new System.EventHandler(this.BuildingHelperForm_Shown);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.TopPannel.ResumeLayout(false);
			this.TopPannel.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem OpenMapFolderMenuItem;
		private System.Windows.Forms.Panel TopPannel;
		private System.Windows.Forms.ComboBox DefaultStrategyComboBox;
		private System.Windows.Forms.Label DefaultStrategyLabel;
		private System.Windows.Forms.Button CreateFilesButton;
		private System.Windows.Forms.TextBox MapNameTextBox;
		private System.Windows.Forms.Label MapNameLabel;
		private System.Windows.Forms.TextBox CurrentDirrectoryTextBox;
		private System.Windows.Forms.Label CurrentDirrectoryLabel;
		private System.Windows.Forms.Panel BotPannel;
		private System.Windows.Forms.CheckBox CustomStrategiesCheckBox;
		private System.Windows.Forms.ComboBox PeaceTimeComboBox;
		private System.Windows.Forms.Label PeaceTimeLabel;
		private System.Windows.Forms.ToolStripMenuItem LanguageToolStrip;
		private System.Windows.Forms.ToolStripMenuItem HelpToolStrip;
		private System.Windows.Forms.ToolStripMenuItem ExitToolStrip;
	}
}

