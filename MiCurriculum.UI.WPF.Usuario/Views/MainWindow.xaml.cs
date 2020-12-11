using MiCurriculum.UI.WPF.Usuario.CustomControls;
using MiCurriculum.UI.WPF.Usuario.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;

namespace MiCurriculum.UI.WPF.Usuario.Views
{
    public partial class MainWindow : Window
    {
        MainWindowModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = _viewModel = new MainWindowModel();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            DialogResult result = CustomMessageBox.Show("¿Esta seguro que desear cerrar la aplicación?", CustomMessageBox.CMessageBoxTitle.Confirmación, CustomMessageBox.CMessageBoxButton.Si, CustomMessageBox.CMessageBoxButton.No);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                base.OnClosing(e);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
