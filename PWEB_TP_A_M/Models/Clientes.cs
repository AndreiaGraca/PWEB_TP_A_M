using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Models
{
    public class Clientes
    {
        public int Id { get; set; }

        //public int ClientesId { get; set;}
        public string Nome { get; set; }
        public int BI { get; set; }
        public int NIF { get; set; }
        public int IdAgendamento { get; set; }
        public virtual Agendamento Agendamento { get; set; }
    }
}
