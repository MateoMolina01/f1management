using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.View
{
    public class DashboardOption
    {
        public string Titulo { get; set; }
        public string Icono { get; set; }
        public Action Accion { get; set; }
    }
}
