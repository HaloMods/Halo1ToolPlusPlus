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
	public class Bitmap : Wrapper
	{
		private System.Windows.Forms.Button Run;
		private Tool__.FileReference SourceFile;

		public Bitmap()
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
			this.SourceFile = new Tool__.FileReference();
			this.Run = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// SourceFile
			// 
			this.SourceFile.ControlName = "Source-File";
			this.SourceFile.Field = "";
			this.SourceFile.FilterText = "Tif Files|*.tif";
			this.SourceFile.Info = "";
			this.SourceFile.InitialDir = "data\\";
			this.SourceFile.Location = new System.Drawing.Point(0, 0);
			this.SourceFile.Name = "SourceFile";
			this.SourceFile.NoTagType = false;
			this.SourceFile.Size = new System.Drawing.Size(488, 24);
			this.SourceFile.TabIndex = 0;
			this.SourceFile.TagType = "TIF";
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 24);
			this.Run.Name = "Run";
			this.Run.TabIndex = 2;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// Bitmap
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.SourceFile);
			this.Name = "Bitmap";
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
				processCaller.Arguments = string.Format("bitmap {0}", this.SourceFile.Field);
				processCaller.Start();
			}
		}
	}
}