using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class RolManager
    {

        public List <Rol> ListaRoles { get; set; }

        public RolManager()
        {
            ListaRoles = new List<Rol>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idRol),0) FROM roles");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Rol> readRoles()
        {
            Rol rol = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM roles");

            foreach (List<object> row in auxList)
            {
                rol = new Rol();

                rol.Id = Convert.ToInt32(row[0]);
                rol.Nombre = row[1].ToString();

                ListaRoles.Add(rol);
            }

            return ListaRoles;
        }

        public void insertRol(Rol rol)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO roles (nombre) VALUES ('{rol.Nombre}')";
            broker.modifier(query);
            MessageBox.Show("Rol insertado correctamente.");
        }

        public void deleteRol(Rol rol)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM roles WHERE idRol = {rol.Id}";
            broker.modifier(query);
            MessageBox.Show("Rol eliminado correctamente.");
        }

        public void updateRol(Rol rol)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE roles SET nombre = '{rol.Nombre}' WHERE idRol = {rol.Id}";
            broker.modifier(query);
        }
    }
}