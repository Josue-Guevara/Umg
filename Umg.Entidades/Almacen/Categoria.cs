using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Umg.Entidades.Almacen
{
    public class Categoria
    {
        public int idcategoria { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Error")]
        public string nombre { get; set; }
        [StringLength(256)]
        public string descripcion { get; set; }
        public bool condicion { get; set; }

        //vinculamos la tabla articulos con categoria  ---> 
        public ICollection<articulo> articulos { get; set; }

        public articulo articulo
        {
            get => default;
            set
            {
            }
        }

        public articulo articulo1
        {
            get => default;
            set
            {
            }
        }

        public articulo articulo2
        {
            get => default;
            set
            {
            }
        }
    }
}

