using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Umg.Entidades.Usuario;
using Umg.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Umg.Datos.Mapping.Ventas
{
    public class IngresoMap : IEntityTypeConfiguration<ingreso>
    {
        public void Configure(EntityTypeBuilder<ingreso> builder)
        {
            builder.ToTable("Ingreso")
             .HasKey(c => c.idingreso);
            builder.Property(c => c.topo_comprobante_ingreso)
                .HasMaxLength(50);
            builder.Property(c => c.serie_comprobante_ingreso)
                .HasMaxLength(50);
            builder.Property(c => c.num_comprobante_ingreso)
                .HasMaxLength(50);
            builder.Property(c => c.fecha_hora_ingreso)
               .HasMaxLength(50);
            builder.Property(c => c.impuesto_ingreso)
                .HasMaxLength(50);
            builder.Property(c => c.total_ingreso)
                .HasMaxLength(50);

        }
    }
}