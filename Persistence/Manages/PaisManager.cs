using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class PaisManager
    {
        public List<Pais> ListaPaises { get; set; }

        public PaisManager()
        {
            ListaPaises = new List<Pais>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idPais),0) FROM paises");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Pais> readPaises()
        {
            Pais pais = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM paises");

            foreach (List<object> row in auxList)
            {
                pais = new Pais();

                pais.Id = Convert.ToInt32(row[0]);
                pais.Nombre = row[1].ToString();

                ListaPaises.Add(pais);
            }

            return ListaPaises;
        }

        public void insertPais(Pais pais)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO paises (nombre) VALUES ('{pais.Nombre}')";
            broker.modifier(query);
            MessageBox.Show($"País insertado: {pais.Nombre}");
        }

        public void deletePais(Pais pais)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM paises WHERE idPais = {pais.Id}";
            broker.modifier(query);
            MessageBox.Show($"País eliminado: {pais.Nombre}");
        }

        public void updatePais(Pais pais)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE paises SET nombre = '{pais.Nombre}' WHERE idPais = {pais.Id}";
            broker.modifier(query);
        }
    }
}
