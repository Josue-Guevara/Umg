using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umg.Datos;
using Umg.Entidades.Usuario;

namespace Umg.Web.Controllers
{
   [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly DbContexSitema _context;

        public RolController(DbContexSitema context)
        {
            _context = context;
        }

        //GET api/Rol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRol()
        {
            return await _context.Rols.ToListAsync();
        }


        //GET api/Rol/2
        [HttpGet("{idrol}")]

        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _context.Rols.FindAsync(id);



            if (rol == null)
            {
                return NotFound();
            }

            return rol;
        }

        //Put api/Rol/2
        [HttpPut("idrol")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            if (id != rol.idrol)
            {
                return BadRequest();
            }

            //MI ENTIDAD YA TIENE LAS PROPIEDADDES O INFO QUE VOY A GUARDAR EN MY DB
            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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

        //POst api/Rol
        [HttpPost]
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRol", new { id = rol.idrol }, rol);
        }

        //Delete api/Rol/2

        [HttpDelete("idrol")]
        public async Task<ActionResult<Rol>> DeleteRol(int id)
        {
            var rol = await _context.Rols.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }

            _context.Rols.Remove(rol);
            await _context.SaveChangesAsync();

            return rol;
        }

        private bool RolExists(int id)
        {
            return _context.Rols.Any(e => e.idrol == id);
        }

    }
}