using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TextEditor.DAL.Interfaces;

namespace TextEditor.DAL
{
	public class FileDbContext : DbContext
	{
		public DbSet<TextFile> Files { get; set; }

		public FileDbContext(string connString)
			: base(connString)
		{
		}

		#region Fluence API section
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Types().Configure(c => c.Ignore("IsDirty"));		// ignores column IsDirty for every table for schema, update, modified
			modelBuilder.Types().Configure(c => c.Ignore("Content"));
			base.OnModelCreating(modelBuilder);
		}

		/// <summary>
		/// think of overloaded version with CancellationToken
		/// </summary>
		/// <returns>amount of rows affected</returns>
		public async override Task<int> SaveChangesAsync()
		{
			await BeforeSaveChanges();
			int result = await base.SaveChangesAsync();

			AfterSaveChanges();
			return result;
		}

		private async Task BeforeSaveChanges()
		{
			foreach (var history in ChangeTracker.Entries()
									.Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added || e.State == EntityState.Modified))
									.Select(e => e.Entity as IModificationHistory))
			{
				if (history.DateCreated == DateTime.MinValue)
					history.DateCreated = DateTime.Now;
				history.DateModified = DateTime.Now;
			}

			foreach (var content in ChangeTracker.Entries()
									.Where(e => e.Entity is IContentCompression && (e.State == EntityState.Added || e.State == EntityState.Modified))
									.Select(e => e.Entity as IContentCompression))
			{
				await content.Compress();
			}
		}

		private void AfterSaveChanges()
		{
			foreach (var history in ChangeTracker.Entries()
				.Where(e => e.Entity is IModificationHistory)
				.Select(e => e.Entity as IModificationHistory))
			{
				history.IsDirty = false;
			}
		}
		#endregion
	}
}
