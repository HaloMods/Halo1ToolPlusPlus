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
	/// <summary>
	/// Summary description for Structure.
	/// </summary>
	public class Structure : Wrapper
	{
		private Tool__.FolderReference ScenarioDirectory;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox BspName;
		private System.Windows.Forms.Button Run;

		public Structure()
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
			this.ScenarioDirectory = new Tool__.FolderReference();
			this.label1 = new System.Windows.Forms.Label();
			this.BspName = new System.Windows.Forms.TextBox();
			this.Run = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ScenarioDirectory
			// 
			this.ScenarioDirectory.ControlName = "Scenario Directory:";
			this.ScenarioDirectory.Field = "";
			this.ScenarioDirectory.Info = "";
			this.ScenarioDirectory.Location = new System.Drawing.Point(0, 0);
			this.ScenarioDirectory.Name = "ScenarioDirectory";
			this.ScenarioDirectory.Size = new System.Drawing.Size(488, 24);
			this.ScenarioDirectory.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bsp-Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// BspName
			// 
			this.BspName.Location = new System.Drawing.Point(144, 24);
			this.BspName.Name = "BspName";
			this.BspName.Size = new System.Drawing.Size(176, 20);
			this.BspName.TabIndex = 2;
			this.BspName.Text = "";
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 48);
			this.Run.Name = "Run";
			this.Run.TabIndex = 3;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// Structure
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.BspName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ScenarioDirectory);
			this.Name = "Structure";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( ScenarioDirectory.Field == "")
			{
				MessageBox.Show("#ERROR: Directory is 'NULL'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if( BspName.Text == "")
			{
				MessageBox.Show("#ERROR: Bsp-Name is 'NULL'",
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
			processCaller.Arguments = string.Format("structure {0} {1}", this.ScenarioDirectory.Field, this.BspName.Text);
			processCaller.Start();
		}

		private void field_TextChanged(object sender, EventArgs e)
		{
			this.BspName.Text = System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetFileName(this.ScenarioDirectory.Field));
		}
	}
}