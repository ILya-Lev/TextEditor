using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TextEditor.DAL;

namespace TextEditor
{
	/// <summary>
	/// Interaction logic for LoadFileDialog.xaml
	/// </summary>
	public partial class LoadFileDialog : Window
	{
		private readonly ConnectedRepository m_repository = null;
		public int SelectedFileId { get; private set; }
		public LoadFileDialog(ConnectedRepository repository)
		{
			InitializeComponent();
			m_repository = repository;
			var filesInfo = m_repository.AllFilesWithoutContent();
			m_filesGrid.DataContext = filesInfo;
			if (!filesInfo.Any())
			{
				m_createdClmn.Width = 100;
				m_filesGrid.Width = 100;
			}
			SelectedFileId = -1;
		}

		private void ButtonSelect_OnClick(object sender, RoutedEventArgs e)
		{
			if (m_filesGrid.SelectedIndex < 0)
				SelectedFileId = -1;
			else
			{
				var textFileWithoutContent = m_filesGrid.SelectedItem as ConnectedRepository.TextFileWithoutContent;
				SelectedFileId = textFileWithoutContent.Id;
			}
			DialogResult = true;
		}

		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
		{
			SelectedFileId = -1;
			DialogResult = false;
		}
	}
}
