using MiCurriculum.UI.WPF.Usuario.CustomControls;
using MiCurriculum.UI.WPF.Usuario.Helpers;
using MiCurriculum.UI.WPF.Usuario.Views;
using MiCurriculum.UI.WPF.Usuario.Views.Modals;
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

        public ICommand _crearEditarPerfilCommand;
        public ICommand CrearEditarPerfilCommand => _crearEditarPerfilCommand ?? (_crearEditarPerfilCommand = new RelayCommand(OnCrearEditarPerfil));


        public MainWindowModel()
        {

        }

        private void OnCloseCommand()
        {
            System.Windows.Application.Current.Windows.OfType<MainWindow>().FirstOrDefault().Close();
        }

        private void OnCrearEditarPerfil()
        {
            //TODO: Programar respuesta al cerrar el modal y optimizar el código
            var modal = new CrearEditarPerfilModal();
            modal.ShowDialog();
        }
    }
}
