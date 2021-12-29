using AtividadeCidades.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeCidades.Configuration
{
    // Classe para configurar a view de funcionários
    public class VW_ALL_FUNCIONARIOS_CONFIGURATION : IEntityTypeConfiguration<VW_ALL_FUNCIONARIOS>
    {
        public void Configure(EntityTypeBuilder<VW_ALL_FUNCIONARIOS> builder)
        {
            builder.ToTable("VW_ALL_FUNCIONARIOS");

            builder
                .Property(v => v.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar(max)")
                .IsRequired();

            builder
                .Property(v => v.DataNascimento)
                .HasColumnName("DataNascimento")
                .HasColumnType("datetime2(7)");

            builder
                .Property(v => v.CidadeId)
                .HasColumnName("CidadeId")
                .HasColumnType("Guid");

            builder
                .Property(v => v.UltimaAtualizacao)
                .HasColumnName("UltimaAtualizacao")
                .HasColumnType("datetime2(7)");
        }
    }
}
