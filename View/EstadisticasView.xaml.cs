using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;
using f1management.Persistence;
using f1management.Persistence.Manages;
using System.Security.Cryptography.X509Certificates;

namespace f1management.View
{
    public partial class EstadisticasView : UserControl
    {
        public SeriesCollection SeriesPuntos { get; set; }
        public SeriesCollection SeriesCarreras { get; set; }
        public List<string> LabelsPilotos { get; set; }
        public Func<double, string> Formatter { get; set; }

        public EstadisticasView()
        {
            InitializeComponent();
            CargarDatosGraficos();
            DataContext = this;
        }

        private void CargarDatosGraficos()
        {
            // Obtener pilotos y sus puntos totales
            PilotoManager pm = new PilotoManager();
            var pilotos = pm.readPilotos();

            PilotoCircuitoManager pcm = new PilotoCircuitoManager();
            var resultados = pcm.ReadAll();

            // Gráfico de barras: puntos por piloto
            LabelsPilotos = new List<string>();
            ChartValues<double> puntos = new ChartValues<double>();

            foreach (var piloto in pilotos)
            {
                var totalPuntos = resultados
                    .Where(r => r.IdPiloto == piloto.Id)
                    .Sum(r => r.Puntos);

                LabelsPilotos.Add(piloto.Nombre);
                puntos.Add(totalPuntos);
            }

            SeriesPuntos = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Puntos",
                    Values = puntos
                }
            };

            Formatter = value => value.ToString("N0");

            // Gráfico de tarta: victorias por país
            // Supongamos que el piloto con más puntos en un circuito es el "ganador"

            // Obtener países (necesitamos nombres)
            PaisManager paisManager = new PaisManager();
            var paises = paisManager.readPaises();
            Dictionary<int, string> nombrePaises = paises.ToDictionary(p => p.Id, p => p.Nombre);

            Dictionary<string, int> victoriasPorPais = new Dictionary<string, int>();

            var circuitosAgrupados = resultados.GroupBy(r => r.IdCircuito);

            foreach (var grupo in circuitosAgrupados)
            {
                var ganador = grupo.OrderByDescending(r => r.Puntos).FirstOrDefault();
                var pilotoGanador = pilotos.FirstOrDefault(p => p.Id == ganador.IdPiloto);
                if (pilotoGanador != null)
                {
                    string pais = nombrePaises.ContainsKey(pilotoGanador.IdPais) ? nombrePaises[pilotoGanador.IdPais] : "Desconocido";
                    if (!victoriasPorPais.ContainsKey(pais))
                        victoriasPorPais[pais] = 0;
                    victoriasPorPais[pais]++;
                }
            }

            SeriesCarreras = new SeriesCollection
            {
                new RowSeries
                {
                    Title = "Carreras disputadas",
                    Values = new ChartValues<int>(
                    pilotos.Select(p => resultados.Count(r => r.IdPiloto == p.Id))
                    )
                }
            };
        }

        public void Volver_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = new DashboardView();
        }
    }
    }