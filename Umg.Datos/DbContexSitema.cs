using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Umg.Datos.Mapping.Almacen;
using Umg.Datos.Mapping.Usuarios;
using Umg.Datos.Mapping.Ventas;
using Umg.Entidades.Almacen;
using Umg.Entidades.Usuario;
using Umg.Entidades.Ventas;





namespace Umg.Datos
{
    public class DbContexSitema : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<articulo> Articulos { get; set; }
        public DbSet<persona> Personas { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Usuario> Usuarioss { get; set; }
        public DbSet<detalle_ingreso> detalle_ingresos { get; set; }
        public DbSet<detalle_venta> detalle_ventas { get; set; }
        public DbSet<ingreso> ingresos { get; set; }
        public DbSet<venta> Ventas { get; set; }
        public DbContexSitema(DbContextOptions<DbContexSitema> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ArticuloMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PersonaMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RolMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Detalle_ingresoMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new Detalle_ventaMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new IngresoMap());

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new VentaMap());
        }
       
    
     
}
}
    