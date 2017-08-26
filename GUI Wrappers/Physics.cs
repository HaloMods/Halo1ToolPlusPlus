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
	public class Physics : Wrapper
	{
		private System.Windows.Forms.Button Run;
		private Tool__.FileReference SourceFile;

		public Physics()
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
			this.SourceFile = new Tool__.FileReference();
			this.SuspendLayout();
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 24);
			this.Run.Name = "Run";
			this.Run.TabIndex = 4;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// SourceFile
			// 
			this.SourceFile.ControlName = "Source-File";
			this.SourceFile.Field = "";
			this.SourceFile.FilterText = "Physics Files|*.jms";
			this.SourceFile.Info = "";
			this.SourceFile.InitialDir = "data\\";
			this.SourceFile.Location = new System.Drawing.Point(0, 0);
			this.SourceFile.Name = "SourceFile";
			this.SourceFile.NoTagType = false;
			this.SourceFile.Size = new System.Drawing.Size(488, 24);
			this.SourceFile.TabIndex = 3;
			this.SourceFile.TagType = "JMS";
			// 
			// Physics
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.SourceFile);
			this.Name = "Physics";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( SourceFile.Field == "")
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
				processCaller.Arguments = string.Format("physics {0}", this.SourceFile.Field);
				processCaller.Start();
			}
		}
	}
}