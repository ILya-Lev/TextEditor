using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TextEditor.DAL;

namespace TextEditor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly ConnectedRepository m_repository = null;
		private TextFile m_textFile = null;
		public MainWindow()
		{
			InitializeComponent();

			//@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TextEditor.DAL.FileDbContext;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
			m_repository = new ConnectedRepository(ReadConnectionString());
			LoadTextFile(-1);
		}

		private static string ReadConnectionString()
		{
			string connectionString;
			using (FileStream fs = new FileStream("ConnectionString.txt", FileMode.Open))
			using (MemoryStream ms = new MemoryStream())
			{
				fs.CopyTo(ms);
				connectionString = Encoding.ASCII.GetString(ms.ToArray());
			}
			return connectionString;
		}

		private async void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			await SavingEntrails();
		}

		private async Task SavingEntrails()
		{
			try
			{
				if (string.IsNullOrEmpty(m_textFile.Name))
				{
					var saveDlg = new SaveDialog();
					var result = saveDlg.ShowDialog();
					if (result == true)
						m_textFile.Name = saveDlg.FileName;
					else
						return;
					await m_repository.SaveAsync();
				}
				else
				{
					await m_repository.UpdateAsync(m_textFile);
				}
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, exc.Message + "\n" + exc.StackTrace, "Exception on saving text file", MessageBoxButton.OK,
					MessageBoxImage.Error);
			}
		}

		private async void OpenButton_OnClick(object sender, RoutedEventArgs e)
		{
			if (m_textFile.IsDirty)
			{
				var answer = MessageBox.Show(this, "Current text file has not been saved yet. Do you want to proceed anyway?",
					"File is not saved!", MessageBoxButton.YesNo, MessageBoxImage.Warning);
				if (answer == MessageBoxResult.Yes)
				{
					m_textFile.IsDirty = false;
				}
				else
				{
					await SavingEntrails();
				}
			}

			try
			{
				var loadDialog = new LoadFileDialog(m_repository);
				loadDialog.ShowDialog();
				LoadTextFile(loadDialog.SelectedFileId);
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, exc.Message + "\n" + exc.StackTrace, "Exception on opening another text file",
					MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private async void LoadTextFile(int id)
		{
			try
			{
				if (id == -1)
				{
					m_textFile = m_repository.NewFile();
				}
				else
				{
					m_textFile = await m_repository.FileById(id);
				}
				m_textFile.IsDirty = false;
				m_text.DataContext = m_textFile;
				Title = string.Format("TextEditor - {0}", string.IsNullOrEmpty(m_textFile.Name) ? "*" : m_textFile.Name);
				m_textFile.PropertyChanged += TextFileBecomeDirtyHandler;
			}
			catch (Exception exc)
			{
				MessageBox.Show(this, exc.Message + "\n" + exc.StackTrace, "Exception on loading text file", MessageBoxButton.OK,
					MessageBoxImage.Error);
			}
		}

		private void MainWindow_OnClosing(object sender, CancelEventArgs e)
		{
			if (m_textFile.IsDirty)
			{
				e.Cancel = false;
				var answer = MessageBox.Show(this, "Current text file is not saved. Do you want to save it?", "File is not saved",
					MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
				if (answer == MessageBoxResult.Yes)
				{
					SaveButton_OnClick(this, new RoutedEventArgs());
				}
				else if (answer == MessageBoxResult.Cancel)
				{
					e.Cancel = true;
				}
			}
		}

		private void TextFileBecomeDirtyHandler(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "IsDirty")
			{
				Title = string.Format("TextEditor - {0}", string.IsNullOrEmpty(m_textFile.Name) ? "*" : m_textFile.Name);
			}
			if (m_textFile.IsDirty)
			{
				if (!Title.EndsWith("*")) Title += "*";
			}
			else
			{
				Title = Title.TrimEnd('*');
			}
		}
	}
}
