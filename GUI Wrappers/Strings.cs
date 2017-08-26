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
	public class Strings : Wrapper
	{
		private System.Windows.Forms.Button Run;
		private Tool__.FolderReference SourceDirectory;

		public Strings()
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
			this.SourceDirectory = new Tool__.FolderReference();
			this.SuspendLayout();
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 24);
			this.Run.Name = "Run";
			this.Run.TabIndex = 3;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// SourceDirectory
			// 
			this.SourceDirectory.ControlName = "Source-Directory";
			this.SourceDirectory.Field = "";
			this.SourceDirectory.Info = "Model Source Directory";
			this.SourceDirectory.Location = new System.Drawing.Point(0, 0);
			this.SourceDirectory.Name = "SourceDirectory";
			this.SourceDirectory.Size = new System.Drawing.Size(488, 24);
			this.SourceDirectory.TabIndex = 2;
			// 
			// Strings
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.SourceDirectory);
			this.Name = "Strings";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( SourceDirectory.Field == "")
				MessageBox.Show("#ERROR: Directory is 'NULL'",
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
				processCaller.Arguments = string.Format("strings {0}", this.SourceDirectory.Field);
				processCaller.Start();
			}
		}
	}
}