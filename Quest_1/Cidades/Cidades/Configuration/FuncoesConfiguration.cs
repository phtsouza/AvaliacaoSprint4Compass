using AtividadeCidade.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AtividadeCidades.Configuration
{
    // Classe para configurar as funcoes 
    public class FuncoesConfiguration : IEntityTypeConfiguration<Funcoes>
    {
        public void Configure(EntityTypeBuilder<Funcoes> builder)
        {
            builder.ToTable("Funcoes");

            builder
                .Property(f => f.Id)
                .HasColumnName("Id")
                .HasColumnType("Guid")
                .IsRequired();

            builder
                .Property(f => f.Descricao)
                .HasColumnName("Descricao")
                .HasColumnType("varchar(max)");

            builder
                .Property(f => f.NivelAcesso)
                .HasColumnName("NivelAcesso")
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property<DateTime>("UltimaAtualizacao");
        }
    }
}
