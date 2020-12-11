using MiCurriculum.COMMON.Entidades;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MiCurriculum.UI.WPF.Usuario.CustomControls
{
    public partial class CardPerfilItem : UserControl, IDisposable
    {
        Perfil _perfil;

        public event EventHandler<string> OnEditClick;
        public event EventHandler<string> OnDeleteClick;
        public event EventHandler<string> OnGoClick;

        public CardPerfilItem(Perfil perfil)
        {
            InitializeComponent();
            txtNombres.Text = perfil.Nombres;
            txtApellidos.Text = perfil.Apellidos;
            txtProfesion.Text = perfil.Profesion;
            if (perfil.Foto != null && perfil.Foto.Length > 0)
                imgLogo.Source = ByteToImage(perfil.Foto);
            _perfil = perfil;
        }

        public void Dispose()
        {
            _perfil.Dispose();
            GC.SuppressFinalize(this);
        }

        private ImageSource ByteToImage(byte[] imageData)
        {
            if (imageData == null)
            {
                return null;
            }
            else
            {
                BitmapImage biImg = new BitmapImage();
                MemoryStream ms = new MemoryStream(imageData);
                biImg.BeginInit();
                biImg.StreamSource = ms;
                biImg.EndInit();
                ImageSource imgSrc = biImg as ImageSource;
                return imgSrc;
            }
        }

        private byte[] ImageToByte(ImageSource image)
        {
            if (image != null)
            {
                MemoryStream memStream = new MemoryStream();
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image as BitmapSource));
                encoder.Save(memStream);
                return memStream.ToArray();
            }
            else
            {
                return null;
            }
        }

        private void btnEditar_Click(object sender, RoutedEventArgs e) => OnEditClick(this, _perfil.Id);
        private void btnBorrar_Click(object sender, RoutedEventArgs e) => OnDeleteClick(this, _perfil.Id);
        private void btnIr_Click(object sender, RoutedEventArgs e) => OnGoClick(this, _perfil.Id);
    }
}
