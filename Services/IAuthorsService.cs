using Newspaper.DTOs;
using Newspaper.Entities;

namespace Newspaper.Services;

public interface IAuthorsService
{
    Task AddAuthorsAsync(List<Author> authors);
    Task<List<AuthorDto>> GetAuthorsAsync();
    Task AddAuthorAsync(Author author);
    Task<Author?> GetAuthorByIdAsync(int id);
    Task<List<Author>> SearchAuthorByNameAsync(string name);
}