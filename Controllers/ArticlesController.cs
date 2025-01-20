using Microsoft.AspNetCore.Mvc;
using Newspaper.DTOs;
using Newspaper.Entities;
using Newspaper.Services;

namespace Newspaper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController(IArticlesService articlesService) : Controller
{

    [HttpGet]
    public async Task<IActionResult> GetAllArticles(
        [FromQuery] string? topic,
        [FromQuery] int? authorId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 30)
    {
        var articles = await articlesService.GetAllArticlesAsync(topic, authorId, page, pageSize);
        var response = new PagedResult<Article>(articles, articles.Count, page, pageSize);
        return Ok(response);
    }
}