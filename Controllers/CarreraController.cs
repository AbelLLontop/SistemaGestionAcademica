using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CarreraController : ControllerBase
{
    private readonly DataContext _context;
    public CarreraController(DataContext dataContext)
    {
        _context = dataContext;
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Carrera>>> GetCarreras()
    {
        return await _context.Carreras.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Carrera>> GetCarrera(int id)
    {
        Carrera? carrera = await _context.Carreras.FirstOrDefaultAsync(x => x.Id == id);
        if (carrera == null)
        {
            return NotFound();
        }
        return carrera;
    }

    [Authorize(Policy = "Admin")]
    [HttpPost]
    public async Task<ActionResult<Carrera>> CreateCarrera([FromBody] CarreraCreate carrera)
    {
        Carrera newCarrera = new Carrera
        {
            Nombre = carrera.Nombre,
            Descripcion = carrera.Descripcion
        };
        _context.Carreras.Add(newCarrera);
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status201Created, new { message = "Carrera creada con exito", data = newCarrera });
    }

    [Authorize(Policy = "Admin")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCarrera(int id, [FromBody] CarreraUpdate carrera)
    {
        Carrera? carreraExistente = await _context.Carreras.FirstOrDefaultAsync(x => x.Id == id);
        if (carreraExistente == null)
        {
            return NotFound();
        }
        carreraExistente.Nombre = carrera.Nombre;
        carreraExistente.Descripcion = carrera.Descripcion;
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status200OK, new { message = "Carrera actualizada con exito", data = carreraExistente });
    }

    [Authorize(Policy = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCarrera(int id)
    {
        Carrera? carreraExistente = await _context.Carreras.FirstOrDefaultAsync(x => x.Id == id);
        if (carreraExistente == null)
        {
            return NotFound();
        }
        _context.Carreras.Remove(carreraExistente);
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status200OK, new { message = "Carrera eliminada con exito", data = carreraExistente });
    }

   
}