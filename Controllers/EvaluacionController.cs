using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class EvaluacionController : ControllerBase
{
    private readonly DataContext _context;
    public EvaluacionController(DataContext dataContext)
    {
        _context = dataContext;
    }
}