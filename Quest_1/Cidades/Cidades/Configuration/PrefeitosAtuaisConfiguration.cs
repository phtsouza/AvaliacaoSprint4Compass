using AtividadeCidade.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AtividadeCidades.Configuration
{
	// Classe para configurar os prefeitos atuais.
    class PrefeitosAtuaisConfiguration : IEntityTypeConfiguration<PrefeitosAtuais>
    {
        public void Configure(EntityTypeBuilder<PrefeitosAtuais> builder)
        {
            builder.ToTable("PrefeitosAtuais");

			builder
				.Property(p => p.Id)
				.HasColumnName("Id")
				.HasColumnType("Guid")
				.IsRequired();

			builder
				.Property(p => p.Nome)
				.HasColumnName("Nome")
				.HasColumnType("nvarchar(MAX)")
				.IsRequired();

			builder
				.Property(p => p.InicioMandato)
				.HasColumnName("InicioMandato")
				.HasColumnType("DateTime2(7)");

			builder
				.Property(p => p.FimMandato)
				.HasColumnName("FimMandato")
				.HasColumnType("Datetime2(7)");

			builder
				.HasOne(p => p.Cidade)
				.WithMany(x => x._prefeitos)
				.IsRequired();
		}
    }
}
