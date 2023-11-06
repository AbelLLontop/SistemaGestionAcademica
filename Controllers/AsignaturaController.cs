using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AsignaturaController : ControllerBase
{
    private readonly DataContext _context;
    public AsignaturaController(DataContext dataContext)
    {
        _context = dataContext;
    }
}