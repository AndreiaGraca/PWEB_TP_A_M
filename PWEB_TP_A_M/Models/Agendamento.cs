using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Models
{
    public class Agendamento
    {
        public int Id { get; set; }

        public string TipoAgendamentoNo { get; set; }
        public int Dia { get; }

        [Display(Name = "Laboratório")]
        public int CentroId { get; set; }
        public virtual CentroTeste Centros { get; set; }
        [Display(Name = "Teste")]
        public int TestesId { get; set; }
        public virtual Testes Testes { get; set; }
        [Display(Name = "Analise")]
        public int AnaliseId { get; set; }
        public virtual Analises Analises { get; set; }


    }
}
