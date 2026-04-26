using  Employees.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infraestructura.FluentConfiguracion
{
    internal class Usuario_FluentConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(e => e.NumeroEmpleado);

            // Importante: Indicar que el ID no lo genera la base de datos (lo asignas tú)
            builder.Property(e => e.NumeroEmpleado)
                .ValueGeneratedNever();

            builder.Property(e => e.CorreoElectronico)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(e => e.CorreoElectronico).IsUnique();

            builder.Property(e => e.Rol).HasMaxLength(20);


        }
        }
        }
    
