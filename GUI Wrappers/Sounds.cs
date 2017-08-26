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
	public class Sounds : Wrapper
	{
		private System.Windows.Forms.Button Run;
		private Tool__.FolderReference SourceDirectory;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox Platform;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox OOVF;
		private System.Windows.Forms.Label label3;

		public Sounds()
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
			this.label1 = new System.Windows.Forms.Label();
			this.Platform = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.OOVF = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 72);
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
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Platform";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Platform
			// 
			this.Platform.Items.AddRange(new object[] {
														  "xbox",
														  "wav",
														  "ogg"});
			this.Platform.Location = new System.Drawing.Point(144, 24);
			this.Platform.Name = "Platform";
			this.Platform.Size = new System.Drawing.Size(176, 21);
			this.Platform.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Ogg Only Value (Quality or Bitrate)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// OOVF
			// 
			this.OOVF.Location = new System.Drawing.Point(144, 48);
			this.OOVF.Name = "OOVF";
			this.OOVF.Size = new System.Drawing.Size(176, 20);
			this.OOVF.TabIndex = 7;
			this.OOVF.Text = "1";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(320, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(168, 48);
			this.label3.TabIndex = 8;
			this.label3.Text = "Quality setting range is -0.1 - 1.0 and bit rate range is 16kbps - 256kbps";
			// 
			// Sounds
			// 
			this.Controls.Add(this.label3);
			this.Controls.Add(this.OOVF);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Platform);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Run);
			this.Controls.Add(this.SourceDirectory);
			this.Name = "Sounds";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( SourceDirectory.Field == "")
			{
				MessageBox.Show("#ERROR: Directory is 'NULL'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if( OOVF.Text == "")
			{
				MessageBox.Show("#ERROR: Ogg Only Value Flag is 'NULL'",
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
			processCaller.Arguments = string.Format("sounds {0} {1} {2}", this.SourceDirectory.Field, Convert.ToString(this.Platform.SelectedItem), this.OOVF.Text);
			processCaller.Start();
		}
	}
}