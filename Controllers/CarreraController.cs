using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
}