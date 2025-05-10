using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class PiezaManager
    {

        public List<Pieza> ListaPiezas { get; set; }

        public PiezaManager()
        {
            ListaPiezas = new List<Pieza>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idPieza),0) FROM piezas");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Pieza> readPiezas()
        {
            Pieza pieza = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM piezas");

            foreach (List<object> row in auxList)
            {
                pieza = new Pieza();

                pieza.Id = Convert.ToInt32(row[0]);
                pieza.Descripcion = row[1].ToString();
                pieza.FechaMontaje = Convert.ToDateTime(row[2]);
                pieza.Precio = Convert.ToSingle(row[3]);
                pieza.Montada = Convert.ToInt32(row[4]) == 1;
                pieza.IdProveedor = Convert.ToInt32(row[5]);
                pieza.IdMonoplaza = Convert.ToInt32(row[6]);

                ListaPiezas.Add(pieza);
            }

            return ListaPiezas;
        }

        public void insertPieza(Pieza pieza)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO piezas (descripcion, fechaMontaje, precio, montada, idProveedor, idMonoplaza) " +
                           $"VALUES ('{pieza.Descripcion}', '{pieza.FechaMontaje:yyyy-MM-dd}', {pieza.Precio}, {(pieza.Montada ? 1 : 0)}, {pieza.IdProveedor}, {pieza.IdMonoplaza})";
            broker.modifier(query);
            MessageBox.Show($"Pieza insertada: {pieza.Descripcion}");
        }

        public void deletePieza(Pieza pieza)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM piezas WHERE idPieza = {pieza.Id}";
            broker.modifier(query);
            MessageBox.Show($"Pieza eliminada: {pieza.Descripcion}");
        }

        public void updatePieza(Pieza pieza)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE piezas SET descripcion = '{pieza.Descripcion}', fechaMontaje = '{pieza.FechaMontaje:yyyy-MM-dd}', precio = {pieza.Precio}, " +
                           $"montada = {(pieza.Montada ? 1 : 0)}, idProveedor = {pieza.IdProveedor}, idMonoplaza = {pieza.IdMonoplaza} WHERE idPieza = {pieza.Id}";
            broker.modifier(query);
        }
    }
}
