using ApiFacultad.Comandos;
using ApiFacultad.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiFacultad.Controllers
{
    public class CursoController : Controller
    {
        private readonly FacultadContext _context;

        public CursoController(FacultadContext context)
        {
            _context = context;
        }

        [HttpPut]
        [Route("")]

        public async IActionResult ActualizarCurso(int id, [FromBody] Curso modificarcurso)
        {
            
        }

        [HttpPost]
        [Route("api/curso/create")]
        public async Task<ActionResult<bool>> CreateCurse([FromBody] ComandoCreateCurso comando)
        {
            try
            {
                var curso = new Curso
                {
                    Id = Guid.NewGuid(),
                    Nombre = comando.Nombre,
                    FechaCreacion = comando.FechaCreacion,
                    Horarios = comando.Horarios,

                    IdCarrera = new Guid("b7514945-25d8-431a-8af7-4e1ff9d9806a")
                };
                await _context.AddAsync(curso);
                await _context.SaveChangesAsync();
                return Ok(true);
            }
            catch (Exception ex)
            {
                return BadRequest("error en registrar nuevo curso");
            }
        }

    }
}
