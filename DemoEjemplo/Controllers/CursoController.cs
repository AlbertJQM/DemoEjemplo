using DB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace DemoEjemplo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly CursoService _cursoService;

        public CursoController(CursoService cursoService)
        {
            _cursoService = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetAll()
        {
            List<Curso> cursos = await _cursoService.GetAll();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetByID(int id)
        {
            Curso curso = await _cursoService.GetByID(id);
            if (curso != null)
            {
                return Ok(curso);
            }
            return NotFound(new { message = "Curso no encontrado." });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Curso curso)
        {
            Curso newCurso = await _cursoService.Create(curso);
            return Ok(new { message = "Curso creado.", curso = newCurso });
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Curso curso)
        {
            Curso updatedCurso = await _cursoService.Update(curso);
            return Ok(new { message = "Curso modificado.", curso = updatedCurso });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Curso deletedcurso = await _cursoService.Delete(id);
            if (deletedcurso != null)
            {
                return Ok(new { message = "Curso eliminado.", curso = deletedcurso });
            }
            return NotFound(new { message = "Curso no encontrado." });
        }
    }
}
