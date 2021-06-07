using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Umg.Entidades.Almacen
{
    public class articulo
    {
        public int idarticulo { get; set; }
        [Required]


        public String codigo_articilo { get; set; }

        public String nombre_articulo { get; set; }

        public decimal venta_articulo { get; set; }

        public float stock_articulo { get; set; }

        public String descripcion_articulo { get; set; }

        public int condicion_articulo { get; set; }

        public int idmarca { get; set; }

  
public Ventas.detalle_ingreso detalle_ingreso
        {
            get => default;
            set
            {
            }
        }

        public Ventas.detalle_venta detalle_venta
        {
            get => default;
            set
            {
            }
        }

        public Ventas.venta venta
        {
            get => default;
            set
            {
            }
        }

        public Ventas.venta venta1
        {
            get => default;
            set
            {
            }
        }
    


//realcion con la tabla categorias  -->ojo
public Categoria categoria { get; set; }

        public Ventas.venta venta2
        {
            get => default;
            set
            {
            }
        }

        public Ventas.venta venta3
        {
            get => default;
            set
            {
            }
        }

        public Ventas.detalle_venta detalle_venta1
        {
            get => default;
            set
            {
            }
        }

        public Ventas.detalle_ingreso detalle_ingreso1
        {
            get => default;
            set
            {
            }
        }
    }
}
