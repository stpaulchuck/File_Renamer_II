using System;
using System.IO;


namespace FileRenamer2
{
	public class FileChangeEventArgs
	{
		public string FolderPath = "";
		public string ChangeType = "";
	}

	public delegate void FileChangedEventHandler(object sender, FileChangeEventArgs e);

	class FileChangeWatcher : IDisposable
	{
		FileSystemWatcher Watcher = new FileSystemWatcher();
		public event FileChangedEventHandler eFileChanged;

		private string m_FolderPath = "";
		public string FolderPath
		{ get { return m_FolderPath; } set { m_FolderPath = value; Watcher.Path = value; } }

		public FileChangeWatcher()
		{
			Watcher.Filter = "*.*";
			Watcher.IncludeSubdirectories = true;
			Watcher.NotifyFilter = NotifyFilters.DirectoryName | NotifyFilters.FileName;
			Watcher.Created += new FileSystemEventHandler(Watcher_Created);
			Watcher.Deleted += new FileSystemEventHandler(Watcher_Deleted);
			Watcher.Renamed += new RenamedEventHandler(Watcher_Renamed);
		}

		void Watcher_Renamed(object sender, RenamedEventArgs e)
		{
			if (eFileChanged != null)
			{
				FileChangeEventArgs args = new FileChangeEventArgs
				{
					FolderPath = m_FolderPath,
					ChangeType = "Rename"
				};
				eFileChanged(this, args);
			}
		}

		void Watcher_Deleted(object sender, FileSystemEventArgs e)
		{
			if (eFileChanged != null)
			{
				FileChangeEventArgs args = new FileChangeEventArgs
				{
					FolderPath = m_FolderPath,
					ChangeType = "Deleted"
				};
				eFileChanged(this, args);
			}
		}

		void Watcher_Created(object sender, FileSystemEventArgs e)
		{
			if (eFileChanged != null)
			{
				FileChangeEventArgs args = new FileChangeEventArgs
				{
					FolderPath = m_FolderPath,
					ChangeType = "Created"
				};
				eFileChanged(this, args);
			}
		}

		public void Start()
		{
			Watcher.EnableRaisingEvents = true;
		}

		public void Stop()
		{
			Watcher.EnableRaisingEvents = false;
		}

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
