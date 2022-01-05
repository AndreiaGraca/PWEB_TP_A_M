using Microsoft.EntityFrameworkCore;
using PWEB_TP_A_M.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PWEB_TP_A_M.Data
{
    public class TpCodeFirstDbContext : DbContext
    {
        public TpCodeFirstDbContext(DbContextOptions<TpCodeFirstDbContext>options) : base(options)
        {

        }

        public DbSet<CentroTeste> CentroTeste { get; set; }
        public DbSet<Administracao> Administracao { get; set; }
        public DbSet<Gestores> Gestores { get; set; }
        public DbSet<Localizacoes> Localizacoes { get; set; }
        public DbSet<Tecnicos> Tecnicos { get; set; }
        public DbSet<PWEB_TP_A_M.Models.Analises> Analises { get; set; }
        public DbSet<PWEB_TP_A_M.Models.Agendamento> Agendamento { get; set; }
        public DbSet<PWEB_TP_A_M.Models.Clientes> Clientes { get; set; }
        public DbSet<PWEB_TP_A_M.Models.Testes> Testes { get; set; }
    }
}
