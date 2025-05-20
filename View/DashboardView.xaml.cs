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
    /// Lógica de interacción para DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        private List<DashboardOption> opciones;
        private int indiceActual = 0;

        public DashboardView()
        {
            InitializeComponent();
            InicializarOpciones();
            MostrarOpcionActual();
        }

        private void InicializarOpciones()
        {

            if (App.UsuarioActual != null && App.UsuarioActual.EsAdmin)
            {
                opciones = new List<DashboardOption>
                {
                    new DashboardOption { Titulo = "CARRERAS", Icono = "🏁", Accion = () => Navegar(new CarrerasView()) },
                    new DashboardOption { Titulo = "PIEZAS", Icono = "🧩", Accion = () => Navegar(new PiezasView()) },
                    new DashboardOption { Titulo = "RENDIMIENTO", Icono = "📊", Accion = () => Navegar(new RendimientoView()) },
                    new DashboardOption { Titulo = "MIEMBROS", Icono = "👥", Accion = () => Navegar(new MiembrosView()) },
                    new DashboardOption { Titulo = "PILOTOS", Icono = "🏎️", Accion = () => Navegar(new PilotosView()) },
                    new DashboardOption { Titulo = "ESTADÍSTICAS", Icono = "📈", Accion = () => Navegar(new EstadisticasView()) }
                };
            }
            else
            {
                opciones = new List<DashboardOption>
        {
                    new DashboardOption { Titulo = "CARRERAS", Icono = "🏁", Accion = () => Navegar(new CarrerasView()) },
                    new DashboardOption { Titulo = "PIEZAS", Icono = "🧩", Accion = () => Navegar(new PiezasView()) },
                    new DashboardOption { Titulo = "RENDIMIENTO", Icono = "📊", Accion = () => Navegar(new RendimientoView()) },
                    new DashboardOption { Titulo = "PILOTOS", Icono = "🏎️", Accion = () => Navegar(new PilotosView()) },
                    new DashboardOption { Titulo = "ESTADÍSTICAS", Icono = "📈", Accion = () => Navegar(new EstadisticasView()) }
                };
            }

                
        }

        private void MostrarOpcionActual()
        {
            var actual = opciones[indiceActual];
            IconoText.Text = actual.Icono;
            TituloText.Text = actual.Titulo;
        }

        private void Anterior_Click(object sender, RoutedEventArgs e)
        {
            indiceActual = (indiceActual - 1 + opciones.Count) % opciones.Count;
            MostrarOpcionActual();
        }

        private void Siguiente_Click(object sender, RoutedEventArgs e)
        {
            indiceActual = (indiceActual + 1) % opciones.Count;
            MostrarOpcionActual();
        }

        private void EjecutarOpcion_Click(object sender, RoutedEventArgs e)
        {
            opciones[indiceActual].Accion.Invoke();
        }

        private void Navegar(UserControl vista)
        {
            ((MainWindow)Application.Current.MainWindow).MainContent.Content = vista;
        }
    }
}


