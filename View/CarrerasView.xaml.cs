using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows;
using System.Windows.Controls;

namespace f1management.View
{
    public partial class CarrerasView : UserControl
    {
        public CarrerasView()
        {
            InitializeComponent();
            CargarCarreras(); // Al iniciar, carga la lista de carreras
        }

        // Método para cargar las carreras en el ListBox
        private void CargarCarreras()
        {
            // Aquí cargarás las carreras desde la base de datos
            // Por ejemplo:
            // var carreras = CarreraManager.ObtenerTodas();
            // listaCarreras.ItemsSource = carreras;

            // Por ahora, lo dejamos vacío o con comentario.
        }

        // Evento cuando se selecciona una carrera
        private void listaCarreras_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //if (listaCarreras.SelectedItem == null)
                return;

            // Supongamos que Carrera es una clase con ID o nombre
            // var carreraSeleccionada = (Carrera)listaCarreras.SelectedItem;

            // Aquí deberías consultar la puntuación y posición de ambos pilotos en esa carrera
            // Ejemplo:
            // var resultadoPiloto1 = ResultadosManager.ObtenerPorCarreraYPiloto(carreraSeleccionada.Id, piloto1.Id);
            // var resultadoPiloto2 = ResultadosManager.ObtenerPorCarreraYPiloto(carreraSeleccionada.Id, piloto2.Id);

            // Y luego actualizar el contenido de los elementos de la UI:
            // piloto1Nombre.Text = piloto1.Nombre;
            // piloto1Dorsal.Text = piloto1.Dorsal.ToString();
            // piloto1Puntuacion.Text = resultadoPiloto1.Puntos.ToString();
            // piloto1Posicion.Text = resultadoPiloto1.Posicion.ToString();

            // piloto2Nombre.Text = piloto2.Nombre;
            // piloto2Dorsal.Text = piloto2.Dorsal.ToString();
            // piloto2Puntuacion.Text = resultadoPiloto2.Puntos.ToString();
            // piloto2Posicion.Text = resultadoPiloto2.Posicion.ToString();
        }
    }
}