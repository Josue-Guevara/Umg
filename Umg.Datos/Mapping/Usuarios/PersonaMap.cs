using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Umg.Entidades.Usuario;

namespace Umg.Datos.Mapping.Usuarios
{
    public class PersonaMap : IEntityTypeConfiguration<persona>
    {
        public void Configure(EntityTypeBuilder<persona> builder)
        {
            builder.ToTable("Persona")
             .HasKey(c => c.idpersona);
            builder.Property(c => c.tipo_persona)
                .HasMaxLength(50);
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
         
        }
    }
}