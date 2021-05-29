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
    public class ingresoController : ControllerBase
    {
        private readonly DbContexSitema _context;

        public ingresoController(DbContexSitema context)
        {
            _context = context;
        }

        //GET api/Ingresos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ingreso>>> Getingreso()
        {
            return await _context.ingresos.ToListAsync();
        }


        //GET api/Ingresos/2
        [HttpGet("{idingreso}")]

        public async Task<ActionResult<ingreso>> Getingreso(int id)
        {
            var ingreso = await _context.ingresos.FindAsync(id);



            if (ingreso == null)
            {
                return NotFound();
            }

            return ingreso;
        }

        //Put api/Ingreso/2
        [HttpPut("idingreso")]
        public async Task<IActionResult> Putingreso(int id, ingreso ingreso)
        {
            if (id != ingreso.idingreso)
            {
                return BadRequest();
            }

            //MI ENTIDAD YA TIENE LAS PROPIEDADDES O INFO QUE VOY A GUARDAR EN MY DB
            _context.Entry(ingreso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ingresoExists(id))
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

        //POst api/Ingreso
        [HttpPost]
        public async Task<ActionResult<ingreso>> Postingreso(ingreso ingreso)
        {
            _context.ingresos.Add(ingreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getingreso", new { id = ingreso.idingreso }, ingreso);
        }

        //Delete api/Ingreso/2

        [HttpDelete("idingreso")]
        public async Task<ActionResult<ingreso>> DeleteIngreso(int id)
        {
            var ingreso = await _context.ingresos.FindAsync(id);

            if (ingreso == null)
            {
                return NotFound();
            }

            _context.ingresos.Remove(ingreso);
            await _context.SaveChangesAsync();

            return ingreso;
        }

        private bool ingresoExists(int id)
        {
            return _context.ingresos.Any(e => e.idingreso == id);
        }

    }
}