using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tool__
{
	public class Lightmaps : Wrapper
	{
		private Tool__.FileReference scenario;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown bsp_index;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.NumericUpDown quality;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.NumericUpDown stop_threshold;
		private System.Windows.Forms.Button Run;

		public Lightmaps()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.scenario = new Tool__.FileReference();
			this.label1 = new System.Windows.Forms.Label();
			this.bsp_index = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.quality = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.stop_threshold = new System.Windows.Forms.NumericUpDown();
			this.Run = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.bsp_index)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.stop_threshold)).BeginInit();
			this.SuspendLayout();
			// 
			// scenario
			// 
			this.scenario.ControlName = "Scenario file";
			this.scenario.Field = "";
			this.scenario.FilterText = "Scenario tags|*.scenario";
			this.scenario.Info = "";
			this.scenario.InitialDir = "tags\\";
			this.scenario.Location = new System.Drawing.Point(0, 0);
			this.scenario.Name = "scenario";
			this.scenario.NoTagType = false;
			this.scenario.Size = new System.Drawing.Size(488, 24);
			this.scenario.TabIndex = 0;
			this.scenario.TagType = ".SCENARIO";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "BSP  Index";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// bsp_index
			// 
			this.bsp_index.Location = new System.Drawing.Point(144, 24);
			this.bsp_index.Maximum = new System.Decimal(new int[] {
																	  10,
																	  0,
																	  0,
																	  0});
			this.bsp_index.Name = "bsp_index";
			this.bsp_index.TabIndex = 3;
			this.ToolTips.SetToolTip(this.bsp_index, "All Multiple Player maps should be set to \'0\'. \nIf this is a SP map, and has mult" +
				"iple BSPs, then select which BSP you want to lightmap");
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "Quality";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// quality
			// 
			this.quality.DecimalPlaces = 6;
			this.quality.Increment = new System.Decimal(new int[] {
																	  1,
																	  0,
																	  0,
																	  65536});
			this.quality.Location = new System.Drawing.Point(144, 48);
			this.quality.Maximum = new System.Decimal(new int[] {
																	1,
																	0,
																	0,
																	0});
			this.quality.Name = "quality";
			this.quality.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "Stop Threshold";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// stop_threshold
			// 
			this.stop_threshold.DecimalPlaces = 6;
			this.stop_threshold.Increment = new System.Decimal(new int[] {
																			 1,
																			 0,
																			 0,
																			 65536});
			this.stop_threshold.Location = new System.Drawing.Point(144, 72);
			this.stop_threshold.Maximum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.stop_threshold.Name = "stop_threshold";
			this.stop_threshold.TabIndex = 7;
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(207, 96);
			this.Run.Name = "Run";
			this.Run.TabIndex = 8;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// Lightmaps
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.stop_threshold);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.quality);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.bsp_index);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.scenario);
			this.Name = "Lightmaps";
			this.Size = new System.Drawing.Size(496, 520);
			((System.ComponentModel.ISupportInitialize)(this.bsp_index)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.stop_threshold)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( scenario.Field == "")
				MessageBox.Show("#ERROR: Filename is 'NULL'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			else
			{
				this.ConsoleOutput.Text = "";
				this.Cursor = Cursors.AppStarting;

				processCaller = new ProcessCaller(this);
				processCaller.StdErrReceived += new DataReceivedHandler(Write);
				processCaller.StdOutReceived += new DataReceivedHandler(Write);
				processCaller.Completed += new EventHandler(ProcessCompletedOrCanceled);
				processCaller.Cancelled += new EventHandler(ProcessCompletedOrCanceled);
				processCaller.FileName = MainForm.HaloDir + "tool.exe";
				processCaller.WorkingDirectory = MainForm.HaloDir;
				processCaller.Arguments = string.Format("lightmaps {0} {1} {2} {3}", this.scenario.Field,
																							Convert.ToInt32(this.bsp_index.Value).ToString(),
																							Convert.ToSingle(this.quality.Value).ToString(),
																							Convert.ToSingle(this.stop_threshold.Value).ToString());
				processCaller.Start();
			}
		}
	}
}