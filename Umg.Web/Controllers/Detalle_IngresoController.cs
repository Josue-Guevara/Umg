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
    public class detalle_ingresoController : ControllerBase
    {
        private readonly DbContexSitema _context;

        public detalle_ingresoController(DbContexSitema context)
        {
            _context = context;
        }

        //GET api/Detalle_ingreso
        [HttpGet]
        public async Task<ActionResult<IEnumerable<detalle_ingreso>>> Getdetalle_ingreso()
        {
            return await _context.detalle_ingresos.ToListAsync();
        }


        //GET api/Detalle_Ingreso/2
        [HttpGet("{id_detalle_ingreso}")]

        public async Task<ActionResult<detalle_ingreso>> Getdetalle_ingreso(int id)
        {
            var detalle_Ingreso = await _context.detalle_ingresos.FindAsync(id);



            if (detalle_Ingreso == null)
            {
                return NotFound();
            }

            return detalle_Ingreso;
        }

        //Put api/Detalle_Ingreso/2
        [HttpPut("id_detalle_ingreso")]
        public async Task<IActionResult> PutDetalle_Ingreso(int id, detalle_ingreso detalle_Ingreso)
        {
            if (id != detalle_Ingreso.id_detalle_ingreso)
            {
                return BadRequest();
            }

            //MI ENTIDAD YA TIENE LAS PROPIEDADDES O INFO QUE VOY A GUARDAR EN MY DB
            _context.Entry(detalle_Ingreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!detalle_ingresoExists(id))
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

        //POst api/Detalle_Ingreso
        [HttpPost]
        public async Task<ActionResult<detalle_ingreso>> Postdetalle_ingreso(detalle_ingreso detalle_Ingreso)
        {
            _context.detalle_ingresos.Add(detalle_Ingreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdetalle_ingreso", new { id = detalle_Ingreso.id_detalle_ingreso }, detalle_Ingreso);
        }

        //Delete api/Detalle_Ingreso/2

        [HttpDelete("id_detalle_ingreso")]
        public async Task<ActionResult<detalle_ingreso>> Deletedetalle_ingreso(int id)
        {
            var detalle_Ingreso = await _context.detalle_ingresos.FindAsync(id);

            if (detalle_Ingreso == null)
            {
                return NotFound();
            }

            _context.detalle_ingresos.Remove(detalle_Ingreso);
            await _context.SaveChangesAsync();

            return detalle_Ingreso;
        }

        private bool detalle_ingresoExists(int id)
        {
            return _context.detalle_ingresos.Any(e => e.id_detalle_ingreso == id);
        }

    }
}
