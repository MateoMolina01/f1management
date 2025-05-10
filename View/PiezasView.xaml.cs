using System.Windows;
using System.Windows.Controls;

namespace f1management.View
{
    public partial class PiezasView : UserControl
    {
        public PiezasView()
        {
            InitializeComponent();
            CargarPiezas();
        }

        private void CargarPiezas()
        {
            // Aquí traerás las piezas desde la base de datos
            // listaPiezas.ItemsSource = PiezasManager.ObtenerTodas();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new DashboardView();
        }


        private void listaPiezas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Suponiendo que tienes una clase Pieza
            // var pieza = (Pieza)listaPiezas.SelectedItem;

            // txtDescripcion.Text = pieza.Descripcion;
            // txtFechaMontaje.Text = pieza.FechaMontaje.ToShortDateString();
            // txtPrecio.Text = pieza.Precio.ToString("F2");
            // txtProveedor.Text = pieza.IdProveedor.ToString();
            // txtMontada.Text = pieza.Montada ? "Sí" : "No";

            // txtGastoEstimado.Text = ""; // Se actualizará solo al pulsar mejorar/cambiar
        }

        private void Mejorar_Click(object sender, RoutedEventArgs e)
        {
            // Aquí puedes definir la lógica de mejora (por ejemplo: +15% coste)
            // if (pieza != null) { gasto = pieza.Precio * 0.15 }
        }

        private void Cambiar_Click(object sender, RoutedEventArgs e)
        {
            // Aquí definirías que el gasto es el precio completo de una nueva pieza
            // if (pieza != null) { gasto = pieza.Precio }
        }
    }
}
