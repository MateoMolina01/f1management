using f1management.Persistence;
using proyectoExamen.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //private void IniciarSesion_Click(object sender, RoutedEventArgs e)
        //{
        //    string user = txtUsuario.Text;
        //    string password = txtPassword.Password;

        //    //comprobacion generica de momento
        //    if(user == "admin" && password == "1234")
        //    {
        //        //cambio la vista princiap
        //        if(Application.Current.MainWindow is MainWindow mainWindow)
        //        {
        //            mainW.LoginExitoso();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        //    }
        //}

        private void IniciarSesion_Click(object sender, RoutedEventArgs e)
        {
            string user = txtUsuario.Text.Trim();
            string password = txtPassword.Password.Trim();

            UsuarioManager usuarioManager = new UsuarioManager();
            List<Usuario> usuarios = usuarioManager.readUsuarios();

            // Buscar el usuario con nombre y contraseña coincidentes
            Usuario usuarioEncontrado = usuarios.FirstOrDefault(u => u.Nombre == user && u.Password == password);

            if (usuarioEncontrado != null)
            {
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
