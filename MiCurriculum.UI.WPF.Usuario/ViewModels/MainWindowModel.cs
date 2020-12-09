using MiCurriculum.UI.WPF.Usuario.Helpers;
using MiCurriculum.UI.WPF.Usuario.Views;
using System;
using System.Linq;
using System.Windows;
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
            Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().Close();
        }

    }
}
