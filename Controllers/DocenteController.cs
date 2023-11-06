using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
}