using Newspaper.Entities;

namespace Newspaper.Services;

public interface IArticlesService
{
    Task<Article> AddArticleAsync(Article article);
    Task<Article?> GetArticleAsync(int id);
    Task<List<Article>> GetAllArticlesAsync(string? topic, int? authorId, int page, int pageSize);
    Task UpdateArticleAsync(Article article);
    Task DeleteArticleAsync(int id);
}