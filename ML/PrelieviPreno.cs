using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class PrelieviPreno
    {
        public int IdPaziente { get; set; }

        public string DataOraPrelievo { get; set; }

        public List<object> PrelieviPrenos { get; set; }
    }
}