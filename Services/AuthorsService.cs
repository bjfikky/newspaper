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

    public async Task<List<Author>> GetAuthorsAsync()
    {
        return await context.Authors
            .OrderBy(a => a.FirstName)
            .ThenBy(a => a.LastName)
            .ToListAsync();
    }

    public async Task<Author> AddAuthorAsync(Author author)
    {
        await context.Authors.AddAsync(author);
        await context.SaveChangesAsync();
        return author;
    }

    public async Task DeleteAuthorAsync(int id)
    {
        var author = await context.Authors.FindAsync(id);
        if (author == null)
        {
            throw new KeyNotFoundException($"Author with id {id} not found");
        }
        context.Authors.Remove(author);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        if (await context.Authors.FindAsync(author.Id) == null)
        {
            throw new KeyNotFoundException($"Author with id {author.Id} not found");
        }
        context.Authors.Update(author);
        await context.SaveChangesAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        return await context.Authors.FindAsync(id);
    }
    
    public async Task<List<Author>?> GetAuthorsByIdsAsync(List<int> ids)
    {
        return await context.Authors.Where(author => ids.Contains(author.Id))
            .ToListAsync();
    }

    public async Task<List<Author>> SearchAuthorByNameAsync(string name)
    {
        return await context.Authors
            .Where(a => EF.Functions.Like(a.FirstName, $"%{name}%") || 
               EF.Functions.Like(a.LastName, $"%{name}%")).ToListAsync();
    }
}