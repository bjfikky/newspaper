using Microsoft.EntityFrameworkCore;
using Newspaper.Data;
using Newspaper.Entities;
using Newspaper.Services.Interfaces;

namespace Newspaper.Services;

public class ArticlesService(NewspaperDbContext context) : IArticlesService
{
    public async Task<Article> AddArticleAsync(Article article)
    {
        await context.Articles.AddAsync(article);
        await context.SaveChangesAsync();
        return article;
    }

    public async Task<Article?> GetArticleAsync(int id)
    {
        return await context.Articles
            .Include(a => a.Authors)
            .Include(a => a.Topics)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Article>> GetAllArticlesAsync(string? topic, int? authorId, int page, int pageSize)
    {
        page = page < 1 ? 1 : page;
        pageSize = pageSize < 1 ? 30 : pageSize;
        
        var query = context.Articles
            .Where(a => a.IsPublished)
            .OrderByDescending(a => a.PublishDate)
            .Include(a => a.Authors)
            .Include(a => a.Topics)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(topic))
            query = query.Where(a => a.Topics != null && a.Topics.Any(t => t.Name == topic));

        if (authorId != null || authorId > 0)
            query = query.Where(a => a.Authors.Any(author => author.Id == authorId));

        return await query
            .Skip((page - 1) * pageSize) // Skip records from previous pages
            .Take(pageSize)             // Take only the specified number of records
            .ToListAsync();
    }

    public async Task UpdateArticleAsync(Article article)
    {
        if (await context.Articles.FindAsync(article.Id) == null)
            throw new KeyNotFoundException();
        
        context.Articles.Update(article);
        await context.SaveChangesAsync();
    }

    public async Task DeleteArticleAsync(int id)
    {
        var article = await context.Articles.FindAsync(id);
        if (article == null)
            throw new KeyNotFoundException($"Article with id {id} was not found");
        
        context.Articles.Remove(article);
        await context.SaveChangesAsync();
    }
}