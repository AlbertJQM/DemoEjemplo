using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DemoEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController : ControllerBase
    {
        private readonly InscripcionService _inscripcionService;

        public InscripcionController(InscripcionService inscripcionService)
        {
            _inscripcionService = inscripcionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> GetAll()
        {
            List<Inscripcion> inscripcions = await _inscripcionService.GetAll();
            return Ok(inscripcions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripcion>> GetByID(int id)
        {
            Inscripcion inscripcion = await _inscripcionService.GetByID(id);
            if (inscripcion != null)
            {
                return Ok(inscripcion);
            }
            return NotFound(new { message = "Inscripcion no encontrado." });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Inscripcion inscripcion)
        {
            Inscripcion newInscripcion = await _inscripcionService.Create(inscripcion);
            return Ok(new { message = "Inscripcion creado.", inscripcion = newInscripcion });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Inscripcion inscripcion)
        {
            Inscripcion updatedInscripcion = await _inscripcionService.Update(inscripcion);
            return Ok(new { message = "Inscripcion modificado.", inscripcion = updatedInscripcion });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Inscripcion deletedinscripcion = await _inscripcionService.Delete(id);
            if (deletedinscripcion != null)
            {
                return Ok(new { message = "Inscripcion eliminado.", inscripcion = deletedinscripcion });
            }
            return NotFound(new { message = "Inscripcion no encontrado." });
        }
    }
}
