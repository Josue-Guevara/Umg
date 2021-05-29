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
    public class PersonaController : ControllerBase
    {
        private readonly DbContexSitema _context;

        public PersonaController(DbContexSitema context)
        {
            _context = context;
        }

        //GET api/Persona
        [HttpGet]
        public async Task<ActionResult<IEnumerable<persona>>> GetPersona()
        {
            return await _context.Personas.ToListAsync();
        }


        //GET api/Persona/2
        [HttpGet("{idPersona}")]

        public async Task<ActionResult<persona>> GetPersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);



            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        //Put api/Persona/2
        [HttpPut("idpersona")]
        public async Task<IActionResult> PutPersona(int id, persona persona)
        {
            if (id != persona.idpersona)
            {
                return BadRequest();
            }

            //MI ENTIDAD YA TIENE LAS PROPIEDADDES O INFO QUE VOY A GUARDAR EN MY DB
            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        //POst api/Persona
        [HttpPost]
        public async Task<ActionResult<persona>> PostPersona(persona persona)
        {
            _context.Personas.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.idpersona }, persona);
        }

        //Delete api/Persona/2

        [HttpDelete("idPersona")]
        public async Task<ActionResult<persona>> DeletePersona(int id)
        {
            var persona = await _context.Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            _context.Personas.Remove(persona);
            await _context.SaveChangesAsync();

            return persona;
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas.Any(e => e.idpersona == id);
        }

    }
}