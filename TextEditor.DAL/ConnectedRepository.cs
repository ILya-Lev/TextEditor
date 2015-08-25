using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace TextEditor.DAL
{
	public class ConnectedRepository
	{
		private FileDbContext m_context = null;

		public class TextFileWithoutContent
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public DateTime Created { get; set; }
			public DateTime Modified { get; set; }
		}

		public ConnectedRepository(string connectionString)
		{
			m_context = new FileDbContext(connectionString);
		}

		public IEnumerable<TextFileWithoutContent> AllFilesWithoutContent()
		{
			return m_context.Files.Select(e => new TextFileWithoutContent { Id = e.Id, Name = e.Name, Created = e.DateCreated, Modified = e.DateModified }).ToList();
		}

		/// <summary>
		/// fetches file object form db by id; but indeed at first EF looks up memory;
		/// this may lead to differences between db content and one shown in UI
		/// to avoid such situations loaded files are always reloaded from db
		/// target use case: open file A; modify it; click Open button again; reject prompt to save changes in A; select file A in open dialog
		/// without direct request to db file A will contain the modifications, 'cause they are still stored in memory; but are absent in db
		/// </summary>
		/// <param name="id">id of the target file</param>
		/// <returns>text file object with all properties</returns>
		public async Task<TextFile> FileById(int id)
		{
			var aFile = m_context.Files.Find(id);
			m_context.Entry(aFile).Reload();
			await aFile.Decompress();
			return aFile;
		}

		public TextFile NewFile()
		{
			var textFile = new TextFile();
			m_context.Files.Add(textFile);
			return textFile;
		}

		public async Task UpdateAsync(TextFile aFile)
		{
			if (aFile.IsDirty)
				m_context.Entry(aFile).State = EntityState.Modified;
			await m_context.SaveChangesAsync();
		}

		public async Task SaveAsync()
		{
			RemoveEmptyNewFiles();
			await m_context.SaveChangesAsync();
		}

		private void RemoveEmptyNewFiles()
		{
			for (int i = m_context.Files.Local.Count; i > 0; --i)
			{
				var textFile = m_context.Files.Local[i - 1];
				if (m_context.Entry(textFile).State == EntityState.Added && !textFile.IsDirty)
				{
					m_context.Files.Remove(textFile);
				}
			}
		}
	}
}
