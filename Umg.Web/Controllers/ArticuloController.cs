using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umg.Datos;
using Umg.Entidades.Almacen;

namespace Umg.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly DbContexSitema _context;

        public ArticuloController(DbContexSitema context)
        {
            _context = context;
        }

        //GET api/Articulo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<articulo>>> GetArticulo()
        {
            return await _context.Articulos.ToListAsync();
        }


        //GET api/Articulo/2
        [HttpGet("{idarticulo}")]

        public async Task<ActionResult<articulo>> GetArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);



            if (articulo == null)
            {
                return NotFound();
            }

            return articulo;
        }

        //Put api/Articulo/2
        [HttpPut("idarticulo")]
        public async Task<IActionResult> PutArticulo(int id, articulo articulo)
        {
            if (id != articulo.idarticulo)
            {
                return BadRequest();
            }

            //MI ENTIDAD YA TIENE LAS PROPIEDADDES O INFO QUE VOY A GUARDAR EN MY DB
            _context.Entry(articulo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        //POst api/Articulo
        [HttpPost]
        public async Task<ActionResult<articulo>> PostArticulo(articulo articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArticulo", new { id = articulo.idarticulo }, articulo);
        }

        //Delete api/Articulo/2

        [HttpDelete("idarticulo")]
        public async Task<ActionResult<articulo>> DeleteArticulo(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);

            if (articulo == null)
            {
                return NotFound();
            }

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();

            return articulo;
        }

        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(e => e.idarticulo == id);
        }

    }
}