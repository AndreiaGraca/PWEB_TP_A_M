using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Models
{
    public class Testes
    {
        public int Id { get; set; }


        //public int TesteId { get; set; }
        public string TipoTeste { get; set; }
        public string NomeTeste { get; set; }

        public int Resultado { get; set; }
    }
}
