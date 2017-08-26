using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Tool__
{
	public class MergeScenery : Wrapper
	{
		private System.Windows.Forms.Button Run;
		private Tool__.FileReference SourceScnr;
		private Tool__.FileReference DestinationScnr;

		public MergeScenery()
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
			this.Run = new System.Windows.Forms.Button();
			this.SourceScnr = new Tool__.FileReference();
			this.DestinationScnr = new Tool__.FileReference();
			this.SuspendLayout();
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(207, 48);
			this.Run.Name = "Run";
			this.Run.TabIndex = 0;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// SourceScnr
			// 
			this.SourceScnr.ControlName = "Source Scenario";
			this.SourceScnr.Field = "";
			this.SourceScnr.FilterText = "Scenario Tags|*.scenario";
			this.SourceScnr.Info = "";
			this.SourceScnr.InitialDir = "tags\\";
			this.SourceScnr.Location = new System.Drawing.Point(0, 0);
			this.SourceScnr.Name = "SourceScnr";
			this.SourceScnr.NoTagType = false;
			this.SourceScnr.Size = new System.Drawing.Size(488, 24);
			this.SourceScnr.TabIndex = 1;
			this.SourceScnr.TagType = ".SCENARIO";
			// 
			// DestinationScnr
			// 
			this.DestinationScnr.ControlName = "Destination Scenario";
			this.DestinationScnr.Field = "";
			this.DestinationScnr.FilterText = "Scenario Tags|*.scenario";
			this.DestinationScnr.Info = "";
			this.DestinationScnr.InitialDir = "tags\\";
			this.DestinationScnr.Location = new System.Drawing.Point(0, 24);
			this.DestinationScnr.Name = "DestinationScnr";
			this.DestinationScnr.NoTagType = false;
			this.DestinationScnr.Size = new System.Drawing.Size(488, 24);
			this.DestinationScnr.TabIndex = 2;
			this.DestinationScnr.TagType = ".SCENARIO";
			// 
			// MergeScenery
			// 
			this.Controls.Add(this.DestinationScnr);
			this.Controls.Add(this.SourceScnr);
			this.Controls.Add(this.Run);
			this.Name = "MergeScenery";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( SourceScnr.Field == "" || DestinationScnr.Field == "")
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
				processCaller.Arguments = string.Format("merge-scenery {0} {1}", this.SourceScnr.Field, DestinationScnr.Field);
				processCaller.Start();
			}
		}
	}
}