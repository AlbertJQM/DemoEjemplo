using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DemoEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteService _estudianteService;

        public EstudianteController(EstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estudiante>>> GetAll()
        {
            List<Estudiante> estudiantes = await _estudianteService.GetAll();
            return Ok(estudiantes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estudiante>> GetByID(int id)
        {
            Estudiante estudiante = await _estudianteService.GetByID(id);
            if (estudiante != null)
            {
                return Ok(estudiante);
            }
            return NotFound(new { message = "Estudiante no encontrado." });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Estudiante estudiante)
        {
            Estudiante newEstudiante = await _estudianteService.Create(estudiante);
            return Ok(new { message = "Estudiante creado.", estudiante = newEstudiante });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Estudiante estudiante)
        {
            Estudiante updatedEstudiante = await _estudianteService.Update(estudiante);
            return Ok(new { message = "Estudiante modificado.", estudiante = updatedEstudiante });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Estudiante deletedEstudiante = await _estudianteService.Delete(id);
            if (deletedEstudiante != null)
            {
                return Ok(new { message = "Estudiante eliminado.", estudiante = deletedEstudiante });
            }
            return NotFound(new { message = "Estudiante no encontrado." });
        }
    }
}
