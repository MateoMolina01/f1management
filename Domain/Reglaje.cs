using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence
{
    class Reglaje
    {
        public int Id { get; set; }
        public float CargaAero { get; set; }
        public float AlturaSuelo { get; set; }
        public float Alineacion { get; set; }
        public float ConfiguracionFrenos { get; set; }
        public DateTime FechaMontaje { get; set; }
        public int IdMonoplaza { get; set; }

        public ReglajesManager rm { get; set; }

        public Reglaje()
        {
            rm = new ReglajesManager();
        }

        public Reglaje(int id, float cargaAero, float alturaSuelo, float alineacion, float configuracionFrenos, DateTime fechaMontaje, int idMonoplaza)
        {
            this.Id = id;
            this.CargaAero = cargaAero;
            this.AlturaSuelo = alturaSuelo;
            this.Alineacion = alineacion;
            this.ConfiguracionFrenos = configuracionFrenos;
            this.FechaMontaje = fechaMontaje;
            this.IdMonoplaza = idMonoplaza;

            rm = new ReglajesManager();
        }

        public Reglaje(float cargaAero, float alturaSuelo, float alineacion, float configuracionFrenos, DateTime fechaMontaje, int idMonoplaza)
        {

            rm = new ReglajesManager();

            Id = rm.lastId();
            this.CargaAero = cargaAero;
            this.AlturaSuelo = alturaSuelo;
            this.Alineacion = alineacion;
            this.ConfiguracionFrenos = configuracionFrenos;
            this.FechaMontaje = fechaMontaje;
            this.IdMonoplaza = idMonoplaza;

        }

        public void insert()
        {
            rm.insertReglaje(this);
        }

        public void update()
        {
            rm.updateReglaje(this);
        }

        public void delete()
        {
            rm.deleteReglaje(this);
        }

        public List<Reglaje> leerReglajes()
        {
            return rm.readReglajes();
        }
    }
}
