using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace f1management.Persistence.Manages
{
    class ProveedorManager
    {
        
        public List<Proveedor> ListaProveedores { get; set; }

        public ProveedorManager()
        {
            ListaProveedores = new List<Proveedor>();
        }

        /// <summary>
        /// Metodo que obtiene el ultimo id de la base de datos
        /// </summary>
        /// <returns>lastId: el ultimo id de la base de datos</returns>
        public int lastId()
        {
            int lastId = 0;

            List<object> result = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idProveedor),0) FROM proveedores");

            foreach (List<object> row in result)
            {
                lastId = Convert.ToInt32(row[0]) + 1;
            }

            return lastId;
        }

        public List<Proveedor> readProveedores()
        {
            Proveedor proveedor = null;
            List<object> auxList = DBBroker.obtenerAgente().leer("SELECT * FROM proveedores");

            foreach (List<object> row in auxList)
            {
                proveedor = new Proveedor();

                proveedor.Id = Convert.ToInt32(row[0]);
                proveedor.Nombre = row[1].ToString();
                proveedor.Contacto = row[2].ToString();
                proveedor.IdPais = Convert.ToInt32(row[3]);

                ListaProveedores.Add(proveedor);
            }

            return ListaProveedores;
        }


        public void insertProveedor(Proveedor proveedor)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"INSERT INTO proveedores (nombre, contacto, idPais) " +
                           $"VALUES ('{proveedor.Nombre}', '{proveedor.Contacto}', {proveedor.IdPais})";
            broker.modifier(query);
            MessageBox.Show($"Proveedor insertado: {proveedor.Nombre}");
        }

        public void deleteProveedor(Proveedor proveedor)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"DELETE FROM proveedores WHERE idProveedor = {proveedor.Id}";
            broker.modifier(query);
            MessageBox.Show($"Proveedor eliminado: {proveedor.Nombre}");
        }

        public void updateProveedor(Proveedor proveedor)
        {
            DBBroker broker = DBBroker.obtenerAgente();
            string query = $"UPDATE proveedores SET nombre = '{proveedor.Nombre}', contacto = '{proveedor.Contacto}', idPais = {proveedor.IdPais} " +
                           $"WHERE idProveedor = {proveedor.Id}";
            broker.modifier(query);
        }
    }
}