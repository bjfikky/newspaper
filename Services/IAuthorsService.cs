using Newspaper.DTOs;
using Newspaper.Entities;

namespace Newspaper.Services;

public interface IAuthorsService
{
    Task AddAuthorsAsync(List<Author> authors);
    Task<List<Author>> GetAuthorsAsync();
    Task<Author> AddAuthorAsync(Author author);
    Task DeleteAuthorAsync(int id);
    Task UpdateAuthorAsync(Author author);
    Task<Author?> GetAuthorByIdAsync(int id);
    Task<List<Author>> SearchAuthorByNameAsync(string name);
}