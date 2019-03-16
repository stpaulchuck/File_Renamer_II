namespace FileRenamer2
{
	partial class frm_Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (FileWatcher != null)
				{
					FileWatcher.Dispose();
				}
				if (DAlerter != null)
				{
					DAlerter.Dispose();
				}
				if (components != null)
				{
					components.Dispose();
				}
				base.Dispose(disposing);
			}
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Main));
			this.DataGridView1 = new System.Windows.Forms.DataGridView();
			this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnExecute = new System.Windows.Forms.Button();
			this.btnPreview = new System.Windows.Forms.Button();
			this.Label6 = new System.Windows.Forms.Label();
			this.numberSuffix = new System.Windows.Forms.TextBox();
			this.Label5 = new System.Windows.Forms.Label();
			this.numberPrefix = new System.Windows.Forms.TextBox();
			this.Label4 = new System.Windows.Forms.Label();
			this.stepNumber = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.startNumber = new System.Windows.Forms.TextBox();
			this.rbNumAfter = new System.Windows.Forms.RadioButton();
			this.rbNumInfix = new System.Windows.Forms.RadioButton();
			this.rbNumBefore = new System.Windows.Forms.RadioButton();
			this.lblTextType = new System.Windows.Forms.Label();
			this.lblSearchText = new System.Windows.Forms.Label();
			this.replaceText = new System.Windows.Forms.TextBox();
			this.searchText = new System.Windows.Forms.TextBox();
			this.rbReplace = new System.Windows.Forms.RadioButton();
			this.rbInfix = new System.Windows.Forms.RadioButton();
			this.rbSuffix = new System.Windows.Forms.RadioButton();
			this.rbPrefix = new System.Windows.Forms.RadioButton();
			this.btnNone = new System.Windows.Forms.Button();
			this.btnAll = new System.Windows.Forms.Button();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.cbDriveList = new System.Windows.Forms.ComboBox();
			this.tvFolderTree = new System.Windows.Forms.TreeView();
			this.btnRefreshList = new System.Windows.Forms.Button();
			this.chkUSBdrives = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// DataGridView1
			// 
			this.DataGridView1.AllowUserToAddRows = false;
			this.DataGridView1.AllowUserToDeleteRows = false;
			this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.DataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
				this.Column1,
				this.Column2,
				this.Column3});
			this.DataGridView1.Location = new System.Drawing.Point(280, 34);
			this.DataGridView1.MultiSelect = false;
			this.DataGridView1.Name = "DataGridView1";
			this.DataGridView1.RowHeadersVisible = false;
			this.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.DataGridView1.Size = new System.Drawing.Size(560, 320);
			this.DataGridView1.TabIndex = 54;
			this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView1_CellContentClick);
			// 
			// Column1
			// 
			this.Column1.HeaderText = "Sel.";
			this.Column1.Name = "Column1";
			this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			this.Column1.Width = 37;
			// 
			// Column2
			// 
			this.Column2.HeaderText = "Current Name";
			this.Column2.Name = "Column2";
			this.Column2.Width = 260;
			// 
			// Column3
			// 
			this.Column3.HeaderText = "New Name";
			this.Column3.Name = "Column3";
			this.Column3.Width = 260;
			// 
			// btnExecute
			// 
			this.btnExecute.Location = new System.Drawing.Point(611, 362);
			this.btnExecute.Name = "btnExecute";
			this.btnExecute.Size = new System.Drawing.Size(80, 24);
			this.btnExecute.TabIndex = 53;
			this.btnExecute.Text = "Execute";
			this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
			// 
			// btnPreview
			// 
			this.btnPreview.Location = new System.Drawing.Point(507, 362);
			this.btnPreview.Name = "btnPreview";
			this.btnPreview.Size = new System.Drawing.Size(80, 24);
			this.btnPreview.TabIndex = 52;
			this.btnPreview.Text = "Preview";
			this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
			// 
			// Label6
			// 
			this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label6.Location = new System.Drawing.Point(708, 474);
			this.Label6.Name = "Label6";
			this.Label6.Size = new System.Drawing.Size(48, 16);
			this.Label6.TabIndex = 51;
			this.Label6.Text = "Suffix";
			this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// numberSuffix
			// 
			this.numberSuffix.Enabled = false;
			this.numberSuffix.Location = new System.Drawing.Point(708, 498);
			this.numberSuffix.Name = "numberSuffix";
			this.numberSuffix.Size = new System.Drawing.Size(48, 20);
			this.numberSuffix.TabIndex = 50;
			this.numberSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Label5
			// 
			this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label5.Location = new System.Drawing.Point(604, 474);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(72, 16);
			this.Label5.TabIndex = 49;
			this.Label5.Text = "Prefix";
			this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// numberPrefix
			// 
			this.numberPrefix.Enabled = false;
			this.numberPrefix.Location = new System.Drawing.Point(620, 498);
			this.numberPrefix.Name = "numberPrefix";
			this.numberPrefix.Size = new System.Drawing.Size(48, 20);
			this.numberPrefix.TabIndex = 48;
			this.numberPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Label4
			// 
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label4.Location = new System.Drawing.Point(604, 442);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(72, 16);
			this.Label4.TabIndex = 47;
			this.Label4.Text = "Step";
			this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// stepNumber
			// 
			this.stepNumber.Enabled = false;
			this.stepNumber.Location = new System.Drawing.Point(684, 442);
			this.stepNumber.Name = "stepNumber";
			this.stepNumber.Size = new System.Drawing.Size(48, 20);
			this.stepNumber.TabIndex = 46;
			this.stepNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Label3
			// 
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label3.Location = new System.Drawing.Point(604, 410);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(72, 16);
			this.Label3.TabIndex = 45;
			this.Label3.Text = "Start";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// startNumber
			// 
			this.startNumber.Enabled = false;
			this.startNumber.Location = new System.Drawing.Point(684, 410);
			this.startNumber.Name = "startNumber";
			this.startNumber.Size = new System.Drawing.Size(48, 20);
			this.startNumber.TabIndex = 44;
			this.startNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// rbNumAfter
			// 
			this.rbNumAfter.Location = new System.Drawing.Point(460, 482);
			this.rbNumAfter.Name = "rbNumAfter";
			this.rbNumAfter.Size = new System.Drawing.Size(96, 16);
			this.rbNumAfter.TabIndex = 43;
			this.rbNumAfter.Text = "Number After";
			this.rbNumAfter.CheckedChanged += new System.EventHandler(this.rbNumAfter_CheckedChanged);
			// 
			// rbNumInfix
			// 
			this.rbNumInfix.Location = new System.Drawing.Point(460, 450);
			this.rbNumInfix.Name = "rbNumInfix";
			this.rbNumInfix.Size = new System.Drawing.Size(96, 16);
			this.rbNumInfix.TabIndex = 42;
			this.rbNumInfix.Text = "Number Infix";
			this.rbNumInfix.CheckedChanged += new System.EventHandler(this.rbNumInfix_CheckedChanged);
			// 
			// rbNumBefore
			// 
			this.rbNumBefore.Location = new System.Drawing.Point(460, 418);
			this.rbNumBefore.Name = "rbNumBefore";
			this.rbNumBefore.Size = new System.Drawing.Size(104, 16);
			this.rbNumBefore.TabIndex = 41;
			this.rbNumBefore.Text = "Number Before";
			this.rbNumBefore.CheckedChanged += new System.EventHandler(this.rbNumBefore_CheckedChanged);
			// 
			// lblTextType
			// 
			this.lblTextType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTextType.Location = new System.Drawing.Point(180, 450);
			this.lblTextType.Name = "lblTextType";
			this.lblTextType.Size = new System.Drawing.Size(152, 16);
			this.lblTextType.TabIndex = 40;
			this.lblTextType.Text = "Prefix Text ...";
			this.lblTextType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblSearchText
			// 
			this.lblSearchText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblSearchText.Location = new System.Drawing.Point(180, 394);
			this.lblSearchText.Name = "lblSearchText";
			this.lblSearchText.Size = new System.Drawing.Size(152, 16);
			this.lblSearchText.TabIndex = 39;
			this.lblSearchText.Text = "(not used)";
			this.lblSearchText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// replaceText
			// 
			this.replaceText.Location = new System.Drawing.Point(164, 474);
			this.replaceText.Name = "replaceText";
			this.replaceText.Size = new System.Drawing.Size(184, 20);
			this.replaceText.TabIndex = 38;
			this.replaceText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// searchText
			// 
			this.searchText.Enabled = false;
			this.searchText.Location = new System.Drawing.Point(164, 418);
			this.searchText.Name = "searchText";
			this.searchText.Size = new System.Drawing.Size(184, 20);
			this.searchText.TabIndex = 37;
			this.searchText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// rbReplace
			// 
			this.rbReplace.Location = new System.Drawing.Point(44, 482);
			this.rbReplace.Name = "rbReplace";
			this.rbReplace.Size = new System.Drawing.Size(76, 16);
			this.rbReplace.TabIndex = 36;
			this.rbReplace.Text = "Replace";
			this.rbReplace.CheckedChanged += new System.EventHandler(this.rbReplace_CheckedChanged);
			// 
			// rbInfix
			// 
			this.rbInfix.Location = new System.Drawing.Point(44, 458);
			this.rbInfix.Name = "rbInfix";
			this.rbInfix.Size = new System.Drawing.Size(64, 16);
			this.rbInfix.TabIndex = 35;
			this.rbInfix.Text = "Infix";
			this.rbInfix.CheckedChanged += new System.EventHandler(this.rbInfix_CheckedChanged);
			// 
			// rbSuffix
			// 
			this.rbSuffix.Location = new System.Drawing.Point(44, 434);
			this.rbSuffix.Name = "rbSuffix";
			this.rbSuffix.Size = new System.Drawing.Size(64, 16);
			this.rbSuffix.TabIndex = 34;
			this.rbSuffix.Text = "Suffix";
			this.rbSuffix.CheckedChanged += new System.EventHandler(this.rbSuffix_CheckedChanged);
			// 
			// rbPrefix
			// 
			this.rbPrefix.Checked = true;
			this.rbPrefix.Location = new System.Drawing.Point(44, 410);
			this.rbPrefix.Name = "rbPrefix";
			this.rbPrefix.Size = new System.Drawing.Size(64, 16);
			this.rbPrefix.TabIndex = 33;
			this.rbPrefix.TabStop = true;
			this.rbPrefix.Text = "Prefix";
			this.rbPrefix.CheckedChanged += new System.EventHandler(this.rbPrefix_CheckedChanged);
			// 
			// btnNone
			// 
			this.btnNone.Location = new System.Drawing.Point(403, 362);
			this.btnNone.Name = "btnNone";
			this.btnNone.Size = new System.Drawing.Size(80, 24);
			this.btnNone.TabIndex = 32;
			this.btnNone.Text = "Select None";
			this.btnNone.Click += new System.EventHandler(this.btnNone_Click);
			// 
			// btnAll
			// 
			this.btnAll.Location = new System.Drawing.Point(299, 362);
			this.btnAll.Name = "btnAll";
			this.btnAll.Size = new System.Drawing.Size(80, 24);
			this.btnAll.TabIndex = 31;
			this.btnAll.Text = "Select All";
			this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
			// 
			// Label2
			// 
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label2.Location = new System.Drawing.Point(508, 10);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(72, 16);
			this.Label2.TabIndex = 30;
			this.Label2.Text = "Files";
			// 
			// Label1
			// 
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Label1.Location = new System.Drawing.Point(84, 50);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(91, 16);
			this.Label1.TabIndex = 29;
			this.Label1.Text = "Directories";
			// 
			// cbDriveList
			// 
			this.cbDriveList.FormattingEnabled = true;
			this.cbDriveList.Location = new System.Drawing.Point(12, 12);
			this.cbDriveList.Name = "cbDriveList";
			this.cbDriveList.Size = new System.Drawing.Size(247, 21);
			this.cbDriveList.TabIndex = 55;
			this.cbDriveList.SelectedIndexChanged += new System.EventHandler(this.cbDriveList_SelectedIndexChanged);
			// 
			// tvFolderTree
			// 
			this.tvFolderTree.HideSelection = false;
			this.tvFolderTree.Location = new System.Drawing.Point(12, 76);
			this.tvFolderTree.Name = "tvFolderTree";
			this.tvFolderTree.Size = new System.Drawing.Size(247, 278);
			this.tvFolderTree.TabIndex = 56;
			this.tvFolderTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolderTree_AfterSelect);
			this.tvFolderTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolderTree_NodeMouseClick);
			this.tvFolderTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvFolderTree_AfterExpand);
			// 
			// btnRefreshList
			// 
			this.btnRefreshList.Location = new System.Drawing.Point(710, 362);
			this.btnRefreshList.Name = "btnRefreshList";
			this.btnRefreshList.Size = new System.Drawing.Size(110, 24);
			this.btnRefreshList.TabIndex = 57;
			this.btnRefreshList.Text = "Refresh File List";
			this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
			// 
			// chkUSBdrives
			// 
			this.chkUSBdrives.AutoSize = true;
			this.chkUSBdrives.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkUSBdrives.Checked = true;
			this.chkUSBdrives.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUSBdrives.Location = new System.Drawing.Point(68, 367);
			this.chkUSBdrives.Name = "chkUSBdrives";
			this.chkUSBdrives.Size = new System.Drawing.Size(118, 17);
			this.chkUSBdrives.TabIndex = 58;
			this.chkUSBdrives.Text = "Display USB Drives";
			this.chkUSBdrives.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.chkUSBdrives.UseVisualStyleBackColor = true;
			this.chkUSBdrives.CheckedChanged += new System.EventHandler(this.chkUSBdrives_CheckedChanged);
			// 
			// frm_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 533);
			this.Controls.Add(this.chkUSBdrives);
			this.Controls.Add(this.btnRefreshList);
			this.Controls.Add(this.tvFolderTree);
			this.Controls.Add(this.cbDriveList);
			this.Controls.Add(this.DataGridView1);
			this.Controls.Add(this.btnExecute);
			this.Controls.Add(this.btnPreview);
			this.Controls.Add(this.Label6);
			this.Controls.Add(this.numberSuffix);
			this.Controls.Add(this.Label5);
			this.Controls.Add(this.numberPrefix);
			this.Controls.Add(this.Label4);
			this.Controls.Add(this.stepNumber);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.startNumber);
			this.Controls.Add(this.rbNumAfter);
			this.Controls.Add(this.rbNumInfix);
			this.Controls.Add(this.rbNumBefore);
			this.Controls.Add(this.lblTextType);
			this.Controls.Add(this.lblSearchText);
			this.Controls.Add(this.replaceText);
			this.Controls.Add(this.searchText);
			this.Controls.Add(this.rbReplace);
			this.Controls.Add(this.rbInfix);
			this.Controls.Add(this.rbSuffix);
			this.Controls.Add(this.rbPrefix);
			this.Controls.Add(this.btnNone);
			this.Controls.Add(this.btnAll);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frm_Main";
			this.Text = "File Renamer II";
			this.Shown += new System.EventHandler(this.frm_Main_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_Main_FormClosing);
			((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		internal System.Windows.Forms.DataGridView DataGridView1;
		internal System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
		internal System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		internal System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		internal System.Windows.Forms.Button btnExecute;
		internal System.Windows.Forms.Button btnPreview;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox numberSuffix;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox numberPrefix;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.TextBox stepNumber;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox startNumber;
		internal System.Windows.Forms.RadioButton rbNumAfter;
		internal System.Windows.Forms.RadioButton rbNumInfix;
		internal System.Windows.Forms.RadioButton rbNumBefore;
		internal System.Windows.Forms.Label lblTextType;
		internal System.Windows.Forms.Label lblSearchText;
		internal System.Windows.Forms.TextBox replaceText;
		internal System.Windows.Forms.TextBox searchText;
		internal System.Windows.Forms.RadioButton rbReplace;
		internal System.Windows.Forms.RadioButton rbInfix;
		internal System.Windows.Forms.RadioButton rbSuffix;
		internal System.Windows.Forms.RadioButton rbPrefix;
		internal System.Windows.Forms.Button btnNone;
		internal System.Windows.Forms.Button btnAll;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		private System.Windows.Forms.ComboBox cbDriveList;
		private System.Windows.Forms.TreeView tvFolderTree;
		internal System.Windows.Forms.Button btnRefreshList;
		private System.Windows.Forms.CheckBox chkUSBdrives;
	}
}

