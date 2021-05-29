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
    public class ventaController : ControllerBase
    {
        private readonly DbContexSitema _context;

        public ventaController(DbContexSitema context)
        {
            _context = context;
        }

        //GET api/Venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<venta>>> Getventa()
        {
            return await _context.Ventas.ToListAsync();
        }


        //GET api/Venta/2
        [HttpGet("{idventa}")]

        public async Task<ActionResult<venta>> Getventa(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);



            if (venta == null)
            {
                return NotFound();
            }

            return venta;
        }

        //Put api/Venta/2
        [HttpPut("idventa")]
        public async Task<IActionResult> Putventa(int id, venta venta)
        {
            if (id != venta.idventa)
            {
                return BadRequest();
            }

            //MI ENTIDAD YA TIENE LAS PROPIEDADDES O INFO QUE VOY A GUARDAR EN MY DB
            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ventaExists(id))
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

        //POst api/Venta
        [HttpPost]
        public async Task<ActionResult<venta>> Postventa(venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getventa", new { id = venta.idventa }, venta);
        }

        //Delete api/Venta/2

        [HttpDelete("idventa")]
        public async Task<ActionResult<venta>> Deleteventa(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return venta;
        }

        private bool ventaExists(int id)
        {
            return _context.Ventas.Any(e => e.idventa == id);
        }

    }
}
