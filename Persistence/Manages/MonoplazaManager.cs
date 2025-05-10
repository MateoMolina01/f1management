using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class MonoplazaManager
    {

        public List<Monoplaza> ListaMonoplazas { get; set; }

        public MonoplazaManager()
        {
            ListaMonoplazas = new List<Monoplaza>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idMonoplaza),0) FROM monoplazas");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Monoplaza> readMonoplazas()
        {
            Monoplaza monoplaza = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM monoplazas");

            foreach (List<object> row in auxList)
            {
                monoplaza = new Monoplaza();

                monoplaza.Id = Convert.ToInt32(row[0]);
                monoplaza.Peso = Convert.ToSingle(row[1]);
                monoplaza.Motor = row[2].ToString();
                monoplaza.Temporada = Convert.ToInt32(row[3]);
                monoplaza.IdPiloto = Convert.ToInt32(row[4]);

                ListaMonoplazas.Add(monoplaza);
            }

            return ListaMonoplazas;
        }

        public void insertMonoplaza(Monoplaza monoplaza)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO monoplazas (peso, motor, temporada, idPiloto) VALUES ({monoplaza.Peso}, '{monoplaza.Motor}', {monoplaza.Temporada}, {monoplaza.IdPiloto})";
            broker.modifier(query);
            MessageBox.Show($"Monoplaza insertado: Motor {monoplaza.Motor}");
        }

        public void deleteMonoplaza(Monoplaza monoplaza)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM monoplazas WHERE IDMonoplaza = {monoplaza.Id}";
            broker.modifier(query);
            MessageBox.Show($"Monoplaza eliminado: ID {monoplaza.Id}");
        }

        public void updateMonoplaza(Monoplaza monoplaza)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE monoplazas SET peso = {monoplaza.Peso}, motor = '{monoplaza.Motor}', temporada = {monoplaza.Temporada}, idPiloto = {monoplaza.IdPiloto} WHERE IDMonoplaza = {monoplaza.Id}";
            broker.modifier(query);
        }

        public string getPilotoNombre(int idPiloto)
        {
            string nombre = "";

            List<object> result = DBBroker.obtenerAgente().leer($"SELECT nombre FROM pilotos WHERE ID = {idPiloto}");

            foreach (List<object> row in result)
            {
                nombre = row[0].ToString();
            }

            return nombre;
        }
    }
}
