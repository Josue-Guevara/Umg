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
    public class UsuarioController : ControllerBase
    {
        private readonly DbContexSitema _context;

        public UsuarioController(DbContexSitema context)
        {
            _context = context;
        }

        //GET api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
        {
            return await _context.Usuarioss.ToListAsync();
        }


        //GET api/Usaurio/2
        [HttpGet("{idusuario}")]

        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarioss.FindAsync(id);



            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        //Put api/Usuario/2
        [HttpPut("idusuario")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.idusuario)
            {
                return BadRequest();
            }

            //MI ENTIDAD YA TIENE LAS PROPIEDADDES O INFO QUE VOY A GUARDAR EN MY DB
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        //POst api/Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarioss.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsaurio", new { id = usuario.idusuario }, usuario);
        }

        //Delete api/Usaurio/2

        [HttpDelete("idusuario")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarioss.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarioss.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarioss.Any(e => e.idusuario == id);
        }

    }
}
