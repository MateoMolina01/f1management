using f1management.Persistence;
using proyectoExamen.persistence.manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace f1management.View
{
    /// <summary>
    /// Lógica de interacción para RegistroUsuarioWindow.xaml
    /// </summary>
    public partial class RegistroUsuarioWindow : Window
    {
        public RegistroUsuarioWindow()
        {
            InitializeComponent();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Registrar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password;
            string confirmPassword = txtPasswordConfirm.Password;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos vacíos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El formato del email no es válido.", "Email incorrecto", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UsuarioManager manager = new UsuarioManager();

            if (manager.ExisteEmail(email))
            {
                MessageBox.Show("El correo electrónico ya está registrado.", "Duplicado", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (manager.ExisteNombreUsuario(nombre))
            {
                MessageBox.Show("El nombre de usuario ya existe.", "Duplicado", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {

                Usuario nuevoUsuario = new Usuario
                {
                    Nombre = nombre,
                    Email = email,
                    Password = password, 
                    EsAdmin = false
                };

                nuevoUsuario.insert();

                MessageBox.Show("Usuario registrado correctamente.", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar el usuario: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
