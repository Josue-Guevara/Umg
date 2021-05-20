using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Umg.Entidades.Usuario
{
    public class Usuario
    {
        public int idusuario { get; set; }
        [Requiered]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe de tener maximo de 30 caracteres, y no menos de 3 caracteres.")]

        public String nombre { get; set; }
        [StringLength(10, ErrorMessage = "La direccion  su tamaño maximo es de 100 caracteres.")]

        public String tipo_documento { get; set; }

        public String num_documento { get; set; }

        public String direccion { get; set; }

        public String telefono { get; set; } //este va a cambiar

        public String email { get; set; }

        public String password_hash { get; set; }

        public String password_sat { get; set; }

        public bool condicion { get; set; }

        public Ventas.venta venta
        {
            get => default;
            set
            {
            }
        }

        public Ventas.ingreso ingreso1
        {
            get => default;
            set
            {
            }
        }

        public Rol Rol
        {
            get => default;
            set
            {
            }
        }

        public Rol Rol1
        {
            get => default;
            set
            {
            }
        }

        public Rol Rol2
        {
            get => default;
            set
            {
            }
        }
    }
}