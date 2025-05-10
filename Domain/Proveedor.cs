using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence
{
    class Proveedor
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contacto { get; set; }
        public int IdPais { get; set; }

        public ProveedorManager pm { get; set; }

        public Proveedor()
        {
            pm = new ProveedorManager();
        }

        public Proveedor(int id, string nombre, string contacto, int idPais)
        {
            Id = id;
            Nombre = nombre;
            Contacto = contacto;
            IdPais = idPais;

            pm = new ProveedorManager();
        }

        public Proveedor(string nombre, string contacto, int idPais)
        {
            pm = new ProveedorManager();

            Id = pm.lastId();
            this.Nombre = nombre;
            this.Contacto = contacto;
            this.IdPais = idPais;
        }

        public void insert()
        {
            pm.insertProveedor(this);
        }

        public void update()
        {
            pm.updateProveedor(this);
        }

        public void delete()
        {
            pm.deleteProveedor(this);
        }

        public List<Proveedor> leerProvedores()
        {
            return pm.readProveedores();
        }
    }
}
