using Microsoft.EntityFrameworkCore;
using AtividadeCidade.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AtividadeCidades.Configuration
{
	// Classe para configurar as Cidades
    public class CidadesConfiguration : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder.ToTable("Cidades");

			builder
				.Property(c => c.Id)
				.HasColumnName("Id")
				.HasColumnType("guid")
				.IsRequired();

			builder
				.Property(c => c.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)");

			builder
				.Property(c => c.Populacao)
				.HasColumnName("Populacao")
				.HasColumnType("int")
				.IsRequired();

			builder
				.Property(c => c.TaxaCriminalidade)
				.HasColumnName("TaxaCriminalidade")
				.HasColumnType("float")
				.IsRequired();

			builder
				.Property(c => c.ImpostoSobreProduto)
				.HasColumnName("ImpostoSobreProduto")
				.HasColumnType("float")
				.IsRequired();

			builder
				.Property(c => c.EstadoCalamidade)
				.HasColumnName("EstadoCalamidade")
				.HasColumnType("bit")
				.IsRequired();

			builder
				.Property<DateTime>("UltimaAtualizacao");

		}
    }
}
