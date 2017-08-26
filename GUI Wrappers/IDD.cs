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
	/// Summary description for IDD.
	/// </summary>
	public class IDD : Wrapper
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox Type;
		private Tool__.FolderReference Savegame_path;
		private System.Windows.Forms.Button Run;

		public IDD()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.Savegame_path.SelectFolder.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\My Games\\Halo CE\\";
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.Type = new System.Windows.Forms.ComboBox();
			this.Savegame_path = new Tool__.FolderReference();
			this.Run = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Type:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Type
			// 
			this.Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.Type.Items.AddRange(new object[] {
													  "defaults",
													  "profiles"});
			this.Type.Location = new System.Drawing.Point(144, 0);
			this.Type.Name = "Type";
			this.Type.Size = new System.Drawing.Size(121, 21);
			this.Type.TabIndex = 1;
			// 
			// Savegame_path
			// 
			this.Savegame_path.ControlName = "Savegame path:";
			this.Savegame_path.Field = "";
			this.Savegame_path.Info = "";
			this.Savegame_path.Location = new System.Drawing.Point(0, 24);
			this.Savegame_path.Name = "Savegame_path";
			this.Savegame_path.Size = new System.Drawing.Size(488, 24);
			this.Savegame_path.TabIndex = 2;
			// 
			// Run
			// 
			this.Run.Location = new System.Drawing.Point(208, 48);
			this.Run.Name = "Run";
			this.Run.TabIndex = 3;
			this.Run.Text = "Run Tool";
			this.Run.Click += new System.EventHandler(this.OnRun);
			// 
			// IDD
			// 
			this.Controls.Add(this.Run);
			this.Controls.Add(this.Savegame_path);
			this.Controls.Add(this.Type);
			this.Controls.Add(this.label1);
			this.Name = "IDD";
			this.Size = new System.Drawing.Size(496, 520);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnRun(object sender, System.EventArgs e)
		{
			string savegame_path = this.Savegame_path.Field.Remove(0, (Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\My Games\\Halo CE\\").Length);

			if( this.Savegame_path.Field == "")
				MessageBox.Show("#ERROR: Savegame path is 'NULL'",
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
				processCaller.Arguments = string.Format("import-device-defaults {0} {1}", Convert.ToSingle(this.Type.SelectedItem), savegame_path);
				processCaller.Start();
			}
		}
	}
}