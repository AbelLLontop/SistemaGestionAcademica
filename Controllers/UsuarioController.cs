using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "Admin")]
public class UsuarioController : ControllerBase
{
    private readonly DataContext _context;
    public UsuarioController(DataContext dataContext)
    {
        _context = dataContext;
    }

    [HttpGet]
    //return object by token
    public async Task<ActionResult<IEnumerable<Usuario>>> ListarUsusarios()
    {
        return await _context.Usuarios.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Usuario>> GetUser(int id)
    {
        Usuario? usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (usuarioExistente == null)
        {
            return NotFound();
        }
        return StatusCode(StatusCodes.Status200OK, new { message = "Usuario encontrado", data = usuarioExistente });
    }



    [HttpPost]
    public async Task<ActionResult<Usuario>> CreateUser(UsuarioCreate usuario)
    {
        Usuario? usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);
        if (usuarioExistente != null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = $"El usuario con el correo institucional {usuario.Email} ya existe" });
        }
        Usuario usuarioNuevo = new Usuario
        {
            Email = usuario.Email,
            Password = usuario.Password,
            TipoUsuario = usuario.TipoUsuario,
            Nombre = usuario.Nombre,
            Apellidos = usuario.Apellidos,
            Telefono = usuario.Telefono,
            Direccion = usuario.Direccion,
            Dni = usuario.Dni,
            Genero = usuario.Genero,
            GradoEstudio = usuario.GradoEstudio,
            FechaNacimiento = usuario.FechaNacimiento

        };
        _context.Usuarios.Add(usuarioNuevo);
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status201Created, new { message = "Usuario creado con exito", data = usuarioNuevo });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id, [FromBody] UsuarioUpdate usuario)
    {
        Usuario? usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (usuarioExistente == null)
        {
            return NotFound();
        }
        if (usuarioExistente.Email != usuario.Email)
        {
            Usuario? usuarioExistenteEmail = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);
            if (usuarioExistenteEmail != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "El email ya existe" });
            }
        }
        if (usuarioExistente.Email != usuario.Email)
        {
            Usuario? usuarioExistenteDni = await _context.Usuarios.FirstOrDefaultAsync(x => x.Dni == usuario.Dni);
            if (usuarioExistenteDni != null)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "El dni ya existe" });
            }
        }
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.TipoUsuario = usuario.TipoUsuario;
        usuarioExistente.Nombre = usuario.Nombre;
        usuarioExistente.Apellidos = usuario.Apellidos;
        usuarioExistente.Telefono = usuario.Telefono;
        usuarioExistente.Direccion = usuario.Direccion;
        usuarioExistente.Dni = usuario.Dni;
        usuarioExistente.Genero = usuario.Genero;
        usuarioExistente.GradoEstudio = usuario.GradoEstudio;
        usuarioExistente.FechaNacimiento = usuario.FechaNacimiento;

        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status200OK, new { message = "Usuario actualizado con exito", data = usuarioExistente });
    }
    [HttpPut("password/{id}")]
    public async Task<IActionResult> PutPassword(int id, [FromBody] PasswordUpdate password)
    {
        Usuario? usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (usuarioExistente == null)
        {
            return NotFound();
        }
        usuarioExistente.Password = password.Password;
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status200OK, new { message = "Contraseña actualizada con exito", data = usuarioExistente });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        Usuario? usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        if (usuarioExistente == null)
        {
            return NotFound();
        }
        _context.Usuarios.Remove(usuarioExistente);
        await _context.SaveChangesAsync();
        return StatusCode(StatusCodes.Status200OK, new { message = "Usuario eliminado con exito" });
    }



}