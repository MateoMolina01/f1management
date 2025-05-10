using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class CircuitoManager
    {

        public List<Circuito> ListaCircuitos { get; set; }

        public CircuitoManager()
        {
            ListaCircuitos = new List<Circuito>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idCircuito),0) FROM circuitos");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Circuito> readCircuitos()
        {
            Circuito circuito = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM circuitos");

            foreach (List<object> row in auxList)
            {
                circuito = new Circuito();

                circuito.Id = Convert.ToInt32(row[0]);
                circuito.Nombre = row[1].ToString();
                circuito.IdPais = Convert.ToInt32(row[2]);

                ListaCircuitos.Add(circuito);
            }

            return ListaCircuitos;
        }
        public void insertCircuito(Circuito circuito)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO circuitos (nombre, idPais) VALUES ('{circuito.Nombre}', {circuito.IdPais})";
            broker.modifier(query);
            MessageBox.Show($"Circuito insertado: {circuito.Nombre}");
        }

        public void deleteCircuito(Circuito circuito)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM circuitos WHERE IDCircuito = {circuito.Id}";
            broker.modifier(query);
            MessageBox.Show($"Circuito eliminado: {circuito.Nombre}");
        }

        public void updateCircuito(Circuito circuito)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE circuitos SET nombre = '{circuito.Nombre}', idPais = {circuito.IdPais} WHERE IDCircuito = {circuito.Id}";
            broker.modifier(query);
        }

        //COMPROBAR
        public string getPaisNombre(int idPais)
        {
            string nombre = "";

            List<object> result = DBBroker.obtenerAgente().leer($"SELECT nombre FROM paises WHERE ID = {idPais}");

            foreach (List<object> row in result)
            {
                nombre = row[0].ToString();
            }

            return nombre;
        }
    }
}
