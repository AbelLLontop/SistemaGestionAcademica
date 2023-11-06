using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        // string? userId = User.FindFirst("userId")?.Value;
        // string? adminType = User.FindFirst("AdminType")?.Value;
        // return StatusCode(StatusCodes.Status200OK, new { userId, adminType });
    }
    [HttpPost]
    public async Task<ActionResult<Usuario>> CreateUser(UsuarioCreate usuario)
    {
        Usuario? usuarioExistente = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == usuario.Email);
        if (usuarioExistente != null)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { message = "El usuario ya existe" });
        }
        Usuario usuarioNuevo = new Usuario
        {
            Email = usuario.Email,
            Password = usuario.Password,
            TipoUsuario = usuario.TipoUsuario,
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
        usuarioExistente.Email = usuario.Email;
        usuarioExistente.TipoUsuario = usuario.TipoUsuario;
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