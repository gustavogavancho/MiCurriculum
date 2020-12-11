using System.Windows;

namespace MiCurriculum.UI.WPF.Usuario.Views.Modals
{
    public partial class CrearEditarPerfilModal : Window
    {
        public CrearEditarPerfilModal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
