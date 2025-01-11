using Microsoft.AspNetCore.Mvc;
using Newspaper.Entities;
using Newspaper.Services;

namespace Newspaper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController(IAuthorsService authorsService) : Controller
{
    // GET
    public async Task<IActionResult> Index()
    {
        return Ok(await authorsService.GetAuthorsAsync());
    }
    
    // GET
    public async Task<IActionResult> Index(int id)
    {
        return Ok(await authorsService.GetAuthorsAsync());
    }
}