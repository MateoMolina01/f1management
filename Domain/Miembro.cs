using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Persistence.Manages
{
    class Miembro
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
        public int IdMonoplaza { get; set; }
        public int IdRol { get; set; }

        public MiembroManager mm { get; set; }

        public Miembro()
        {
            mm = new MiembroManager();
        }

        public Miembro(int id, string nombre, int idUsuario, int idMonoplaza, int idRol)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.IdUsuario = idUsuario;
            this.IdMonoplaza = idMonoplaza;
            this.IdRol = idRol;

            mm = new MiembroManager();
        }

        public Miembro(string nombre, int idUsuario, int idMonoplaza, int idRol)
        {
            mm = new MiembroManager();

            Id = mm.lastId();
            this.Nombre = nombre;
            this.IdUsuario = idUsuario;
            this.IdMonoplaza = idMonoplaza;
            this.IdRol = idRol;
        }

        public List<Miembro> readMiembros()
        {
            return mm.readMiembros();
        }

        public void insert()
        {
            mm.insertMiembro(this);
        }

        public void update()
        {
            mm.updateMiembro(this);
        }

        public void delete()
        {
            mm.deleteMiembro(this);
        }
    }
}
