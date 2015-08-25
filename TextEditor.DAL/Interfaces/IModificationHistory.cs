using System;

namespace TextEditor.DAL.Interfaces
{
	public interface IModificationHistory
	{
		bool IsDirty { get; set; }
		DateTime DateCreated { get; set; }
		DateTime DateModified { get; set; }
	}
}
