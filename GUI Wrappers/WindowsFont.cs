using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace Tool__
{
	public class WindowsFont : Wrapper
	{
		private System.Windows.Forms.Button Run;

		public WindowsFont()
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
			this.SuspendLayout();
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 1);
			this.Run.Name = "Run";
			this.Run.TabIndex = 2;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// WindowsFont
			// 
			this.Controls.Add(this.Run);
			this.Name = "WindowsFont";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
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
			processCaller.Arguments = "windows-font";
			processCaller.Start();
		}
	}
}