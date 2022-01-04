using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Models
{
    public class Gestores
    {
        public int Id { get; set; }
        public String Centro { get; set; }

        public String CentroId { get; set; }
        public virtual CentroTeste CentroTeste { get; set; }
    }
}
