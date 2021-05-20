using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Umg.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umg.Datos.Mapping.Ventas
{
    public class VentaMap : IEntityTypeConfiguration<venta>
    {
        public void Configure(EntityTypeBuilder<venta> builder)
        {
            builder.ToTable("Venta")
             .HasKey(c => c.idventa);
            builder.Property(c => c.tipo_comprobante_venta)
                .HasMaxLength(50);
            builder.Property(c => c.serie_comprobante)
                .HasMaxLength(50);
            builder.Property(c => c.num_comprobante_venta)
                .HasMaxLength(50);
            builder.Property(c => c.fecha_hora_venta)
                .HasMaxLength(50);
            builder.Property(c => c.impuesto)
                .HasMaxLength(50);
            builder.Property(c => c.total)
                .HasMaxLength(50);


        }
    }
}