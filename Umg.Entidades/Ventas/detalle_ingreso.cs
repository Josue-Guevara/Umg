﻿using System.ComponentModel.DataAnnotations;

namespace Umg.Entidades.Ventas
{
    public class detalle_ingreso
    {
        public int id_detalle_ingreso { get; set; }
        [Required]

        public int cantidad_detalle_ingreso { get; set; }

        public decimal precio_detalle_ingreso { get; set; }

        public int ingreso_detalle_ingreso { get; set; }

        public detalle_venta detalle_venta
        {
            get => default;
            set
            {
            }
        }

        public Usuario.persona persona
        {
            get => default;
            set
            {
            }
        }

        public Usuario.persona persona1
        {
            get => default;
            set
            {
            }
        }
    }
}