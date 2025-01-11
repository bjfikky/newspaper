using Microsoft.EntityFrameworkCore;
using Newspaper.Data;
using Newspaper.DTOs;
using Newspaper.Entities;

namespace Newspaper.Services;

public class AuthorsService(NewspaperDbContext context) : IAuthorsService
{
    public Task AddAuthorsAsync(List<Author> authors)
    {
        throw new NotImplementedException();
    }

    public async Task<List<AuthorDto>> GetAuthorsAsync()
    {
        return await context.Authors
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .Select(a => new AuthorDto(a.Id, a.FirstName, a.LastName))
            .ToListAsync();
    }

    public async Task AddAuthorAsync(Author author)
    {
        await context.Authors.AddAsync(author);
        await context.SaveChangesAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        return await context.Authors.FindAsync(id);
    }

    public async Task<List<Author>> SearchAuthorByNameAsync(string name)
    {
        return await context.Authors
            .Where(a => EF.Functions.Like(a.FirstName, $"%{name}%") || 
               EF.Functions.Like(a.LastName, $"%{name}%")).ToListAsync();
    }
}