using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor.DAL.Interfaces
{
	public interface IContentCompression
	{
		byte[] CompressedContent { get; set; }
		Task Compress();
		Task Decompress();
	}
}
