using Microsoft.AspNetCore.Mvc;
using Newspaper.DTOs;
using Newspaper.Entities;
using Newspaper.Services.Interfaces;

namespace Newspaper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ArticlesController(IArticlesService articlesService, IAuthorsService authorsService, ITopicsService topicsService) : Controller
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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetArticleById(int id)
    {
        var article = await articlesService.GetArticleAsync(id);
        if (article == null)
            return NotFound();
        
        var articleDto = new ArticleDto(
            article.Id, 
            article.Title, 
            article.SubTitle, 
            article.Authors.Select(a => a.Id).ToList(),
            article.Topics.Select(a => a.Id).ToList(),
            article.ImageUrl,
            article.Body,
            article.IsPublished
            );
        
        return Ok(articleDto);
    }

    [HttpPost]
    // TODO: Role needed for creating an Article. Like an Author role
    public async Task<IActionResult> CreateArticle(ArticleDto articleDto)
    {
        var authors = await authorsService.GetAuthorsByIdsAsync(articleDto.AuthorIds);
        var topics = await topicsService.GetTopicsByIdsAsync(articleDto.TopicIds);
        
        if (authors == null || authors.Count == 0)
            return BadRequest(new { message = "Authors not found. Provide an author first." });

        // Note that creating an article does not publish it, hence why we aren't setting IsPublished
        var article = new Article
        {
            Title = articleDto.Title,
            SubTitle = articleDto.Subtitle,
            Body = articleDto.Body,
            Authors = authors,
            ImageUrl = articleDto.ImageUrl,
            Topics = topics,
            LastEditDate = DateTime.UtcNow,
            IsPublished = false
        };
        
        article = await articlesService.AddArticleAsync(article);
        return Ok(article);
    }
}