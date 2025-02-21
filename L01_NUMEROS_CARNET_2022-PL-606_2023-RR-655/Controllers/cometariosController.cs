using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models;


namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly blogDBContext _context;

        public ComentariosController(blogDBContext context)
        {
            _context = context;
        }

        // CRUD: Obtener todos los comentarios
        [HttpGet]
        public IActionResult Get()
        {
            var comentarios = _context.comentarios.ToList();
            if (!comentarios.Any())
            {
                return NotFound();
            }
            return Ok(comentarios);
        }

        // Obtener comentario por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var comentario = _context.comentarios
                .FirstOrDefault(c => c.ComentarioId == id);
            if (comentario == null)
            {
                return NotFound();
            }
            return Ok(comentario);
        }

        // Crear nuevo comentario
        [HttpPost]
        public IActionResult Create([FromBody] comentarios comentario)
        {
            if (comentario == null)
            {
                return BadRequest("Comentario no válido");
            }

            _context.comentarios.Add(comentario);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = comentario.ComentarioId }, comentario);
        }

        // Actualizar comentario existente
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] comentarios comentarioModificado)
        {
            var comentario = _context.comentarios
                .FirstOrDefault(c => c.ComentarioId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            comentario.PublicacionId = comentarioModificado.PublicacionId;
            comentario.ComentarioTexto = comentarioModificado.ComentarioTexto;
            comentario.UsuarioId = comentarioModificado.UsuarioId;

            _context.Entry(comentario).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(comentario);
        }

        // Eliminar comentario
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var comentario = _context.comentarios
                .FirstOrDefault(c => c.ComentarioId == id);
            if (comentario == null)
            {
                return NotFound();
            }

            _context.comentarios.Remove(comentario);
            _context.SaveChanges();

            return Ok(comentario);
        }

        // Filtrar comentarios por UsuarioId
        [HttpGet("FindByUsuario/{usuarioId}")]
        public IActionResult FindByUsuario(int usuarioId)
        {
            var comentarios = _context.comentarios
                .Where(c => c.UsuarioId == usuarioId)
                .ToList();
            if (!comentarios.Any())
            {
                return NotFound();
            }
            return Ok(comentarios);
        }
    }
}
