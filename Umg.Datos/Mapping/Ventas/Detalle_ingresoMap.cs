using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Umg.Entidades.Usuario;
using Umg.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umg.Datos.Mapping.Ventas
{
    public class Detalle_ingresoMap : IEntityTypeConfiguration<detalle_ingreso>
    {
        public void Configure(EntityTypeBuilder<detalle_ingreso> builder)
        {
            builder.ToTable("Detalle_ingreso")
             .HasKey(c => c.id_detalle_ingreso);
            builder.Property(c => c.cantidad_detalle_ingreso)
                .HasMaxLength(50);
            builder.Property(c => c.precio_detalle_ingreso)
                .HasMaxLength(50);
            builder.Property(c => c.ingreso_detalle_ingreso)
                .HasMaxLength(50);

        }
    }
}