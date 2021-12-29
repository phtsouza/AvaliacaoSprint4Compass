using AtividadeCidade.Models;
using AtividadeCidades.Configuration;
using AtividadeCidades.Procedures;
using AtividadeCidades.Views;
using Microsoft.EntityFrameworkCore;

namespace AtividadeCidades.Contexts
{
    public class CidadesContext : DbContext
    {
        public DbSet<Cidade> _cidades { get; set; }
        public DbSet<Funcionarios> _funcionarios { get; set; }
        public DbSet<Funcoes> _funcoes { get; set; }
        public DbSet<PrefeitosAtuais> _prefeitosAtuais { get; set; }
        public DbSet<FuncoesFuncionarios> _funcoesFuncionarios { get; set; }
        public DbSet<VW_ALL_FUNCIONARIOS> _VWALLFUNCIONARIOS { get; set; }
        public DbSet<SP_ADD_CIDADE> _SPADDCIDADES { get; set; }

        /*
         * Método que define a base de dados
         * Para rodar o programa é necessário rodar o script localizado na pasta Scripts
        */
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Cidades;Trusted_connection=true");
        }

        // Método que aplica as configurações
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CidadesConfiguration());
            modelBuilder.ApplyConfiguration(new FuncionariosConfiguration());
            modelBuilder.ApplyConfiguration(new FuncoesConfiguration());
            modelBuilder.ApplyConfiguration(new PrefeitosAtuaisConfiguration());
            modelBuilder.ApplyConfiguration(new FuncoesFuncionariosConfiguration());
            modelBuilder.ApplyConfiguration(new VW_ALL_FUNCIONARIOS_CONFIGURATION());
        }
    }
}
