using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
}