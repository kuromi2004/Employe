  using Employees.Dominio.Entidades;


    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Employees.Infraestructura.FluentConfiguracion
{


    public class Periodo_FluentConfiguration : IEntityTypeConfiguration<Periodo>
    {
        public void Configure(EntityTypeBuilder<Periodo> builder)
        {
            builder.ToTable("Periodos");
            builder.HasKey(e => e.PeriodoId);

            builder.Property(e => e.Estado)
                .HasMaxLength(20)
                .IsRequired();

            builder.HasMany(e => e.RegistrosJornada)
                .WithOne(r => r.Periodo)
                .HasForeignKey(r => r.PeriodoId);
        }
    }
}

