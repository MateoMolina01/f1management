using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace f1management.Domain.API.Constructors
{
    public class ConstructorStanding
    {
        public string position { get; set; }
        public string points { get; set; }
        public string wins { get; set; }
        public Constructor Constructor { get; set; }
    }
}
