using MiCurriculum.COMMON.Entidades;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace MiCurriculum.UI.WPF.Usuario.CustomControls
{
    public partial class CardPerfilesCollection : UserControl
    {
        private static WrapPanel _contenedor;
        private static ICommand _editCommand;
        private static ICommand _deleteCommand;
        private static ICommand _goCommand;

        public CardPerfilesCollection()
        {
            InitializeComponent();
            _contenedor = wrpCollectionContainer;
        }

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(IEnumerable<Perfil>), typeof(CardPerfilesCollection), new FrameworkPropertyMetadata()
        {
            DefaultValue = new ObservableCollection<Perfil>(),
            BindsTwoWayByDefault = true,
            DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            PropertyChangedCallback = new PropertyChangedCallback(CambioValorPropiedadItemsSource),
        });

        public static readonly DependencyProperty OnEditCommandDependency = DependencyProperty.Register("OnEditCommand", typeof(ICommand), typeof(CardPerfilesCollection), new FrameworkPropertyMetadata()
        {
            PropertyChangedCallback = new PropertyChangedCallback(CambioValorCommandOnEdit)
        });

        public static readonly DependencyProperty OnDeleteCommandDependency = DependencyProperty.Register("OnDeleteCommand", typeof(ICommand), typeof(CardPerfilesCollection), new FrameworkPropertyMetadata()
        {
            PropertyChangedCallback = new PropertyChangedCallback(CambioValorCommandOnDelete)
        });

        public static readonly DependencyProperty OnGoToCommandDependency = DependencyProperty.Register("GoToCommand", typeof(ICommand), typeof(CardPerfilesCollection), new FrameworkPropertyMetadata()
        {
            PropertyChangedCallback = new PropertyChangedCallback(CambioValorCommandOnGoTo)
        });

        private static void CambioValorPropiedadItemsSource(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            foreach (UIElement element in _contenedor.Children) 
            {
                if (element is CardPerfilItem card)
                {
                    card.Dispose();
                }
            }
            _contenedor.Children.Clear();
            foreach (Perfil perfil in (IEnumerable<Perfil>)e.NewValue)
            {
                CardPerfilItem card = new CardPerfilItem(perfil);
                card.OnEditClick += Card_OnEditClick;
                card.OnDeleteClick += Card_OnDeleteClick;
                card.OnGoClick += Card_OnGoClick;
                _contenedor.Children.Add(card);
            }
        }

        private static void CambioValorCommandOnEdit(DependencyObject d, DependencyPropertyChangedEventArgs e) => _editCommand = (ICommand)e.NewValue;

        private static void CambioValorCommandOnDelete(DependencyObject d, DependencyPropertyChangedEventArgs e) => _deleteCommand = (ICommand)e.NewValue;

        private static void CambioValorCommandOnGoTo(DependencyObject d, DependencyPropertyChangedEventArgs e) => _goCommand = (ICommand)e.NewValue;

        public ICommand OnEditCommand
        {
            get { return (ICommand)GetValue(OnEditCommandDependency); }
            set { SetValue(OnEditCommandDependency, value); }
        }

        public ICommand OnDeleteCommand
        {
            get { return (ICommand)GetValue(OnDeleteCommandDependency); }
            set { SetValue(OnDeleteCommandDependency, value); }
        }

        public ICommand GoToCommand
        {
            get { return (ICommand)GetValue(OnGoToCommandDependency); }
            set { SetValue(OnGoToCommandDependency, value); }
        }

        public IEnumerable<Perfil> ItemsSource
        {
            get { return (IEnumerable<Perfil>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        private static void Card_OnGoClick(object sender, string e)
        {
            if (_goCommand != null)
            {
                if (_goCommand.CanExecute(e))
                {
                    _goCommand.Execute(e);
                }
            }
        }

        private static void Card_OnDeleteClick(object sender, string e)
        {
            if (_deleteCommand != null)
            {
                if (_deleteCommand.CanExecute(e))
                {
                    _deleteCommand.Execute(e);
                }
            }
        }

        private static void Card_OnEditClick(object sender, string e)
        {
            if (_editCommand != null)
            {
                if (_editCommand.CanExecute(e))
                {
                    _editCommand.Execute(e);
                }
            }
        }
    }
}
