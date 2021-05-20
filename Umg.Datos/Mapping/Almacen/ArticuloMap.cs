using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Umg.Entidades.Almacen;

namespace Umg.Datos.Mapping.Almacen
{
    public class ArticuloMap : IEntityTypeConfiguration<articulo>
    {
        public void Configure(EntityTypeBuilder<articulo> builder)
        {
            builder.ToTable("articulo")
             .HasKey(c => c.idarticulo);
            builder.Property(c => c.nombre_articulo)
                .HasMaxLength(50);
            builder.Property(c => c.venta_articulo)
                .HasMaxLength(50);
            builder.Property(c => c.codigo_articilo)
              .HasMaxLength(50);
            builder.Property(c => c.stock_articulo)
              .HasMaxLength(50);
            builder.Property(c => c.descripcion_articulo)
                .HasMaxLength(256);
            builder.Property(c => c.idmarca)
              .HasMaxLength(50);
        }
    }
}