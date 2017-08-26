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
	public class BuildCacheFile : Tool__.Wrapper
	{
		private System.Windows.Forms.Button Run;
		private Tool__.FileReference ScenarioName;

		public BuildCacheFile()
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
			this.ScenarioName = new Tool__.FileReference();
			this.Run = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ScenarioName
			// 
			this.ScenarioName.ControlName = "Scenario-Name";
			this.ScenarioName.Field = "";
			this.ScenarioName.FilterText = "Scenario Tags|*.scenario";
			this.ScenarioName.Info = "";
			this.ScenarioName.InitialDir = "tags\\";
			this.ScenarioName.Location = new System.Drawing.Point(0, 0);
			this.ScenarioName.Name = "ScenarioName";
			this.ScenarioName.NoTagType = false;
			this.ScenarioName.Size = new System.Drawing.Size(488, 24);
			this.ScenarioName.TabIndex = 0;
			this.ScenarioName.TagType = ".SCENARIO";
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(207, 24);
			this.Run.Name = "Run";
			this.Run.TabIndex = 2;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// BuildCacheFile
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.ScenarioName);
			this.Name = "BuildCacheFile";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( ScenarioName.Field == "")
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
				processCaller.Arguments = string.Format("build-cache-file {0}", this.ScenarioName.Field);

				processCaller.Start();
			}
		}
	}
}