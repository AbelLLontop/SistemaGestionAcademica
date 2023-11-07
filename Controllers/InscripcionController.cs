using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class InscripcionController : ControllerBase
{
    private readonly DataContext _context;
    public InscripcionController(DataContext dataContext)
    {
        _context = dataContext;
    }
   
    [Authorize(Policy = "Admin")]
    [HttpPost("{idCarrera}/inscribir/{idEstudiante}")]
    public async Task<IActionResult> InscribirEstudiante(int idCarrera, int idEstudiante)
    {
        Carrera? carreraExistente = await _context.Carreras.FirstOrDefaultAsync(x => x.Id == idCarrera);
        if (carreraExistente == null)
        {
            return NotFound();
        }
        Usuario? usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == idEstudiante);
        if (usuarioExistente == null)
        {
            return NotFound();
        }
        Inscripcion? inscripcionExistente = await _context.Inscripciones.FirstOrDefaultAsync(x => x.CarreraId == idCarrera && x.UsuarioId == idEstudiante);
        if (inscripcionExistente != null && inscripcionExistente.Estado == "Activo")
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = $"El estudiante {usuarioExistente.Nombre} {usuarioExistente.Apellidos} ya esta inscrito en la carrera {carreraExistente.Nombre}" });
        }

        Inscripcion inscripcionNueva = new Inscripcion
        {
            CarreraId = idCarrera,
            UsuarioId = idEstudiante,
            Estado = "Activo"
        };
        _context.Inscripciones.Add(inscripcionNueva);
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status201Created, new { message = $"El estudiante {usuarioExistente.Nombre} {usuarioExistente.Apellidos} se inscribio en la carrera {carreraExistente.Nombre}" });
    }

}