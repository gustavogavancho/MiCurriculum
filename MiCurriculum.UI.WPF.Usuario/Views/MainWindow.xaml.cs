using MiCurriculum.UI.WPF.Usuario.ViewModels;
using System.Windows;

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
    }
}
