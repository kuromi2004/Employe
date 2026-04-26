using Employees.Dominio.Entidades;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infraestructura.FluentConfiguracion
{
    internal class RegistroJornada_FluentConfiguration : IEntityTypeConfiguration<RegistroJornada>
    {
        public void Configure(EntityTypeBuilder<RegistroJornada> builder)
        {

            builder.ToTable("RegistrosJornada");
            builder.HasKey(e => e.RegistroId);

            builder.Property(e => e.HorasTrabajadas)
                .HasPrecision(4, 2);

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.RegistrosJornada)
                .HasForeignKey(d => d.NumeroEmpleado);
        }
    }
}

