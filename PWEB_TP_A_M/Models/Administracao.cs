using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Models
{
    public class Administracao
    {
        public int Id { get; set; }
        public String Laboratorios { get; set;}

        public int CentrosTesteId { get; set; }
        public virtual CentroTeste CentrosTeste { get; set; }

        public int ClientesId { get; set; }
        public virtual Clientes Clientes { get; set; }
    }
}
