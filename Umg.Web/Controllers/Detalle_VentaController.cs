using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umg.Datos;
using Umg.Entidades.Ventas;

namespace Umg.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class detalle_ventaController : ControllerBase
    {
        private readonly DbContexSitema _context;

        public detalle_ventaController(DbContexSitema context)
        {
            _context = context;
        }

        //GET api/Detalle_Venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<detalle_venta>>> Getdetalle_venta()
        {
            return await _context.detalle_ventas.ToListAsync();
        }


        //GET api/Detalle_Venta/2
        [HttpGet("{id_detalle_venta}")]

        public async Task<ActionResult<detalle_venta>> Getdetalle_venta(int id)
        {
            var detalle_Venta = await _context.detalle_ventas.FindAsync(id);



            if (detalle_Venta == null)
            {
                return NotFound();
            }

            return detalle_Venta;
        }

        //Put api/Detalle_Venta/2
        [HttpPut("id_detalle_venta")]
        public async Task<IActionResult> Putdetalle_venta(int id, detalle_venta detalle_Venta)
        {
            if (id != detalle_Venta.id_detalle_venta)
            {
                return BadRequest();
            }

            //MI ENTIDAD YA TIENE LAS PROPIEDADDES O INFO QUE VOY A GUARDAR EN MY DB
            _context.Entry(detalle_Venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!detalle_ventaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //POst api/Detalle_Venta
        [HttpPost]
        public async Task<ActionResult<detalle_venta>> Postdetalle_venta(detalle_venta detalle_Venta)
        {
            _context.detalle_ventas.Add(detalle_Venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdetale_venta", new { id = detalle_Venta.id_detalle_venta }, detalle_Venta);
        }

        //Delete api/Detalle_Venta/2

        [HttpDelete("id_deralle_venta")]
        public async Task<ActionResult<detalle_venta>> Deletedetalle_venta(int id)
        {
            var detalle_Venta = await _context.detalle_ventas.FindAsync(id);

            if (detalle_Venta == null)
            {
                return NotFound();
            }

            _context.detalle_ventas.Remove(detalle_Venta);
            await _context.SaveChangesAsync();

            return detalle_Venta;
        }

        private bool detalle_ventaExists(int id)
        {
            return _context.detalle_ventas.Any(e => e.id_detalle_venta == id);
        }

    }
}