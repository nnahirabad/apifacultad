using ApiFacultad.Comandos;
using ApiFacultad.Comandos.Usuarios;
using ApiFacultad.Models;
using ApiFacultad.Resultados.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 


namespace ApiFacultad.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly FacultadContext _context;


        public UsuarioController(FacultadContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("api/usuario/login")]
        public async Task<ActionResult<ResultadoLogin>> Login([FromBody] ComandoLogin comando)
        {
            try
            {
                var result = new ResultadoLogin();
                var usuario = await _context.Usuarios.Where(c => c.Email.Equals(comando.Email) && c.Contrasena.Equals(comando.Password)).Include(c => c.IdRolNavigation).FirstOrDefaultAsync();
                if (usuario != null)
                {
                    result.Email = usuario.Email;
                    result.NombreRol = usuario.IdRolNavigation.Nombre;
                    return Ok(result);
                }
                else
                {
                    result.SetError("Usuario no encontrado");
                    result.StatusCode = "500";
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("error wacho");
            }
        }


        [HttpGet]
        [Route("api/usuario/GetTodos")]
        public async Task<ActionResult<List<ResultadoLogin>>> GetTodosLosActivos()
        {
            try
            {
                var result = new List<ResultadoLogin>();
                var usuarios = await _context.Usuarios.ToListAsync();
                if (usuarios != null)
                {
                    foreach (var usu in usuarios)
                    {
                        var resultAux = new ResultadoLogin
                        {
                            Email = usu.Email,
                            NombreRol =usu.IdRolNavigation.Nombre,
                            StatusCode = "200"

                        };
                        result.Add(resultAux);
                    }

                    return Ok(result);

                }
                else
                {

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("alto error wacho");
            }
        }

        [HttpPost]
        [Route("api/usuario/create")]
        public async Task<ActionResult<bool>> CreateUsuario([FromBody] ComandoCreateUser comando)
        {
            try
            {
                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Email = comando.Email,
                    Contrasena = comando.Password,
                    IdRol = new Guid("b7514945-25d8-431a-8af7-4e1ff9d9806a")
                };
                await _context.AddAsync(usuario);
                await _context.SaveChangesAsync();
                return Ok(true); 
            }
            catch (Exception ex)
            {
                return BadRequest("error en registrar nuevo user");
            }
        }

       

    }

}

