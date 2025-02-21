using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models;


namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly blogDBContext _context;

        public UsuariosController(blogDBContext context)
        {
            _context = context;
        }

        // CRUD: Obtener todos los usuarios
        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _context.usuarios.ToList();
            if (!usuarios.Any())
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        // Obtener usuario por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var usuario = _context.usuarios
                .FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // Crear nuevo usuario
        [HttpPost]
        public IActionResult Create([FromBody] usuarios usuario)
        {
            if (usuario == null)
            {
                return BadRequest("Usuario no válido");
            }

            _context.usuarios.Add(usuario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = usuario.UsuarioId }, usuario);
        }

        // Actualizar usuario existente
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] usuarios usuarioModificado)
        {
            var usuario = _context.usuarios
                .FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.RolId = usuarioModificado.RolId;
            usuario.NombreUsuario = usuarioModificado.NombreUsuario;
            usuario.Clave = usuarioModificado.Clave;
            usuario.Nombre = usuarioModificado.Nombre;
            usuario.Apellido = usuarioModificado.Apellido;

            _context.Entry(usuario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(usuario);
        }

        // Eliminar usuario
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _context.usuarios
                .FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.usuarios.Remove(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }

        // Filtrar usuarios por nombre y apellido
        [HttpGet("FindByNombre/{nombre}/{apellido}")]
        public IActionResult FindByNombreYApellido(string nombre, string apellido)
        {
            var usuarios = _context.usuarios
                .Where(u => u.Nombre.Contains(nombre) && u.Apellido.Contains(apellido))
                .ToList();
            if (!usuarios.Any())
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        // Filtrar usuarios por rol
        [HttpGet("FindByRol/{rolId}")]
        public IActionResult FindByRol(int rolId)
        {
            var usuarios = _context.usuarios
                .Where(u => u.RolId == rolId)
                .ToList();
            if (!usuarios.Any())
            {
                return NotFound();
            }
            return Ok(usuarios);
        }
    }
}
