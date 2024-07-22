
namespace BuildingHelperFilesCreator
{
	partial class MapLocation
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.LocationLabel = new System.Windows.Forms.Label();
			this.LocationValueLabel = new System.Windows.Forms.Label();
			this.StrategyComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// LocationLabel
			// 
			this.LocationLabel.AutoSize = true;
			this.LocationLabel.Location = new System.Drawing.Point(28, 4);
			this.LocationLabel.Name = "LocationLabel";
			this.LocationLabel.Size = new System.Drawing.Size(48, 13);
			this.LocationLabel.TabIndex = 0;
			this.LocationLabel.Text = "Location";
			// 
			// LocationValueLabel
			// 
			this.LocationValueLabel.AutoSize = true;
			this.LocationValueLabel.Location = new System.Drawing.Point(78, 4);
			this.LocationValueLabel.Name = "LocationValueLabel";
			this.LocationValueLabel.Size = new System.Drawing.Size(48, 13);
			this.LocationValueLabel.TabIndex = 1;
			this.LocationValueLabel.Text = "Location";
			// 
			// StrategyComboBox
			// 
			this.StrategyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.StrategyComboBox.FormattingEnabled = true;
			this.StrategyComboBox.Location = new System.Drawing.Point(3, 20);
			this.StrategyComboBox.Name = "StrategyComboBox";
			this.StrategyComboBox.Size = new System.Drawing.Size(121, 21);
			this.StrategyComboBox.TabIndex = 2;
			// 
			// MapLocation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.StrategyComboBox);
			this.Controls.Add(this.LocationValueLabel);
			this.Controls.Add(this.LocationLabel);
			this.Name = "MapLocation";
			this.Size = new System.Drawing.Size(128, 47);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label LocationLabel;
		private System.Windows.Forms.Label LocationValueLabel;
		private System.Windows.Forms.ComboBox StrategyComboBox;
	}
}
