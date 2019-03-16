using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

/*************************************************************************************************/
/*  Filer Renamer 2, copyright © 2010, 2011, 2012, 2019 Charles H Fisher Jr., South St. Paul, MN */
/*************************************************************************************************/
/*              his program is license under the GNU General Public License Version 3            */
/*                   all rights reserved; you may use this code in your own                      */
/*                   projects but a reference to my copyright is required                        */
/*************************************************************************************************/

namespace FileRenamer2
{
	public partial class frm_Main : Form
	{
		public string sCurrentDirectoryPath = "";
		Dictionary<string, string> LastDirListByDrive = new Dictionary<string, string>();
		Timer tTime;
		DiskChangeAlerter DAlerter;
		bool bDriveRescan = false;
		GettingDrivesNotice frmNotice = new GettingDrivesNotice();
		FileChangeWatcher FileWatcher;

		public frm_Main()
		{
			InitializeComponent();
		}

		void DAlerter_DiskChangeEvent(DriveChangedArgs e)
		{
			//MessageBox.Show(e.DriveLetter + ", " + e.InterfaceType + ", " + e.ChangeType);
			try
			{
				if (this.InvokeRequired)
				{
					// this is what we do if the event comes in from another thread
					MethodInvoker del = delegate { DAlerter_DiskChangeEvent(e); };
					this.Invoke(del);
					return;
				}
				else
				{
					// this is what we do as a result of the invoke() or if its
					// on the same thread as the handler
					frmNotice.Show();
					Application.DoEvents();
					bDriveRescan = true;
					cbDriveList.Text = "";
					cbDriveList.Items.Clear();
					tvFolderTree.Nodes.Clear();
					DataGridView1.Rows.Clear();
					GetDrives();
					bDriveRescan = false;
				}
			}
			catch (Exception de)
			{
				frmNotice.Hide();
				Application.DoEvents();
				MessageBox.Show("rescan error: " + de);
			}
			if (frmNotice != null)
			{
				frmNotice.Hide();
				Application.DoEvents();
			}
		}

		private void frm_Main_Shown(object sender, EventArgs e)
		{
			p.frmParent = this;
			x.frmParent = this;
			chkUSBdrives.Checked = Properties.Settings.Default.DisplayUSBdrives;
			frmNotice.Show(this);
			tTime = new Timer
			{
				Interval = 100
			};
			tTime.Tick += new EventHandler(tTime_Tick);
			tTime.Start();
		}

		void tTime_Tick(object sender, EventArgs e)
		{
			try
			{
				tTime.Stop();
				tTime.Tick -= new EventHandler(tTime_Tick);
				tTime.Dispose();
				tTime = null;
				DAlerter = new DiskChangeAlerter(); // must come before getdrives()
				GetDrives();
				frmNotice.Hide();
				if (chkUSBdrives.Checked)
					DAlerter.DiskChangeEvent += new EventChangedAlertHandler(DAlerter_DiskChangeEvent);
				FileWatcher = new FileChangeWatcher
				{
					FolderPath = sCurrentDirectoryPath
				};
				FileWatcher.eFileChanged += new FileChangedEventHandler(FileWatcher_eFileChanged);
				FileWatcher.Start();
			}
			catch (Exception te)
			{
				Debug.WriteLine("tTime_Tick(): " + te);
			}
		}

		void FileWatcher_eFileChanged(object sender, FileChangeEventArgs e)
		{
			//Debug.WriteLine("!!** File Change **!!");
			if (this.InvokeRequired)
			{
				MethodInvoker del = delegate { FileWatcher_eFileChanged(sender, e); };
				try
				{
					this.Invoke(del);
				}
				catch { };
				return;
			}
			else
				GetFiles();
		}

		public void GetFiles()
		{
			GetFiles(sCurrentDirectoryPath);
		}

		private void GetFiles(string sDirPath)
		{
			if (FileWatcher != null) FileWatcher.Stop();
			DataGridView1.Rows.Clear();
			string[] sFileNames;
			try
			{
				sFileNames = Directory.GetFiles(sDirPath);
			}
			catch
			{
				sFileNames = new string[] { };
			}
			if (sFileNames.Length == 0)
			{
				//DataGridView1.Rows.Add(1);
				//DataGridView1[0, 0].Value = false;
				return;
			}
			List<string> vettedfiles = new List<string>();
			for (int i = sFileNames.Length - 1; i >= 0; i--)
			{
				string sName = sFileNames[i];
				FileAttributes attr = File.GetAttributes(sFileNames[i]);
				if ((attr & (FileAttributes.Hidden | FileAttributes.System)) == 0)
					vettedfiles.Add(sFileNames[i]);
			}
			if (vettedfiles.Count < 1) return;
			DataGridView1.Rows.Add(vettedfiles.Count);
			for (int i = 0; i < vettedfiles.Count; i++)
			{
				DataGridView1[0, i].Value = false;
				string sName = vettedfiles[i];
				DataGridView1[1, i].Value = sName.Substring(sName.LastIndexOf('\\') + 1);
			}
			if (FileWatcher != null)
			{
				FileWatcher.FolderPath = sCurrentDirectoryPath;
				FileWatcher.Start();
			}
		}

