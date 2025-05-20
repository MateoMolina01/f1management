using f1management.Persistence;
using proyectoExamen.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace f1management.View
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {

        private MainWindow mainW;

        public LoginView(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainW = mainWindow;
        }

        private void CrearCuenta_Click(object sender, RoutedEventArgs e)
        {
            RegistroUsuarioWindow ventanaRegistro = new RegistroUsuarioWindow();
            ventanaRegistro.ShowDialog(); // Modal
        }

        private void IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string password = txtPassword.Password;

            UsuarioManager usuarioManager = new UsuarioManager();
            List<Usuario> usuarios = usuarioManager.readUsuarios();

            string passwordEncriptada = usuarioManager.EncriptarContraseña(password);

            // Buscar el usuario con nombre y contraseña coincidentes
            Usuario usuarioEncontrado = usuarios.FirstOrDefault(u => u.Nombre == user && u.Password == passwordEncriptada);

            if (usuarioEncontrado != null)
            {
                //lo guardo en el app para poder usarlo en el resto de la aplicacion
                App.UsuarioActual = usuarioEncontrado;

                // Login correcto: puedes verificar también si es admin con usuarioEncontrado.EsAdmin
                if (Application.Current.MainWindow is MainWindow mainW)
                {
                    mainW.LoginExitoso();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

       
    }
}
