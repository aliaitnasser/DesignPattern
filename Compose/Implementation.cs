namespace Composite
{
	/// <summary>
	/// Conponent
	/// </summary>
	public abstract class FileSystemItem
	{
		public string Name { get; set; }
		public abstract long GetSize();

		public FileSystemItem(string name)
		{
			Name = name;
		}
	}
	
	/// <summary>
	/// leaf
	/// </summary>
	public class File : FileSystemItem
	{
		public long Size { get; set; }

		public File(string name, long size) : base(name)
		{
			Size = size;
		}

		public override long GetSize()
		{
			return Size;
		}
	}

	public class Directory : FileSystemItem
	{
		private List<FileSystemItem> _fileItems = new ();
		private long _size;
		public Directory(string name, long size) : base(name)
		{
			_size = size;
		}

		public void add(FileSystemItem itemToAdd)
		{
			_fileItems.Add(itemToAdd);
		}

		public void remove(FileSystemItem itemToRemove)
		{
			_fileItems.Remove(itemToRemove);
		}

		public override long GetSize()
		{
			long treeSize = _size;
			foreach (var item in _fileItems)
			{
				treeSize += item.GetSize();
			}
			return treeSize;
		}
	}	
}