		private void GetFolders(string sCurDir)
		{
			tvFolderTree.Nodes.Clear();
			if (sCurDir.Length <= 4)
			{
				tvFolderTree.Nodes.Add(" [ root ]");
			}
			else
			{
				tvFolderTree.Nodes.Add(".. (parent)");
				tvFolderTree.Nodes[0].Nodes.Add(sCurDir.Substring(sCurDir.LastIndexOf('\\') + 1));
				tvFolderTree.Nodes[0].Nodes[0].Tag = sCurDir;
			}
			tvFolderTree.Nodes[0].Tag = sCurDir.Substring(0, sCurDir.LastIndexOf('\\') + 1);
			// recursively call all child node directories
			string[] sFolders = Directory.GetDirectories(sCurDir);
			TreeNode CurrentNode = null;
			if (tvFolderTree.Nodes[0].GetNodeCount(false) > 0)
				CurrentNode = tvFolderTree.Nodes[0].Nodes[0];
			else
				CurrentNode = tvFolderTree.Nodes[0];
			foreach (string sFolder in sFolders)
			{
				TreeNode newNode = new TreeNode(sFolder.Substring(sFolder.LastIndexOf('\\') + 1))
				{
					Tag = sFolder
				};
				CurrentNode.Nodes.Add(newNode);
			}
			foreach (TreeNode tNode in CurrentNode.Nodes)
			{
				try
				{
					sFolders = new string[] { "" };
					if (!tNode.Tag.ToString().Contains("System Volume Information"))
						sFolders = Directory.GetDirectories(tNode.Tag.ToString());
					foreach (string sFolder in sFolders)
					{
						TreeNode newNode = new TreeNode(sFolder.Substring(sFolder.LastIndexOf('\\') + 1))
						{
							Tag = sFolder
						};
						tNode.Nodes.Add(newNode);
					}
				}
				catch (Exception e)
				{
					Debug.WriteLine("getfolders:L120 - " + e);
				}
			}
			tvFolderTree.Nodes[0].Expand();

		}

		private void DrillDownToCurrentDir(string sDirFullPath)
		{
			string[] splitArray;
			splitArray = sDirFullPath.Split('\\');
			TreeNode nCurrentNode = tvFolderTree.Nodes[0];
			for (int i = 1; i < splitArray.Length; i++)
			{
				foreach (TreeNode nNode in nCurrentNode.Nodes)
				{
					if (nNode.Text == splitArray[i])
					{
						nNode.Expand();
						//TreeViewEventArgs e = new TreeViewEventArgs(nNode);
						//tvFolderTree_AfterSelect(nNode, e);
						nCurrentNode = nNode;
					}
				}
			}
			tvFolderTree.SelectedNode = nCurrentNode;
		}

		private void cbDriveList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string oldDrive = sCurrentDirectoryPath.Substring(0, 2);
			if (LastDirListByDrive.ContainsKey(oldDrive) == false)
				LastDirListByDrive.Add(oldDrive, sCurrentDirectoryPath);

			string sNewDrive = cbDriveList.Text.Substring(0, 2);
			try
			{
				Directory.SetCurrentDirectory(sNewDrive + "\\");
			}
			catch
			{
				tvFolderTree.Nodes.Clear();
				DataGridView1.Rows.Clear();
				MessageBox.Show("Drive not ready: " + sNewDrive);
				//tvFolderTree.SelectedNode = tvFolderTree.Nodes[0];
				//cbDriveList.Text = oldDrive;
				return;
			}
			GetFolders(sNewDrive + "\\");
			GetFiles(sNewDrive + "\\");
			// if there's a dictionary entry, drill down to the last dir used
			if (LastDirListByDrive.ContainsKey(sNewDrive) == true)
			{
				sCurrentDirectoryPath = LastDirListByDrive[sNewDrive].ToString();
				if (sCurrentDirectoryPath == "") return;
				Directory.SetCurrentDirectory(sCurrentDirectoryPath);
				DrillDownToCurrentDir(sCurrentDirectoryPath);
			}
			else
				tvFolderTree.SelectedNode = tvFolderTree.Nodes[0];
		}

