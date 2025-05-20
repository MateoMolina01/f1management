using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence
{
    class Rol
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public RolManager rm { get; set; }

        public Rol()
        {
            rm = new RolManager();
        }

        public Rol(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;

            rm = new RolManager();
        }

        public Rol(string nombre)
        {
            rm = new RolManager();

            Id = rm.lastId();
            this.Nombre = nombre;
        }

        public List<Rol> readRoles()
        {
            return rm.readRoles();
        }

        public void insert()
        {
            rm.insertRol(this);
        }

        public void delete()
        {
            rm.deleteRol(this);
        }

        public void update()
        {
            rm.updateRol(this);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
