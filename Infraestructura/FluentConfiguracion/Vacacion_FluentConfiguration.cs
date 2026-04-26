using Employees.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infraestructura.FluentConfiguracion
{
    internal class Vacacion_FluentConfiguration : IEntityTypeConfiguration<Vacacion>
    {
        public void Configure(EntityTypeBuilder<Vacacion> builder)
        {


            builder.HasKey(e => e.VacacionId);

            builder.Property(e => e.EstadoAprobacion)
                .HasMaxLength(20)
                .HasDefaultValue("Pendiente");

            // Relación doble con Usuarios
            builder.HasOne(d => d.Solicitante)
                .WithMany(p => p.VacacionesSolicitadas)
                .HasForeignKey(d => d.SolicitanteId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Aprobador)
                .WithMany(p => p.VacacionesAprobadas)
                .HasForeignKey(d => d.AprobadorId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}