using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence
{
    class Accidente
    {
        public int Id { get; set; }
        public DateTime Fecha {get; set;}
        public float Coste { get; set; }
        public int IdPiloto { get; set; }
        public int IdCircuito { get; set; }

        public AccidenteManager am { get; set; }

        public Accidente()
        {
            am = new AccidenteManager();
        }

        public Accidente(int id, DateTime fecha, float coste, int idPiloto, int idCircuito)
        {
            this.Id = id;
            this.Fecha = fecha;
            this.Coste = coste;
            this.IdPiloto = idPiloto;
            this.IdCircuito = idCircuito;
            
            am = new AccidenteManager();
        }

        public Accidente(DateTime fecha, float coste, int idPiloto, int idCircuito)
        {
            am = new AccidenteManager();

            this.Id = am.lastId();
            this.Fecha = fecha;
            this.Coste = coste;
            this.IdPiloto = idPiloto;
            this.IdCircuito = idCircuito;
        }

        public List<Accidente> leerAccidentes()
        {
            return am.readAccidentes();
        }

        public void insert()
        {
            am.insertAccidente(this);
        }

        public void update()
        {
            am.updateAccidente(this);
        }

        public void delete()
        {
            am.deleteAccidente(this);
        }
    }
}
