using System;
using System.Windows.Controls;

namespace MiCurriculum.UI.WPF.Usuario.Contracts.Services
{
    public interface IElementoGenerico
    {
        event EventHandler<UserControl> CambiarModulo;
    }
}
