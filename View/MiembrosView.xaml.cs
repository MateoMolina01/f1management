using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using f1management.Persistence;
using f1management.Persistence.Manages;
using proyectoExamen.persistence.manages;

namespace f1management.View
{
    public partial class MiembrosView : UserControl
    {
        private List<Miembro> miembros = new List<Miembro>();
        private Miembro miembroSeleccionado = null;
        private MiembroManager mm = new MiembroManager();

        private List<Usuario> usuarios = new List<Usuario>();
        private UsuarioManager um = new UsuarioManager();

        private List<Rol> roles = new List<Rol>();
        private RolManager rm = new RolManager();

        public MiembrosView()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarRoles();
            CargarMiembros();
        }

        public void CargarMiembros()
        {
            miembros.Clear();
            miembros = mm.readMiembros();
            ListaMiembros.ItemsSource = null;
            ListaMiembros.ItemsSource = miembros;
        }

        public void CargarUsuarios()
        {
            usuarios = um.readUsuarios();
            CmbUsuario.ItemsSource = usuarios;
            CmbRol.DisplayMemberPath = "Nombre";
            CmbRol.SelectedValuePath = "Id";
        }

        public void CargarRoles()
        {
            roles = rm.readRoles();
            CmbRol.ItemsSource = roles;
            CmbRol.DisplayMemberPath = "Nombre";
            CmbRol.SelectedValuePath = "Id";
        }

        public void ListaMiembros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            miembroSeleccionado = (Miembro)ListaMiembros.SelectedItem;

            if (miembroSeleccionado != null)
            {
                TxtNombre.Text = miembroSeleccionado.Nombre;
                TxtMonoplaza.Text = miembroSeleccionado.IdMonoplaza.ToString();
                CmbRol.SelectedValue = miembroSeleccionado.IdRol;
                CmbUsuario.SelectedValue = miembroSeleccionado.IdUsuario;
            }
        }

        public void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (miembroSeleccionado != null)
            {
                miembroSeleccionado.Nombre = TxtNombre.Text;

                if (int.TryParse(TxtMonoplaza.Text, out int idMonoplaza))
                {
                    miembroSeleccionado.IdMonoplaza = idMonoplaza;
                }

                if (CmbRol.SelectedValue != null && int.TryParse(CmbRol.SelectedValue.ToString(), out int idRol))
                {
                    miembroSeleccionado.IdRol = idRol;
                }

                if (CmbUsuario.SelectedItem is Usuario usuarioSeleccionado)
                {
                    miembroSeleccionado.IdUsuario = usuarioSeleccionado.Id;
                }

                miembroSeleccionado.update();
                //CargarMiembros();
                LimpiarFormulario();
            }
        }

        public void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (miembroSeleccionado != null)
            {
                miembroSeleccionado.delete();
                miembroSeleccionado = null;
                LimpiarFormulario();
                CargarMiembros();
            }
        }

        public void Añadir_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text) ||
                CmbRol.SelectedValue == null ||
                string.IsNullOrWhiteSpace(TxtMonoplaza.Text) ||
                CmbUsuario.SelectedItem == null)
            {
                MessageBox.Show("Por favor, rellena todos los campos antes de añadir.");
                return;
            }

            if (!int.TryParse(TxtMonoplaza.Text, out int idMonoplaza))
            {
                MessageBox.Show("El ID del monoplaza debe ser un número.");
                return;
            }

            int idRol = Convert.ToInt32(CmbRol.SelectedValue);
            int idUsuario = ((Usuario)CmbUsuario.SelectedItem).Id;

            Miembro nuevo = new Miembro
            {
                Nombre = TxtNombre.Text,
                IdMonoplaza = idMonoplaza,
                IdRol = idRol,
                IdUsuario = idUsuario
            };

            nuevo.insert();

            LimpiarFormulario();
            CargarMiembros();
        }

        public void LimpiarFormulario()
        {
            TxtNombre.Text = "";
            TxtMonoplaza.Text = "";
            CmbRol.SelectedIndex = -1;
            CmbUsuario.SelectedIndex = -1;
        }

        public void Volver_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new DashboardView();
        }
    }
}
