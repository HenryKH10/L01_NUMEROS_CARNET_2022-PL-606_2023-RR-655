using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Models;


namespace L01_NUMEROS_CARNET_2022_PL_606_2023_RR_655.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly blogDBContext _context;

        public CalificacionesController(blogDBContext context)
        {
            _context = context;
        }

        // CRUD: Obtener todas las calificaciones
        [HttpGet]
        public IActionResult Get()
        {
            var calificaciones = _context.calificaciones.ToList();
            if (!calificaciones.Any())
            {
                return NotFound();
            }
            return Ok(calificaciones);
        }

        // Obtener calificación por ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var calificacion = _context.calificaciones
                .FirstOrDefault(c => c.CalificacionId == id);
            if (calificacion == null)
            {
                return NotFound();
            }
            return Ok(calificacion);
        }

        // Crear nueva calificación
        [HttpPost]
        public IActionResult Create([FromBody] calificaciones calificacion)
        {
            if (calificacion == null)
            {
                return BadRequest("Calificación no válida");
            }

            _context.calificaciones.Add(calificacion);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = calificacion.CalificacionId }, calificacion);
        }

        // Actualizar calificación existente
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] calificaciones calificacionModificada)
        {
            var calificacion = _context.calificaciones
                .FirstOrDefault(c => c.CalificacionId == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            calificacion.PublicacionId = calificacionModificada.PublicacionId;
            calificacion.UsuarioId = calificacionModificada.UsuarioId;
            calificacion.CalificacionValor = calificacionModificada.CalificacionValor;

            _context.Entry(calificacion).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(calificacion);
        }

        // Eliminar calificación
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var calificacion = _context.calificaciones
                .FirstOrDefault(c => c.CalificacionId == id);
            if (calificacion == null)
            {
                return NotFound();
            }

            _context.calificaciones.Remove(calificacion);
            _context.SaveChanges();

            return Ok(calificacion);
        }

        // Filtrar calificaciones por publicación
        [HttpGet("FindByPublicacion/{publicacionId}")]
        public IActionResult FindByPublicacion(int publicacionId)
        {
            var calificaciones = _context.calificaciones
                .Where(c => c.PublicacionId == publicacionId)
                .ToList();
            if (!calificaciones.Any())
            {
                return NotFound();
            }
            return Ok(calificaciones);
        }
    }
}
