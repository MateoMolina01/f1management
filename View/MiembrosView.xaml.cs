using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace f1management.View
{
    public partial class MiembrosView : UserControl
    {
        // Clase simple para representar un miembro
        public class Miembro
        {
            public string Nombre { get; set; }
            public string Rol { get; set; }
            public string MonoplazaAsignado { get; set; }
        }

        private List<Miembro> miembros = new List<Miembro>();
        private Miembro miembroSeleccionado = null;

        public MiembrosView()
        {
            InitializeComponent();
            // Cargar los miembros desde la BBDD cuando lo implementes
            CargarMiembros();
        }

        private void CargarMiembros()
        {
            // Aquí más adelante pondrás la lógica para cargar desde la base de datos.
            ListaMiembros.ItemsSource = null;
            ListaMiembros.ItemsSource = miembros;
        }

        private void ListaMiembros_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            miembroSeleccionado = (Miembro)ListaMiembros.SelectedItem;

            if (miembroSeleccionado != null)
            {
                TxtNombre.Text = miembroSeleccionado.Nombre;
                CmbRol.Text = miembroSeleccionado.Rol;
                TxtMonoplaza.Text = miembroSeleccionado.MonoplazaAsignado;
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (miembroSeleccionado != null)
            {
                miembroSeleccionado.Nombre = TxtNombre.Text;
                miembroSeleccionado.Rol = CmbRol.Text;
                miembroSeleccionado.MonoplazaAsignado = TxtMonoplaza.Text;
                CargarMiembros();
            }
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (miembroSeleccionado != null)
            {
                miembros.Remove(miembroSeleccionado);
                miembroSeleccionado = null;
                LimpiarFormulario();
                CargarMiembros();
            }
        }

        private void Añadir_Click(object sender, RoutedEventArgs e)
        {
            var nuevo = new Miembro
            {
                Nombre = TxtNombre.Text,
                Rol = CmbRol.Text,
                MonoplazaAsignado = TxtMonoplaza.Text
            };

            miembros.Add(nuevo);
            LimpiarFormulario();
            CargarMiembros();
        }

        private void LimpiarFormulario()
        {
            TxtNombre.Text = "";
            CmbRol.SelectedIndex = -1;
            TxtMonoplaza.Text = "";
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new DashboardView();
        }
    }
}
