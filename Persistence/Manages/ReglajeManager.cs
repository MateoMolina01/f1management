using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class ReglajesManager
    {

        public List<Reglaje> ListaReglajes { get; set; }

        public ReglajesManager()
        {
            ListaReglajes = new List<Reglaje>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idReglaje),0) FROM reglajes");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Reglaje> readReglajes()
        {
            Reglaje reglaje = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM reglajes");

            foreach (List<object> row in auxList)
            {
                reglaje = new Reglaje();

                reglaje.Id = Convert.ToInt32(row[0]);
                reglaje.CargaAero = Convert.ToSingle(row[1]);
                reglaje.AlturaSuelo = Convert.ToSingle(row[2]);
                reglaje.Alineacion = Convert.ToSingle(row[3]);
                reglaje.ConfiguracionFrenos = Convert.ToSingle(row[4]);
                reglaje.FechaMontaje = Convert.ToDateTime(row[5]);
                reglaje.IdMonoplaza = Convert.ToInt32(row[6]);

                ListaReglajes.Add(reglaje);
            }

            return ListaReglajes;
        }
        public void insertReglaje(Reglaje reglaje)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO reglajes (cargaAerodinamica, alturaSuelo, alineacion, configuracionFrenos, fechaAplicacion, idMonoplaza) " +
                           $"VALUES ({reglaje.CargaAero}, {reglaje.AlturaSuelo}, {reglaje.Alineacion}, {reglaje.ConfiguracionFrenos}, " +
                           $"'{reglaje.FechaMontaje:yyyy-MM-dd}', {reglaje.IdMonoplaza})";
            broker.modifier(query);
            MessageBox.Show("Reglaje insertado correctamente.");
        }

        public void deleteReglaje(Reglaje reglaje)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM reglajes WHERE idReglaje = {reglaje.Id}";
            broker.modifier(query);
            MessageBox.Show("Reglaje eliminado correctamente.");
        }

        public void updateReglaje(Reglaje reglaje)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE reglajes SET cargaAerodinamica = {reglaje.CargaAero}, alturaSuelo = {reglaje.AlturaSuelo}, " +
                           $"alineacion = {reglaje.Alineacion}, configuracionFrenos = {reglaje.ConfiguracionFrenos}, " +
                           $"fechaAplicacion = '{reglaje.FechaMontaje:yyyy-MM-dd}', idMonoplaza = {reglaje.IdMonoplaza} " +
                           $"WHERE idReglaje = {reglaje.Id}";
            broker.modifier(query);
        }
    }
}
