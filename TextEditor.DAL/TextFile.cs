using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;
using TextEditor.DAL.Interfaces;

namespace TextEditor.DAL
{
	public class TextFile : IModificationHistory, IContentCompression, INotifyPropertyChanged
	{
		#region fields
		private string m_name;
		private string m_content;
		private bool m_isDirty;
		#endregion
		#region properties
		public int Id { get; set; }
		public string Name
		{
			get { return m_name; }
			set
			{
				if (m_name != value)
				{
					m_name = value;
					IsDirty = true;
					OnPropertyChanged("Name");
				}
			}
		}
		public string Content
		{
			get { return m_content; }
			set
			{
				if (m_content != value)
				{
					m_content = value;
					IsDirty = true;
					OnPropertyChanged("Content");
				}
			}
		}
		public bool IsDirty
		{
			get { return m_isDirty; }
			set
			{
				if (m_isDirty != value)
				{
					m_isDirty = value;
					OnPropertyChanged("IsDirty");
				}
			}
		}
		public DateTime DateCreated { get; set; }
		public DateTime DateModified { get; set; }
		#endregion
		#region INotifyPropertyChanged implementation section
		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		#endregion
		#region IContentCompression implementation section
		public byte[] CompressedContent { get; set; }
		/// <summary>
		/// takes Content and compresses it into a byte array
		/// </summary>
		public async Task Compress()
		{
			if (Content != null)
			{
				byte[] strBytes = Encoding.Unicode.GetBytes(Content);

				using (MemoryStream inStream = new MemoryStream(strBytes))
				using (MemoryStream outStream = new MemoryStream())
				{
					using (GZipStream gz = new GZipStream(outStream, CompressionMode.Compress))
					{
						await inStream.CopyToAsync(gz);
					}
					CompressedContent = outStream.ToArray();
				}
			}
		}
		/// <summary>
		/// takes byte array and decompress it into Content
		/// </summary>
		public async Task Decompress()
		{
			if (CompressedContent != null && CompressedContent.Length != 0)
			{
				using (MemoryStream inStream = new MemoryStream(CompressedContent))
				using (MemoryStream outStream = new MemoryStream())
				{
					using (GZipStream gz = new GZipStream(inStream, CompressionMode.Decompress))
					{
						await gz.CopyToAsync(outStream);
					}
					Content = Encoding.Unicode.GetString(outStream.ToArray());
				}
			}
			else
			{
				Content = "";
			}
		}
		#endregion
	}
}
