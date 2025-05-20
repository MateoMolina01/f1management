using f1management.Persistence;
using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using System.IO;
using System.Text;

namespace f1management.View
{
    public partial class PiezasView : UserControl
    {
        private List<Pieza> piezas;
        private Pieza piezaSeleccionada;

        private List<Pieza> piezasFiltradas; // Lista que se muestra en pantalla

        private Dictionary<int, Proveedor> proveedoresPorId;

        private Dictionary<int, List<string>> historialPorPieza = new Dictionary<int, List<string>>();

        public PiezasView()
        {
            InitializeComponent();
            CargarPiezas();
        }

        private void CargarPiezas()
        {
            Pieza pieza = new Pieza();
            piezas = pieza.readPiezas();

            // Copia inicial
            piezasFiltradas = new List<Pieza>(piezas);

            ListaPiezas.ItemsSource = piezasFiltradas;

            // Cargar proveedores
            ProveedorManager pm = new ProveedorManager();
            var proveedores = pm.readProveedores();
            proveedoresPorId = proveedores.ToDictionary(p => p.Id);

            ActualizarResumenMontadas();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new DashboardView();
        }

        private void ListaPiezas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            piezaSeleccionada = (Pieza)ListaPiezas.SelectedItem;
            if (piezaSeleccionada != null)
            {
                DescripcionText.Text = piezaSeleccionada.Descripcion;
                FechaMontajeText.Text = piezaSeleccionada.FechaMontaje.ToShortDateString();
                PrecioText.Text = piezaSeleccionada.Precio.ToString("F2") + " €";

                if (proveedoresPorId.TryGetValue(piezaSeleccionada.IdProveedor, out Proveedor proveedor))
                {
                    ProveedorText.Text = proveedor.Nombre;
                }
                else
                {
                    ProveedorText.Text = "Desconocido";
                }

                MontadaCheckBox.IsChecked = piezaSeleccionada.Montada;

                // Mostrar historial
                if (piezaSeleccionada != null && historialPorPieza.TryGetValue(piezaSeleccionada.Id, out List<string> historial))
                {
                    HistorialListBox.ItemsSource = historial;
                }
                else
                {
                    HistorialListBox.ItemsSource = null;
                }
            }
        }

        private void MontadaCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CambiarEstadoMontada(true);
        }

        private void MontadaCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CambiarEstadoMontada(false);
        }

        private void CambiarEstadoMontada(bool nuevaMontada)
        {
            if (piezaSeleccionada != null)
            {
                piezaSeleccionada.Montada = nuevaMontada;
                piezaSeleccionada.update(); //Se guarda en BD

                ActualizarResumenMontadas(); //Se actualiza la etiqueta de resumen
            }
        }

        private void Mejorar_Click(object sender, RoutedEventArgs e)
        {
            if (piezaSeleccionada != null)
            {
                float gastoMejora = piezaSeleccionada.Precio * 0.15f;
                string entrada = $"Mejorada - {DateTime.Now:G}";

                if (!historialPorPieza.ContainsKey(piezaSeleccionada.Id))
                    historialPorPieza[piezaSeleccionada.Id] = new List<string>();

                historialPorPieza[piezaSeleccionada.Id].Add(entrada);
                HistorialListBox.ItemsSource = null;
                HistorialListBox.ItemsSource = historialPorPieza[piezaSeleccionada.Id];

                MessageBox.Show($"Mejora aplicada. Gasto estimado: {gastoMejora:F2} €", "Mejorar Pieza", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Cambiar_Click(object sender, RoutedEventArgs e)
        {
            if (piezaSeleccionada != null)
            {
                float gastoCambio = piezaSeleccionada.Precio;
                string entrada = $"Cambiada - {DateTime.Now:G}";

                if (!historialPorPieza.ContainsKey(piezaSeleccionada.Id))
                    historialPorPieza[piezaSeleccionada.Id] = new List<string>();

                historialPorPieza[piezaSeleccionada.Id].Add(entrada);
                HistorialListBox.ItemsSource = null;
                HistorialListBox.ItemsSource = historialPorPieza[piezaSeleccionada.Id];

                MessageBox.Show($"Cambio realizado. Gasto estimado: {gastoCambio:F2} €", "Cambiar Pieza", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BuscadorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = BuscadorTextBox.Text.Trim().ToLower();

            piezasFiltradas = piezas
                .Where(p => p.Descripcion.ToLower().Contains(texto))
                .ToList();

            ListaPiezas.ItemsSource = piezasFiltradas;

            PlaceholderText.Visibility = string.IsNullOrEmpty(BuscadorTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;

            ActualizarResumenMontadas(); // aquí se actualiza el resumen
        }

        private void ActualizarResumenMontadas()
        {
            var piezasMontadas = piezasFiltradas.Where(p => p.Montada).ToList();

            int totalMontadas = piezasMontadas.Count;
            float costeTotal = piezasMontadas.Sum(p => p.Precio);

            ResumenMontadasText.Text = $"Total piezas montadas: {totalMontadas} | Coste total: {costeTotal:F2} €";
        }

        private void ProveedorText_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (piezaSeleccionada != null && proveedoresPorId.TryGetValue(piezaSeleccionada.IdProveedor, out Proveedor proveedor))
            {
                MessageBox.Show($"Contacto del proveedor:\n{proveedor.Contacto}", $"Proveedor: {proveedor.Nombre}", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ExportarCSV_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "CSV files (*.csv)|*.csv",
                Title = "Guardar piezas como CSV",
                FileName = "piezas.csv"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("ID;Descripción;Fecha Montaje;Precio;Montada;Proveedor");

                var piezasAExportar = ListaPiezas.ItemsSource as IEnumerable<Pieza>;

                if (piezasAExportar == null || !piezasAExportar.Any())
                {
                    MessageBox.Show("No hay piezas visibles para exportar.", "Exportar CSV", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                foreach (var pieza in piezasAExportar)
                {
                    string proveedor = proveedoresPorId.TryGetValue(pieza.IdProveedor, out var p) ? p.Nombre : "Desconocido";
                    string linea = $"{pieza.Id};{pieza.Descripcion};{pieza.FechaMontaje:dd/MM/yyyy};{pieza.Precio:F2};{(pieza.Montada ? "Sí" : "No")};{proveedor}";
                    sb.AppendLine(linea);
                }

                try
                {
                    File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Exportación completada con éxito.", "Exportar CSV", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
