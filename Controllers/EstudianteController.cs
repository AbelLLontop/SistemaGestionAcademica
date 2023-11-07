using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EstudianteController : ControllerBase
{
    private readonly DataContext _context;
    public EstudianteController(DataContext dataContext)
    {
        _context = dataContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Estudiante>> GetEstudiante(int id)
    {
        Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (usuario == null)
        {
            return NotFound();
        }
        Estudiante estudiante = new Estudiante
        {
            Id = usuario.Id,
            Nombre = usuario.Nombre,
            Apellidos = usuario.Apellidos,
            Telefono = usuario.Telefono,
            Direccion = usuario.Direccion,
            Dni = usuario.Dni,
            Genero = usuario.Genero,
            GradoEstudio = usuario.GradoEstudio,
            FechaNacimiento = usuario.FechaNacimiento,
            Email = usuario.Email
        };

        return estudiante;
    }


    [Authorize(Policy = "Admin,Estudiante")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEstudiante(int id, [FromBody] EstudianteUpdate estudiante)
    {
        Usuario? estudianteExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (estudianteExistente == null)
        {
            return NotFound();
        }

        Usuario? usuarioExistenteDni = await _context.Usuarios.FirstOrDefaultAsync(x => x.Dni == estudiante.Dni);
        if (usuarioExistenteDni != null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = "El dni ya existe" });
        }

        estudianteExistente.Nombre = estudiante.Nombre;
        estudianteExistente.Telefono = estudiante.Telefono;
        estudianteExistente.Direccion = estudiante.Direccion;
        estudianteExistente.FechaNacimiento = estudiante.FechaNacimiento;
        estudianteExistente.Apellidos = estudiante.Apellidos;
        estudianteExistente.Dni = estudiante.Dni;
        estudianteExistente.Genero = estudiante.Genero;
        estudianteExistente.GradoEstudio = estudiante.GradoEstudio;

        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status201Created, new { message = "Estudiante actualizado con exito", data = estudianteExistente });

    }


}