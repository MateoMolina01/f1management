using f1management.Persistence.Manages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence
{
    class Pieza
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaMontaje { get; set; }
        public float Precio { get; set; }
        public bool Montada { get; set; }
        public int IdProveedor { get; set; }
        public int IdMonoplaza { get; set; }

        public PiezaManager pm { get; set; }

        public Pieza()
        {
            pm = new PiezaManager();
        }

        public Pieza(int id, string descripcion, DateTime fechaMontaje, float precio, bool montada, int idProveedor, int idMonoplaza)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.FechaMontaje = fechaMontaje;
            this.Precio = precio;
            this.Montada = montada;
            this.IdProveedor = idProveedor;
            this.IdMonoplaza = idMonoplaza;

            pm = new PiezaManager();
        }

        public Pieza(string descripcion, DateTime fechaMontaje, float precio, bool montada, int idProveedor, int idMonoplaza)
        {
            pm = new PiezaManager();

            Id = pm.lastId();
            this.Descripcion = descripcion;
            this.FechaMontaje = fechaMontaje;
            this.Precio = precio;
            this.Montada = montada;
            this.IdProveedor = idProveedor;
            this.IdMonoplaza = idMonoplaza;
        }

        public List<Pieza> readPiezas()
        {
            return pm.readPiezas();
        }

        public void insert()
        {
            pm.insertPieza(this);
        }

        public void update()
        {
            pm.updatePieza(this);
        }

        public void delete()
        {
            pm.deletePieza(this);
        }
    }
}
