using MiCurriculum.UI.WPF.Usuario.CustomControls;
using MiCurriculum.UI.WPF.Usuario.Helpers;
using MiCurriculum.UI.WPF.Usuario.Views;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace MiCurriculum.UI.WPF.Usuario.ViewModels
{
    public class MainWindowModel : BaseViewModel
    {
        public ICommand _closeCommand;
        public ICommand CloseCommand => _closeCommand ?? (_closeCommand = new RelayCommand(OnCloseCommand));

        public MainWindowModel()
        {

        }

        private void OnCloseCommand()
        {
            DialogResult result = CustomMessageBox.Show("¿Esta seguro que desear cerrar la aplicación?", CustomMessageBox.CMessageBoxTitle.Confirmación, CustomMessageBox.CMessageBoxButton.Si, CustomMessageBox.CMessageBoxButton.No);
            if (result == DialogResult.Yes)
            {
                System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().Close();
            }
        }

    }
}
