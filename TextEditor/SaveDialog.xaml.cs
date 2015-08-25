using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TextEditor
{
	/// <summary>
	/// Interaction logic for SaveDialog.xaml
	/// </summary>
	public partial class SaveDialog : Window
	{
		public string FileName { get; private set; }
		public SaveDialog()
		{
			InitializeComponent();
			m_btnOk.IsEnabled = false;
			FocusManager.SetFocusedElement(m_label, m_textBoxFileName);
		}

		private void ButtonOk_OnClick(object sender, RoutedEventArgs e)
		{
			FileName = m_textBoxFileName.Text;
			DialogResult = true;
		}

		private void ButtonCancel_OnClick(object sender, RoutedEventArgs e)
		{
			FileName = "";
			DialogResult = false;
		}

		private void TextBoxFileName_OnTextChanged(object sender, TextChangedEventArgs e)
		{
			m_btnOk.IsEnabled = m_textBoxFileName.Text.Length != 0;
		}

		private void SaveDialog_OnClosing(object sender, CancelEventArgs e)
		{
			if (DialogResult != true)
			{
				FileName = "";
				DialogResult = false;
			}
		}
	}
}
