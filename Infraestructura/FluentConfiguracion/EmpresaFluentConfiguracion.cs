using  Employees.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Employees.Infraestructura.FluentConfiguracion
{
    internal class Empresa_FluentConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
       
    
            builder.HasKey(e => e.IdEmpresa).HasName("Empresa_pkey");

            builder.ToTable("Empresa");

            builder.Property(e => e.IdEmpresa).HasColumnName("ID_empresa");
            builder.Property(e => e.Factura).HasColumnName("factura");
            builder.Property(e => e.Nombre)
                .HasMaxLength(70)
                .HasColumnName("nombre");
        }

          
        
        }
    }


