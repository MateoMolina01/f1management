using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence.Manages
{
    class MiembroManager
    {

        public List<Miembro> ListaMiembros { get; set; }

        public MiembroManager()
        {
            ListaMiembros = new List<Miembro>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idMiembro),0) FROM miembros");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Miembro> readMiembros()
        {
            Miembro miembro = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM miembros");
            foreach (List<object> row in auxList)
            {
                miembro = new Miembro();
                miembro.Id = Convert.ToInt32(row[0]);
                miembro.Nombre = row[1].ToString();
                miembro.IdUsuario = Convert.ToInt32(row[2]);
                miembro.IdMonoplaza = Convert.ToInt32(row[3]);
                miembro.IdRol = Convert.ToInt32(row[4]);
                ListaMiembros.Add(miembro);
            }
            return ListaMiembros;
        }

        public void insertMiembro(Miembro miembro)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO miembros (nombre, idUsuario, idMonoplaza, idRol) VALUES ('{miembro.Nombre}', {miembro.IdUsuario}, {miembro.IdMonoplaza}, {miembro.IdRol})";
            broker.modifier(query);
        }

        public void updateMiembro(Miembro miembro)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE miembros SET nombre = '{miembro.Nombre}', idUsuario = {miembro.IdUsuario}, idMonoplaza = {miembro.IdMonoplaza}, idRol = {miembro.IdRol} WHERE idMiembros = {miembro.Id}";
            broker.modifier(query);
        }

        public void deleteMiembro(Miembro miembro)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM miembros WHERE idMiembros = {miembro.Id}";
            broker.modifier(query);
        }

        public Miembro getMiembroById(int id)
        {
            Miembro miembro = null;
            List<object> auxList = DBBroker.obtenerAgente().leer($"SELECT * FROM miembros WHERE idMiembros = {id}");
            foreach (List<object> row in auxList)
            {
                miembro = new Miembro();
                miembro.Id = Convert.ToInt32(row[0]);
                miembro.Nombre = row[1].ToString();
                miembro.IdUsuario = Convert.ToInt32(row[2]);
                miembro.IdMonoplaza = Convert.ToInt32(row[3]);
                miembro.IdRol = Convert.ToInt32(row[4]);
            }
            return miembro;
        }

        public List<Miembro> getMiembrosByMonoplaza(int idMonoplaza)
        {
            Miembro miembro = null;
            List<object> auxList = DBBroker.obtenerAgente().leer($"SELECT * FROM miembros WHERE idMonoplaza = {idMonoplaza}");
            foreach (List<object> row in auxList)
            {
                miembro = new Miembro();
                miembro.Id = Convert.ToInt32(row[0]);
                miembro.Nombre = row[1].ToString();
                miembro.IdUsuario = Convert.ToInt32(row[2]);
                miembro.IdMonoplaza = Convert.ToInt32(row[3]);
                miembro.IdRol = Convert.ToInt32(row[4]);
                ListaMiembros.Add(miembro);
            }
            return ListaMiembros;
        }

    }
}
