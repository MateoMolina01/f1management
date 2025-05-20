using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence
{
    class Pais
    {

        public int Id { get; set; }
        public string Nombre { get; set; }

        public PaisManager pm { get; set; }

        public Pais()
        {
            pm = new PaisManager();
        }

        public Pais(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;

            pm = new PaisManager();
        }

        public Pais(string nombre)
        {
            pm = new PaisManager();

            Id = pm.lastId();
            this.Nombre = nombre;
        }

        public List<Pais> leerPaises()
        {
            return pm.readPaises();
        }

        public void insert()
        {
            pm.insertPais(this);
        }

        public void update()
        {
            pm.updatePais(this);
        }

        public void delete()
        {
            pm.deletePais(this);
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
