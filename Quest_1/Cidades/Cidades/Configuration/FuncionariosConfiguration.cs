using AtividadeCidade.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AtividadeCidades.Configuration
{
	// Classe para configurar os funcionários
    public class FuncionariosConfiguration : IEntityTypeConfiguration<Funcionarios>
    {
        public void Configure(EntityTypeBuilder<Funcionarios> builder)
        {
			builder.ToTable("Funcionarios");

			builder
				.Property(f => f.Nome)
				.HasColumnName("Nome")
				.HasColumnType("varchar(max)");

			builder
				.Property(f => f.DataNascimento)
				.HasColumnName("DataNascimento")
				.HasColumnType("datatime2(7)")
				.IsRequired();

			builder
				.Property<Guid>("CidadeId")
				.IsRequired();

			builder
				.HasOne(f => f.Cidade)
				.WithMany(c => c._funcionarios)
				.HasForeignKey("CidadeId");

			builder
				.Property<DateTime>("UltimaAtualizacao");
		}
    }
}
