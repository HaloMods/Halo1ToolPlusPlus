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
	public class ProcessSounds : Wrapper
	{
		private Tool__.FolderReference RootPath;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox SubString;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Value;
		private System.Windows.Forms.ComboBox Modifier;
		private System.Windows.Forms.Button Run;

		public ProcessSounds()
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
			this.RootPath = new Tool__.FolderReference();
			this.label1 = new System.Windows.Forms.Label();
			this.SubString = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.Value = new System.Windows.Forms.TextBox();
			this.Modifier = new System.Windows.Forms.ComboBox();
			this.Run = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// RootPath
			// 
			this.RootPath.ControlName = "Root Path";
			this.RootPath.Field = "";
			this.RootPath.Info = "";
			this.RootPath.Location = new System.Drawing.Point(0, 0);
			this.RootPath.Name = "RootPath";
			this.RootPath.Size = new System.Drawing.Size(488, 24);
			this.RootPath.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Search String";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SubString
			// 
			this.SubString.Location = new System.Drawing.Point(144, 24);
			this.SubString.Name = "SubString";
			this.SubString.Size = new System.Drawing.Size(176, 20);
			this.SubString.TabIndex = 2;
			this.SubString.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(0, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Modifier";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(0, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(144, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Modifier Value";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Value
			// 
			this.Value.Location = new System.Drawing.Point(144, 72);
			this.Value.Name = "Value";
			this.Value.Size = new System.Drawing.Size(176, 20);
			this.Value.TabIndex = 5;
			this.Value.Text = "";
			// 
			// Modifier
			// 
			this.Modifier.Items.AddRange(new object[] {
														  "gain+",
														  "gain-",
														  "gain=",
														  "maximum-distance",
														  "minimum-distance"});
			this.Modifier.Location = new System.Drawing.Point(144, 48);
			this.Modifier.Name = "Modifier";
			this.Modifier.Size = new System.Drawing.Size(176, 21);
			this.Modifier.TabIndex = 6;
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 96);
			this.Run.Name = "Run";
			this.Run.TabIndex = 7;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// ProcessSounds
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.Modifier);
			this.Controls.Add(this.Value);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.SubString);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.RootPath);
			this.Name = "ProcessSounds";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			if( RootPath.Field == "")
			{
				MessageBox.Show("#ERROR: Root Path is 'NULL'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if(SubString.Text == "")
			{
				MessageBox.Show("#ERROR: Seach String is 'NULL'",
					"Whoops",
					MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				return;
			}

			if(Value.Text == "")
			{
				MessageBox.Show("#ERROR: Modifier Value is 'NULL'",
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
			processCaller.Arguments = string.Format("process-sounds {0} {1} {2} {3}", RootPath.Field, SubString.Text, Convert.ToString(Modifier.SelectedItem), Convert.ToSingle(Value.Text));
			processCaller.Start();
		}
	}
}