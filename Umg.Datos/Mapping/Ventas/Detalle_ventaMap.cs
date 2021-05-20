using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Umg.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umg.Datos.Mapping.Ventas
{
    public class Detalle_ventaMap : IEntityTypeConfiguration<detalle_venta>
    {
        public void Configure(EntityTypeBuilder<detalle_venta> builder)
        {
            builder.ToTable("Detalle_venta")
             .HasKey(c => c.id_detalle_venta);
            builder.Property(c => c.cantidad_detalle_venta)
                .HasMaxLength(50);
            builder.Property(c => c.precio_detalle_venta)
                .HasMaxLength(50);
            builder.Property(c => c.descuento_detalle_venta)
                .HasMaxLength(50);

        }
    }
}