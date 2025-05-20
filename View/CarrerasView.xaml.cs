using f1management.Persistence;
using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace f1management.View
{
    public partial class CarrerasView : UserControl
    {
        private List<Circuito> circuitos;
        private List<Piloto> pilotos;
        private List<PilotoCircuito> resultados;
        private List<Pais> paises;

        public CarrerasView()
        {
            InitializeComponent();
            CargarTemporadas();
            CargarPilotos();
            CargarCarreras();
            CargarPaises();
        }

        private void Volver_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new DashboardView();
        }

        private void CargarTemporadas()
        {
            TemporadaComboBox.ItemsSource = new List<int> { 2023, 2024, 2025 };
            TemporadaComboBox.SelectedIndex = 0;
        }
        private void CargarPaises()
        {
            PaisManager pm = new PaisManager();
            paises = pm.readPaises(); // Debes tener este método ya hecho
            PaisComboBox.ItemsSource = paises;
        }

        private void CargarPilotos()
        {
            Piloto p = new Piloto();
            pilotos = p.leerPilotos();
            Piloto1ComboBox.ItemsSource = pilotos;
            Piloto2ComboBox.ItemsSource = pilotos;
        }

        private void CargarCarreras()
        {
            Circuito c = new Circuito();
            circuitos = c.leerCircuitos();
            CarrerasListBox.ItemsSource = circuitos;
            if (circuitos.Count > 0)
                CarrerasListBox.SelectedIndex = 0;
        }

        private void TemporadaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualizarInformacionPilotos();
        }

        private void CarrerasListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualizarInformacionPilotos();
        }

        private void PilotoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActualizarInformacionPilotos();
        }

        private void ActualizarInformacionPilotos()
        {
            if (CarrerasListBox.SelectedItem == null || TemporadaComboBox.SelectedItem == null)
                return;

            var circuito = (Circuito)CarrerasListBox.SelectedItem;
            int temporada = (int)TemporadaComboBox.SelectedItem;

            // Cargar resultados de esta carrera y temporada
            PilotoCircuito pc = new PilotoCircuito();
            resultados = pc.ObtenerPorCircuitoYTemporada(circuito.Id, temporada);

            // Mostrar datos de piloto 1
            var piloto1 = (Piloto)Piloto1ComboBox.SelectedItem;
            if (piloto1 != null)
            {
                var res1 = resultados.FirstOrDefault(r => r.IdPiloto == piloto1.Id);
                Piloto1DorsalText.Text = piloto1.Dorsal.ToString();
                Piloto1PuntosText.Text = res1?.Puntos.ToString() ?? "0";
                Piloto1PosicionText.Text = CalcularPosicion(res1?.Puntos ?? 0, resultados);
            }
            else
            {
                Piloto1DorsalText.Text = "";
                Piloto1PuntosText.Text = "";
                Piloto1PosicionText.Text = "";
            }

            // Mostrar datos de piloto 2
            var piloto2 = (Piloto)Piloto2ComboBox.SelectedItem;
            if (piloto2 != null)
            {
                var res2 = resultados.FirstOrDefault(r => r.IdPiloto == piloto2.Id);
                Piloto2DorsalText.Text = piloto2.Dorsal.ToString();
                Piloto2PuntosText.Text = res2?.Puntos.ToString() ?? "0";
                Piloto2PosicionText.Text = CalcularPosicion(res2?.Puntos ?? 0, resultados);
            }
            else
            {
                Piloto2DorsalText.Text = "";
                Piloto2PuntosText.Text = "";
                Piloto2PosicionText.Text = "";
            }
        }

        private string CalcularPosicion(int puntos, List<PilotoCircuito> resultados)
        {
            var ordenados = resultados.OrderByDescending(r => r.Puntos).ToList();
            int posicion = ordenados.FindIndex(r => r.Puntos == puntos) + 1;
            return posicion > 0 ? posicion.ToString() : "-";
        }

        private void AñadirCircuito_Click(object sender, RoutedEventArgs e)
        {
            string nombre = NuevoCircuitoTextBox.Text.Trim();
            Pais paisSeleccionado = (Pais)PaisComboBox.SelectedItem;

            if (string.IsNullOrWhiteSpace(nombre) || paisSeleccionado == null)
            {
                MessageBox.Show("Debes ingresar un nombre y seleccionar un país.", "Campos incompletos", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            Circuito nuevo = new Circuito(nombre, paisSeleccionado.Id);
            nuevo.insert();

            MessageBox.Show($"Circuito '{nombre}' añadido con éxito.", "Nuevo Circuito", MessageBoxButton.OK, MessageBoxImage.Information);

            CargarCarreras();
            NuevoCircuitoTextBox.Clear();
            PaisComboBox.SelectedIndex = -1;

            NuevoCircuitoTextBox.Clear();
            PaisComboBox.SelectedIndex = -1;
            NombrePlaceholder.Visibility = Visibility.Visible;
            PaisPlaceholder.Visibility = Visibility.Visible;
        }

        private void EliminarCircuito_Click(object sender, RoutedEventArgs e)
        {
            if (CarrerasListBox.SelectedItem is Circuito seleccionado)
            {
                MessageBoxResult result = MessageBox.Show($"¿Seguro que quieres eliminar '{seleccionado.Nombre}'?",
                                                           "Confirmar eliminación",
                                                           MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    seleccionado.delete();
                    MessageBox.Show("Circuito eliminado.", "Eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                    CargarCarreras();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un circuito primero.", "Ninguno seleccionado", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void NuevoCircuitoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            NombrePlaceholder.Visibility = string.IsNullOrWhiteSpace(NuevoCircuitoTextBox.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

        private void PaisComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PaisPlaceholder.Visibility = PaisComboBox.SelectedItem == null
                ? Visibility.Visible
                : Visibility.Collapsed;
        }

    }
}
