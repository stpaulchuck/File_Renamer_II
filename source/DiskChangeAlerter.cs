using System;
using System.Management;
using System.Collections.Generic;
using System.Diagnostics;

namespace FileRenamer2
{
	public enum DriveChangeType { Create, Remove, MediaChange, Other };

	public class DriveChangedArgs
	{
		public string DriveLetter = "";
		public string InterfaceType = "";
		public DriveChangeType ChangeType = DriveChangeType.Other;
	}
	public delegate void EventChangedAlertHandler(DriveChangedArgs e);


	public class DiskChangeAlerter:IDisposable
	{
		ManagementEventWatcher Watcher = new ManagementEventWatcher();
		public event EventChangedAlertHandler DiskChangeEvent;

		private Dictionary<string, string> m_USBdic = new Dictionary<string, string>();
		public Dictionary<string, string> USBdic => m_USBdic;

		public void IsExiting()
		{
			Watcher.Stop();
			Watcher.Dispose();
			Watcher = null;
		}

		public DiskChangeAlerter()
		{
			WqlEventQuery q1 = new WqlEventQuery("SELECT * FROM __InstanceOperationEvent WITHIN 1 "
				 + "WHERE TargetInstance ISA 'Win32_DiskDrive' Or TargetInstance isa 'Win32_MappedLogicalDisk'");
			Watcher.Query = q1;
			Watcher.EventArrived += new EventArrivedEventHandler(Watcher_EventArrived);
			Watcher.Start();
		}

		private void Watcher_EventArrived(object sender, EventArrivedEventArgs e)
		{
			ManagementBaseObject mbo, obj;
			mbo = (ManagementBaseObject)e.NewEvent;
			obj = (ManagementBaseObject)mbo["TargetInstance"];
			DriveChangedArgs a1 = new DriveChangedArgs
			{
				DriveLetter = obj["Name"].ToString()
			};
			if (obj.ClassPath.ToString().ToLower().Contains("mapped"))
				a1.InterfaceType = "MappedDrive";
			if (obj.ClassPath.ToString().Contains("Win32_DiskDrive"))
			{
				try
				{
					a1.InterfaceType = obj["InterfaceType"].ToString();
				}
				catch
				{
					a1.InterfaceType = "unknown";
				}
				try
				{
					a1.DriveLetter = GetDriveLetterFromDisk(obj["Name"].ToString());
					if (!USBdic.ContainsKey(obj["Name"].ToString()))
					{ USBdic.Add(obj["Name"].ToString(), a1.DriveLetter); }
				}
				catch
				{
					if (USBdic.ContainsKey(obj["Name"].ToString()))
					{
						a1.DriveLetter = USBdic[obj["Name"].ToString()];
						USBdic.Remove(obj["Name"].ToString());
					}
					else
						a1.DriveLetter = "unknown";
				}
			}
			switch (mbo.ClassPath.ClassName)
			{
				case "__InstanceCreationEvent":
					a1.ChangeType = DriveChangeType.Create;
					break;
				case "__InstanceDeletionEvent":
					a1.ChangeType = DriveChangeType.Remove;
					break;
				case "__InstanceModificationEvent":
					a1.ChangeType = DriveChangeType.MediaChange;
					break;
				default:
					a1.ChangeType = DriveChangeType.Other;
					break;
			}
			try
			{
				DiskChangeEvent?.Invoke(a1);
			}
			catch (Exception ex)
			{
				Debug.WriteLine("Watchereventarrived(): " + ex);
			}
		}


		private string GetDriveLetterFromDisk(string Name)
		{
			ObjectQuery oq_part, oq_disk;
			ManagementObjectSearcher mos_part, mos_disk;
			string ans = "";

			// WMI queries use the "\" as an escape charcter
			//    Name = Name.Replace(@"\", @"\\");

			//' First we map the Win32_DiskDrive instance with the association called
			//' Win32_DiskDriveToDiskPartition. Then we map the Win32_DiskPartion
			//' instance with the assocation called Win32_LogicalDiskToPartition

			oq_part = new ObjectQuery("ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + Name + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition");
			mos_part = new ManagementObjectSearcher(oq_part);
			foreach (ManagementObject obj_part in mos_part.Get())
			{
				oq_disk = new ObjectQuery("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + obj_part["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition");
				mos_disk = new ManagementObjectSearcher(oq_disk);
				foreach (ManagementObject obj_disk in mos_disk.Get())
				{
					ans += obj_disk["Name"] + ",";
				}
			}
			return ans = ans.Substring(0, ans.Length - 1);
		}

		public void GetUSBdrives()
		{
			WqlObjectQuery qDrives = new WqlObjectQuery("select * from Win32_DiskDrive where InterfaceType='USB'");
			ManagementObjectSearcher oSearch = new ManagementObjectSearcher(qDrives);
			ManagementObjectCollection cDrives = oSearch.Get();
			foreach (ManagementObject obj in cDrives)
			{
				Debug.WriteLine("drive win32 name" + obj["Name"]);
				// associate physical disks with partitions
				ManagementObjectSearcher partsearch = new ManagementObjectSearcher(
					 "associators of {Win32_DiskDrive.DeviceID='" + obj["DeviceID"] + "'} " +
					 "where AssocClass = Win32_DiskDriveToDiskPartition");
				ManagementObjectCollection partcol = partsearch.Get();
				foreach (ManagementObject partobj in partcol)
				{
					if (partobj != null)
					{
						Debug.WriteLine("partition name " + partobj["Name"]);
						ManagementObjectSearcher lsearcher = new ManagementObjectSearcher(
							 "associators of {Win32_DiskPartition.DeviceID='" + partobj["DeviceID"] + "'} " +
							 "where AssocClass= Win32_LogicalDiskToPartition");
						ManagementObjectCollection lcol = lsearcher.Get();
						foreach (ManagementObject logical in lcol)
						{
							if (logical != null)
							{
								Debug.WriteLine("logical=" + logical["Name"]);
							}
							else
								Debug.WriteLine("logical is null");
						}
					}
					else
						Debug.WriteLine("partition is null");
				}
			}
			cDrives.Dispose();
			cDrives = null;
			qDrives = null;
			oSearch.Dispose();
			oSearch = null;
		} // GetUSBdrives()

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// free managed resources
				if (Watcher != null)
					Watcher.Dispose();
			}
			// free native resources if there are any.
		}

	} // end class
} // end namespace
