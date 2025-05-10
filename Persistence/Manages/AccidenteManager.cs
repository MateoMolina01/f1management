using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class AccidenteManager
    {

        public List<Accidente> ListaAccidentes { get; set; }

        public AccidenteManager()
        {
            ListaAccidentes = new List<Accidente>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idAccidente),0) FROM accidentes");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Accidente> readAccidentes()
        {
            Accidente accidente = null;
            List<object> auxList;
            auxList = DBBroker.obtenerAgente().leer("SELECT * FROM Accidente");

            foreach (List<object> row in auxList)
            {
                accidente = new Accidente();

                accidente.Id = Convert.ToInt32(row[0]);
                accidente.Fecha = Convert.ToDateTime(row[1]);
                accidente.Coste = Convert.ToSingle(row[2]);
                accidente.IdPiloto = Convert.ToInt32(row[3]);
                accidente.IdCircuito = Convert.ToInt32(row[4]);

                ListaAccidentes.Add(accidente);
            }

            return ListaAccidentes;
        }

        public void insertAccidente(Accidente accidente)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO Accidente (fecha, coste, idPiloto, idCircuito) VALUES " +
                           $"('{accidente.Fecha:yyyy-MM-dd}', {accidente.Coste}, {accidente.IdPiloto}, {accidente.IdCircuito})";
            broker.modifier(query);
            MessageBox.Show($"Accidente insertado: Piloto {accidente.IdPiloto}, Circuito {accidente.IdCircuito}");
        }

        public void deleteAccidente(Accidente accidente)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM Accidente WHERE idAccidente = {accidente.Id}";
            broker.modifier(query);
            MessageBox.Show($"Accidente eliminado: ID {accidente.Id}");
        }

        public void updateAccidente(Accidente accidente)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE Accidente SET fecha = '{accidente.Fecha:yyyy-MM-dd}', coste = {accidente.Coste}, " +
                           $"idPiloto = {accidente.IdPiloto}, idCircuito = {accidente.IdCircuito} " +
                           $"WHERE idAccidente = {accidente.Id}";
            broker.modifier(query);
            MessageBox.Show($"Accidente actualizado: ID {accidente.Id}");
        }
    }
}