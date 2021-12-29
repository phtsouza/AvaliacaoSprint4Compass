using AtividadeCidade.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AtividadeCidades.Configuration
{
    // Classe para configurar as funções dos funcionários
    class FuncoesFuncionariosConfiguration : IEntityTypeConfiguration<FuncoesFuncionarios>
    {
        public void Configure(EntityTypeBuilder<FuncoesFuncionarios> builder)
        {
            builder.ToTable("FuncoesFuncionarios");

            builder
                .Property<Guid>("FuncionarioId");

            builder
                .Property<Guid>("FuncaoId");

            builder
                .HasKey("FuncaoId", "FuncionarioId");

            builder
                .HasOne(ff => ff.Funcionario)
                .WithMany(f => f.Funcoes)
                .HasForeignKey("FuncionarioId");

            builder
                .HasOne(ff => ff.Funcao)
                .WithMany(f => f.Funcionarios)
                .HasForeignKey("FuncaoId");
        }
    }
}
