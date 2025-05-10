using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence.Manages
{
    class Circuito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdPais { get; set; }

        public CircuitoManager cm { get; set; }

        public Circuito()
        {
            cm = new CircuitoManager();
        }

        public Circuito(int id, string nombre, int idPais)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.IdPais = idPais;

            cm = new CircuitoManager();
        }

        public Circuito(string nombre, int idPais)
        {
            cm = new CircuitoManager();

            this.Id = cm.lastId();
            this.Nombre = nombre;
            this.IdPais = idPais;
        }

        public List<Circuito> leerCircuitos()
        {
            return cm.readCircuitos();
        }

        public void insert()
        {
            cm.insertCircuito(this);
        }

        public void delete()
        {
            cm.deleteCircuito(this);
        }

        public void update()
        {
            cm.updateCircuito(this);
        }

        public string getPaisNombre(int idPais)
        {
            return cm.getPaisNombre(idPais);
        }
    }

}
