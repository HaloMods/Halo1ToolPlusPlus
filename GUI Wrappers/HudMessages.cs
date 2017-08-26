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
	public class HudMessages : Wrapper
	{
		private Tool__.FolderReference Path;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ScenarioName;
		private System.Windows.Forms.Button Run;

		public HudMessages()
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
			this.Path = new Tool__.FolderReference();
			this.label1 = new System.Windows.Forms.Label();
			this.ScenarioName = new System.Windows.Forms.TextBox();
			this.Run = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Path
			// 
			this.Path.ControlName = "Path:";
			this.Path.Field = "";
			this.Path.Info = "";
			this.Path.Location = new System.Drawing.Point(0, 0);
			this.Path.Name = "Path";
			this.Path.Size = new System.Drawing.Size(488, 24);
			this.Path.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Scenario-Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ScenarioName
			// 
			this.ScenarioName.Location = new System.Drawing.Point(144, 24);
			this.ScenarioName.Name = "ScenarioName";
			this.ScenarioName.Size = new System.Drawing.Size(176, 20);
			this.ScenarioName.TabIndex = 2;
			this.ScenarioName.Text = "";
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 48);
			this.Run.Name = "Run";
			this.Run.TabIndex = 3;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// HudMessages
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.ScenarioName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Path);
			this.Name = "HudMessages";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( ScenarioName.Text == "")
			{
				MessageBox.Show("#ERROR: ScenarioName is 'NULL'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if( Path.Field == "")
			{
				MessageBox.Show("#ERROR: Path is 'NULL'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			this.ConsoleOutput.Text = "";
			this.Cursor = Cursors.AppStarting;

			processCaller = new ProcessCaller(this);
			processCaller.StdErrReceived += new DataReceivedHandler(Write);
			processCaller.StdOutReceived += new DataReceivedHandler(Write);
			processCaller.Completed += new EventHandler(ProcessCompletedOrCanceled);
			processCaller.Cancelled += new EventHandler(ProcessCompletedOrCanceled);
			processCaller.FileName = MainForm.HaloDir + "tool.exe";
			processCaller.WorkingDirectory = MainForm.HaloDir;
			processCaller.Arguments = string.Format("hud-messages {0} {1}", this.ScenarioName.Text, this.Path.Field);
			processCaller.Start();
			
			Process.Start(MainForm.HaloDir + "tool.exe", string.Format("hud-messages {0} {1}", this.ScenarioName.Text, this.Path.Field));
		}
	}
}