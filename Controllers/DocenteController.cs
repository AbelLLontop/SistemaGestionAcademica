using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class DocenteController : ControllerBase
{
    private readonly DataContext _context;
    public DocenteController(DataContext dataContext)
    {
        _context = dataContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Docente>> GetDocente(int id)
    {
        Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (usuario == null)
        {
            return NotFound();
        }
        Docente docente = new Docente
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

        return docente;
    }


    [Authorize(Policy = "Admin,Docente")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDocente(int id, [FromBody] DocenteUpdate docente)
    {
        Usuario? docenteExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (docenteExistente == null)
        {
            return NotFound();
        }

        Usuario? usuarioExistenteDni = await _context.Usuarios.FirstOrDefaultAsync(x => x.Dni == docente.Dni);
        if (usuarioExistenteDni != null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = "El dni ya existe" });
        }

        docenteExistente.Nombre = docente.Nombre;
        docenteExistente.Telefono = docente.Telefono;
        docenteExistente.Direccion = docente.Direccion;
        docenteExistente.FechaNacimiento = docente.FechaNacimiento;
        docenteExistente.Apellidos = docente.Apellidos;
        docenteExistente.Dni = docente.Dni;
        docenteExistente.Genero = docente.Genero;
        docenteExistente.GradoEstudio = docente.GradoEstudio;

        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status201Created, new { message = "Docente actualizado con exito", data = docenteExistente });

    }


}