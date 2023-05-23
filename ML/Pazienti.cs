using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Pazienti
    {
        public int IdPaziente { get; set; }

        public string Nome { get; set; }

        public string Cognome { get; set; }

        public string DataNascita { get; set; }

        public PrelieviPreno PrelieviPreno { get; set; }

        public List<object> Pazientis { get; set; }
    }
}