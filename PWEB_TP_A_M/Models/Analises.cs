using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Models
{
    public class Analises
    {
        public int Id { get; set; }

        public string TipoAnalise { get; set; }
        public string NomeAnalise { get; set; }

        public string Resultados { get; set; }
    }
}
