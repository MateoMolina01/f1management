using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence.Manages
{
    class Monoplaza
    {

        public int Id { get; set; }
        public float Peso { get; set; }
        public string Motor { get; set; }
        public int Temporada { get; set; }
        public int IdPiloto { get; set; }

        public MonoplazaManager mm { get; set; }

        public Monoplaza()
        {
            mm = new MonoplazaManager();
        }

        public Monoplaza(int id, float peso, string motor, int temporada, int idPiloto)
        {
            this.Id = id;
            this.Peso = peso;
            this.Motor = motor;
            this.Temporada = temporada;
            this.IdPiloto = idPiloto;

            mm = new MonoplazaManager();
        }

        public Monoplaza(float peso, string motor, int temporada, int idPiloto)
        {
            mm = new MonoplazaManager();

            Id = mm.lastId();
            this.Motor = motor;
            this.Temporada = temporada;
            this.IdPiloto = idPiloto;
        }

        public List<Monoplaza> leerMonoplazas()
        {
            return mm.readMonoplazas();
        }

        public void insert()
        {
            mm.insertMonoplaza(this);
        }

        public void delete()
        {
            mm.deleteMonoplaza(this);
        }

        public void update()
        {
            mm.updateMonoplaza(this);
        }
    }
}
