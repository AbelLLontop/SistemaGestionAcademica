using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MatriculaController : ControllerBase
{
    private readonly DataContext _context;
    public MatriculaController(DataContext dataContext)
    {
        _context = dataContext;
    }
}