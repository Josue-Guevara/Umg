using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Umg.Entidades.Usuario
{
    public class persona
    {
        public int idpersona { get; set; }
        [Requiered]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "El nombre debe de tener maximo de 30 caracteres, y no menos de 3 caracteres.")]

        public int tipo_persona { get; set; }

        public String nombre { get; set; }

        public String tipo_documento { get; set; }

        public String num_documento { get; set; }

        public String direccion { get; set; }

        public String telefono { get; set; } // este debe de cambiar

        public String email { get; set; }

        public Ventas.venta venta
        {
            get => default;
            set
            {
            }
        }

        public Ventas.ingreso ingreso
        {
            get => default;
            set
            {
            }
        }

        public Usuario Usuarios
        {
            get => default;
            set
            {
            }
        }

        public Usuario Usuarios1
        {
            get => default;
            set
            {
            }
        }

        public Usuario Usuarios2
        {
            get => default;
            set
            {
            }
        }
    }
}