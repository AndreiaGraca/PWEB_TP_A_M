﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Models
{
    public class Tecnicos
    {
        public int Id { get; set; }

        //public int TecnicosId { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }

        public int IdAgendamento { get; set; }

        public virtual Agendamento Agendamento { get; set; }
    }
}
