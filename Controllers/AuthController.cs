using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly DataContext _context;
    public AuthController(IConfiguration configuration, DataContext dataContext)
    {
        _configuration = configuration;
        _context = dataContext;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] Credentials credentials)
    {
        Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == credentials.Email && x.Password == credentials.Password);
        if (usuario == null)
        {
            return Unauthorized(
                new
                {
                    message = "Usuario o contraseña incorrectos"
                }
            );
        }
        string secretKey = _configuration.GetSection("JwtSettings:SecretKey").Value!;

        Claim[] claims = new Claim[]{
                new Claim("userId",usuario.Id.ToString()),
                new Claim("AdminType",usuario.TipoUsuario),
                new Claim("Email",usuario.Email)
            };

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(5),
            signingCredentials: creds
        );

        string token = new JwtSecurityTokenHandler().WriteToken(securityToken);


        return StatusCode(StatusCodes.Status200OK, new { token });
    }


}