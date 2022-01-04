using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Models
{
    public class CentroTeste
    {
        public int Id { get; set; }
        public String Nome { get; set; }
        public int Vagas { get; set; }
    
        public String Localidade { get; set; }
        public String Horario { get; set; }
        public int LimTestes { get; set; }
        public String Tecnico { get; set; }

        public int AnalisesId { get; set; }
        public virtual Analises Analises { get; set; }

        public String LocalidadeId { get; set; }
        public virtual Localizacoes Localizacoes { get; set; }


        public String TecnicosId { get; set; }
        public virtual Tecnicos Tecnicos { get; set; }
    }
}
