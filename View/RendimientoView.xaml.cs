using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using f1management.APIs; // Ajusta el namespace según corresponda
using System.Windows.Input;
using f1management.APIs;

namespace f1management.View
{
    public partial class RendimientoView : UserControl
    {
        private readonly ErgastApiService _apiService = new ErgastApiService();

        public RendimientoView()
        {
            InitializeComponent();

            this.Dispatcher.InvokeAsync(async () =>
            {
                await CargarClasificacionAsync();
            });
        }

        private async void RendimientoView_Loaded(object sender, RoutedEventArgs e)
        {
            await CargarClasificacionAsync();
        }

        private async void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {
            await CargarClasificacionAsync();
        }

        private async Task CargarClasificacionAsync()
        {
            if (dataGridDrivers == null)
                return;

            CerrarPanel_Click(null, null); // Cierra el panel lateral si estaba abierto

            try
            {
                var tipo = ((ComboBoxItem)TipoClasificacionComboBox.SelectedItem)?.Content?.ToString();

                // Limpiar columnas y datos anteriores
                dataGridDrivers.Columns.Clear();
                dataGridDrivers.ItemsSource = null;

                if (tipo == "Pilotos")
                {
                    var data = await _apiService.GetDriverStandingsAsync();

                    var standings = data.MRData.StandingsTable.StandingsLists.First().DriverStandings
                        .Select(d => new
                        {
                            Posición = d.position,
                            Piloto = $"{d.Driver.givenName} {d.Driver.familyName}",
                            Nacionalidad = d.Driver.nationality,
                            Equipo = d.Constructors.First().name,
                            Puntos = d.points,
                            Victorias = d.wins
                        }).ToList();

                    var columnaPosicion = new DataGridTemplateColumn
                    {
                        Header = "Posición",
                        Width = 80,
                        CellTemplate = (DataTemplate)this.FindResource("PosicionTemplate")
                    };

                    dataGridDrivers.Columns.Add(columnaPosicion);
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Piloto", Binding = new System.Windows.Data.Binding("Piloto") });
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Nacionalidad", Binding = new System.Windows.Data.Binding("Nacionalidad") });
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Equipo", Binding = new System.Windows.Data.Binding("Equipo") });
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Puntos", Binding = new System.Windows.Data.Binding("Puntos") });
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Victorias", Binding = new System.Windows.Data.Binding("Victorias") });

                    dataGridDrivers.ItemsSource = standings;
                }
                else if (tipo == "Equipos")
                {
                    var data = await _apiService.GetConstructorStandingsAsync();

                    var standings = data.MRData.StandingsTable.StandingsLists.First().ConstructorStandings
                        .Select(c => new
                        {
                            Posición = c.position,
                            Equipo = c.Constructor.name,
                            //Nacionalidad = c.Constructor.nationality,
                            Puntos = c.points,
                            Victorias = c.wins
                        }).ToList();

                    var columnaPosicion = new DataGridTemplateColumn
                    {
                        Header = "Posición",
                        Width = 80,
                        CellTemplate = (DataTemplate)this.FindResource("PosicionTemplate")
                    };

                    dataGridDrivers.Columns.Add(columnaPosicion);
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Equipo", Binding = new System.Windows.Data.Binding("Equipo") });
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Nacionalidad", Binding = new System.Windows.Data.Binding("Nacionalidad") });
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Puntos", Binding = new System.Windows.Data.Binding("Puntos") });
                    dataGridDrivers.Columns.Add(new DataGridTextColumn { Header = "Victorias", Binding = new System.Windows.Data.Binding("Victorias") });

                    dataGridDrivers.ItemsSource = standings;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void dataGridDrivers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridDrivers.SelectedItem is null)
                return;

            var tipo = ((ComboBoxItem)TipoClasificacionComboBox.SelectedItem)?.Content?.ToString();

            // Cerrar por defecto
            PanelDetalle.Visibility = Visibility.Collapsed;
            MainGrid.ColumnDefinitions[1].Width = new GridLength(0);

            // Mostrar solo si es piloto
            if (tipo == "Pilotos")
            {
                dynamic piloto = dataGridDrivers.SelectedItem;

                DetalleNombre.Text = piloto.Piloto;
                DetalleEquipo.Text = $"Equipo: {piloto.Equipo}";
                DetalleNacionalidad.Text = $"Nacionalidad: {piloto.Nacionalidad}";
                DetallePuntos.Text = $"Puntos: {piloto.Puntos}";
                DetalleVictorias.Text = $"Victorias: {piloto.Victorias}";

                PanelDetalle.Visibility = Visibility.Visible;
                MainGrid.ColumnDefinitions[1].Width = new GridLength(300);
            }
        }

        private async void TipoClasificacionComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await CargarClasificacionAsync();
        }

        private void CerrarPanel_Click(object sender, RoutedEventArgs e)
        {
            PanelDetalle.Visibility = Visibility.Collapsed;
            MainGrid.ColumnDefinitions[1].Width = new GridLength(0);
            dataGridDrivers.SelectedItem = null;
        }

        public void Volver_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new DashboardView();
        }
    }
}