		private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex != 0) return;
			int iIndex = e.RowIndex + 1;
			if (iIndex == DataGridView1.Rows.Count)
				iIndex = 0;
			DataGridView1[0, iIndex].Selected = true;
		}

		private void tvFolderTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			sCurrentDirectoryPath = e.Node.Tag.ToString();
			string sDriveKey = sCurrentDirectoryPath.Substring(0, 2);
			if (LastDirListByDrive.ContainsKey(sDriveKey) == true)
				LastDirListByDrive[sDriveKey] = sCurrentDirectoryPath;
			else
				LastDirListByDrive.Add(sDriveKey, sCurrentDirectoryPath);
			GetFiles(e.Node.Tag.ToString());
		}

		private void tvFolderTree_AfterExpand(object sender, TreeViewEventArgs e)
		{
			foreach (TreeNode tNode in e.Node.Nodes)
			{
				// see if there are any child folders and display them
				try
				{
					string[] sFolders = new string[] { "" };
					if (!tNode.Tag.ToString().Contains("System Volume Information"))
						sFolders = Directory.GetDirectories(tNode.Tag.ToString());
					foreach (string sFolder in sFolders)
					{
						TreeNode newNode = new TreeNode(sFolder.Substring(sFolder.LastIndexOf('\\') + 1))
						{
							Tag = sFolder
						};
						tNode.Nodes.Add(newNode);
					}
				}
				catch (Exception e2)
				{
					Debug.WriteLine("tvFolderTree_AfterExpand:L211 - " + e2);
				}
			}
		}

		private void tvFolderTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (bDriveRescan) return;
			sCurrentDirectoryPath = e.Node.Tag.ToString();
			GetFiles(e.Node.Tag.ToString());
		}

		private void btnAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < DataGridView1.Rows.Count; i++)
			{
				DataGridView1[0, i].Value = true; // CheckState.Checked;
			}
		}

		private void btnNone_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < DataGridView1.Rows.Count; i++)
			{
				DataGridView1[0, i].Value = false; // CheckState.Unchecked;
			}
		}

		private void btnPreview_Click(object sender, EventArgs e)
		{
			if (rbPrefix.Checked == true)
				p.prefix();
			else if (rbSuffix.Checked == true)
				p.suffix();
			else if (rbInfix.Checked == true)
				p.infix();
			else if (rbReplace.Checked == true)
				p.replace();
			else if (rbNumBefore.Checked == true)
				p.numBefore();
			else if (rbNumAfter.Checked == true)
				p.numAfter();
			else if (rbNumInfix.Checked == true)
				p.numInfix();
		}

		private void btnExecute_Click(object sender, EventArgs e)
		{
			if (FileWatcher != null) FileWatcher.Stop();
			if (rbPrefix.Checked == true)
				x.prefix();
			else if (rbSuffix.Checked == true)
				x.suffix();
			else if (rbInfix.Checked == true)
				x.infix();
			else if (rbReplace.Checked == true)
				x.replace();
			else if (rbNumBefore.Checked == true)
				x.numbefore();
			else if (rbNumAfter.Checked == true)
				x.numafter();
			else if (rbNumInfix.Checked == true)
				x.numafter();
			if (FileWatcher != null) FileWatcher.Start();
			//GetFiles();
		}

		private void rbPrefix_CheckedChanged(object sender, EventArgs e)
		{
			lblTextType.Text = "Prefix Text";
			lblSearchText.Text = "(not used)";
			searchText.Enabled = false;
			replaceText.Enabled = true;
			startNumber.Enabled = false;
			stepNumber.Enabled = false;
			numberPrefix.Enabled = false;
			numberSuffix.Enabled = false;
		}

		private void rbSuffix_CheckedChanged(object sender, EventArgs e)
		{
			lblTextType.Text = "Suffix Text";
			lblSearchText.Text = "(not used)";
			searchText.Enabled = false;
			replaceText.Enabled = true;
			startNumber.Enabled = false;
			stepNumber.Enabled = false;
			numberPrefix.Enabled = false;
			numberSuffix.Enabled = false;
		}

		private void rbInfix_CheckedChanged(object sender, EventArgs e)
		{
			lblTextType.Text = "Infix Text";
			lblSearchText.Text = "Insert After ...";
			searchText.Enabled = true;
			replaceText.Enabled = true;
			startNumber.Enabled = false;
			stepNumber.Enabled = false;
			numberPrefix.Enabled = false;
			numberSuffix.Enabled = false;
		}

		private void rbReplace_CheckedChanged(object sender, EventArgs e)
		{
			lblTextType.Text = "Replacement Text";
			lblSearchText.Text = "Find This ...";
			searchText.Enabled = true;
			replaceText.Enabled = true;
			startNumber.Enabled = false;
			stepNumber.Enabled = false;
			numberPrefix.Enabled = false;
			numberSuffix.Enabled = false;
		}

		private void rbNumBefore_CheckedChanged(object sender, EventArgs e)
		{
			startNumber.Enabled = true;
			stepNumber.Enabled = true;
			numberPrefix.Enabled = true;
			numberSuffix.Enabled = true;
			searchText.Enabled = false;
			replaceText.Enabled = false;
		}

		private void rbNumInfix_CheckedChanged(object sender, EventArgs e)
		{
			lblSearchText.Text = "Insert After ...";
			startNumber.Enabled = true;
			stepNumber.Enabled = true;
			numberPrefix.Enabled = true;
			numberSuffix.Enabled = true;
			searchText.Enabled = true;
			replaceText.Enabled = false;
		}

		private void rbNumAfter_CheckedChanged(object sender, EventArgs e)
		{
			startNumber.Enabled = true;
			stepNumber.Enabled = true;
			numberPrefix.Enabled = true;
			numberSuffix.Enabled = true;
			searchText.Enabled = false;
			replaceText.Enabled = false;
		}

		private int GetDrives()
		{
			string sCurDriveText = "";
			try
			{
				string sCurDir = Directory.GetCurrentDirectory();
				if (!Directory.Exists(sCurDir))
				{
					Dictionary<string, string>.ValueCollection vals = LastDirListByDrive.Values;
					foreach (string sTest in vals)
					{
						if (Directory.Exists(sTest))
						{
							Directory.SetCurrentDirectory(sTest);
							sCurDir = sTest;
							break;
						}
					}
				}
				sCurrentDirectoryPath = sCurDir;
				string sCurDrive = sCurDir.Substring(0, 2);
				if (LastDirListByDrive.ContainsKey(sCurDrive) == false)
					LastDirListByDrive.Add(sCurDrive, sCurDir);
				sCurDriveText = sCurDrive;
				cbDriveList.Items.Clear();

				DriveInfo[] allDrives = DriveInfo.GetDrives();
				foreach (DriveInfo oInfo in allDrives)
				{
					if (oInfo.DriveType == DriveType.Fixed
							  || oInfo.DriveType == DriveType.Network
									|| oInfo.DriveType == DriveType.Removable)
					{
						if (oInfo.IsReady)
						{
							cbDriveList.Items.Add(oInfo.Name + " - " + oInfo.VolumeLabel);
							if (oInfo.Name.Contains(sCurDrive))
								sCurDriveText = oInfo.Name + " - " + oInfo.VolumeLabel;
						}
						else
						{
							cbDriveList.Items.Add(oInfo.Name + " - {not ready}");
						}
					}
				}
				cbDriveList.Text = sCurDriveText;
				GetFolders(sCurDir.Substring(0, 2) + "\\");
				DrillDownToCurrentDir(sCurDir);
				GetFiles(sCurDir);
			}
			catch (Exception ed)
			{
				Debug.WriteLine("getdrives(): " + ed);
			}
			return cbDriveList.Items.Count;
		}

		private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			DAlerter.IsExiting();
			Properties.Settings.Default.DisplayUSBdrives = chkUSBdrives.Checked;
			Properties.Settings.Default.Save();
		}

		private void btnRefreshList_Click(object sender, EventArgs e)
		{
			GetFiles();
		}

		private void chkUSBdrives_CheckedChanged(object sender, EventArgs e)
		{
			if (chkUSBdrives.Checked)
			{
				if (DAlerter == null)
					DAlerter = new DiskChangeAlerter();
				DAlerter.DiskChangeEvent += new EventChangedAlertHandler(DAlerter_DiskChangeEvent);
				DAlerter.GetUSBdrives();
				foreach (KeyValuePair<string, string> DicEntry in DAlerter.USBdic)
				{
					cbDriveList.Items.Add(DicEntry.Value + " - {USB}");
				}
			}
			else
			{
				if (DAlerter != null)
				{
					DAlerter.DiskChangeEvent -= new EventChangedAlertHandler(DAlerter_DiskChangeEvent);
				}
				foreach (KeyValuePair<string, string> DicEntry in DAlerter.USBdic)
				{
					int iloc = cbDriveList.Items.IndexOf(DicEntry.Value + " - {USB}");
					if (iloc >= 0)
						cbDriveList.Items.RemoveAt(iloc);
				} // if not null
			} // if checked
		} // chkUSBdrives_CheckedChanged

	} // end class
} // end namespace
