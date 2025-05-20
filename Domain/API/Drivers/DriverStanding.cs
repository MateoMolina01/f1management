using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Domain.API
{
    public class DriverStanding
    {
        public string position { get; set; }
        public string points { get; set; }
        public string wins { get; set; }
        public Driver Driver { get; set; }
        public List<Constructor> Constructors { get; set; }
    }
}
