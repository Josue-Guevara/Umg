using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Umg.Entidades.Usuario;


namespace Umg.Datos.Mapping.Usuarios
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario")
             .HasKey(c => c.idusuario);
            builder.Property(c => c.nombre)
                .HasMaxLength(50);
            builder.Property(c => c.tipo_documento)
                .HasMaxLength(50);
            builder.Property(c => c.num_documento)
                .HasMaxLength(50);
            builder.Property(c => c.direccion)
                .HasMaxLength(50);
            builder.Property(c => c.telefono)
                .HasMaxLength(50);
            builder.Property(c => c.email)
                .HasMaxLength(50);
            builder.Property(c => c.password_hash)
               .HasMaxLength(50);
            builder.Property(c => c.password_sat)
              .HasMaxLength(50);

        }
    }
}