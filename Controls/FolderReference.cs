using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace Tool__
{
	public class FolderReference : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Button browse;
		private System.Windows.Forms.ToolTip toolTip;
		public System.Windows.Forms.TextBox field;
		private System.Windows.Forms.Label name;
		public System.Windows.Forms.FolderBrowserDialog SelectFolder;
		private System.ComponentModel.IContainer components;

		#region Control Name
		public string ControlName
		{
			get { return this.name.Text; }
			set { this.name.Text = value; }
		}
		#endregion

		#region Field
		public string Field
		{
			get { return this.field.Text; }
			set { this.field.Text = value; }
		}
		#endregion

		#region Info
		private string info;
		public string Info
		{
			get { return this.info; }
			set 
			{ 
				this.info = value;
				this.SetTips(value); 
			}
		}

		public void SetTips(string tips)
		{
			toolTip.SetToolTip(this, tips);
			toolTip.SetToolTip(this.name, tips);
			toolTip.SetToolTip(this.field, tips);
		}
		#endregion

		public FolderReference()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			this.Field = "";
			this.Info = "" ;
			SelectFolder.SelectedPath = MainForm.HaloDir;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.browse = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.field = new System.Windows.Forms.TextBox();
			this.name = new System.Windows.Forms.Label();
			this.SelectFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// browse
			// 
			this.browse.Location = new System.Drawing.Point(328, 0);
			this.browse.Name = "browse";
			this.browse.Size = new System.Drawing.Size(24, 23);
			this.browse.TabIndex = 8;
			this.browse.Text = "...";
			this.browse.Click += new System.EventHandler(this.OnBrowse);
			// 
			// field
			// 
			this.field.Location = new System.Drawing.Point(144, 0);
			this.field.Name = "field";
			this.field.Size = new System.Drawing.Size(176, 20);
			this.field.TabIndex = 7;
			this.field.Text = "";
			// 
			// name
			// 
			this.name.Location = new System.Drawing.Point(0, 0);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(140, 24);
			this.name.TabIndex = 5;
			this.name.Text = "folder reference";
			this.name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// SelectFolder
			// 
			this.SelectFolder.Description = "Select a Folder";
			// 
			// FolderReference
			// 
			this.Controls.Add(this.field);
			this.Controls.Add(this.name);
			this.Controls.Add(this.browse);
			this.Name = "FolderReference";
			this.Size = new System.Drawing.Size(488, 24);
			this.ResumeLayout(false);

		}
		#endregion

		private void OnBrowse(object sender, System.EventArgs e)
		{
			if(SelectFolder.ShowDialog() == DialogResult.OK)
			{
				this.Field = SelectFolder.SelectedPath;
				this.Field = this.Field.Remove(0, MainForm.HaloDir.Length + 5);
			}
		}
	}
}