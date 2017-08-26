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
	public class StructureLensFlares : Wrapper
	{
		private System.Windows.Forms.Button Run;
		private System.Windows.Forms.TextBox BspName;
		private System.Windows.Forms.Label label1;

		public StructureLensFlares()
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
			this.BspName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 24);
			this.Run.Name = "Run";
			this.Run.TabIndex = 6;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// BspName
			// 
			this.BspName.Location = new System.Drawing.Point(144, 0);
			this.BspName.Name = "BspName";
			this.BspName.Size = new System.Drawing.Size(176, 20);
			this.BspName.TabIndex = 5;
			this.BspName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Bsp-Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StructureLensFlares
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.BspName);
			this.Controls.Add(this.label1);
			this.Name = "StructureLensFlares";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( BspName.Text == "")
				MessageBox.Show("#ERROR: Bsp-Name is 'NULL'",
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
				processCaller.Arguments = string.Format("structure-lens-flares {0}", this.BspName.Text);
				processCaller.Start();
			}
		}
	}
}