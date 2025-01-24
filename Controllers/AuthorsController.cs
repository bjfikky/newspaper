using Microsoft.AspNetCore.Mvc;
using Newspaper.DTOs;
using Newspaper.Entities;
using Newspaper.Services.Interfaces;

namespace Newspaper.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorsController(IAuthorsService authorsService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await authorsService.GetAuthorsAsync();
        var authorDto = authors
            .Select(author => new AuthorDto(author.Id, author.FirstName, author.LastName)).ToList();
        return Ok(authorDto);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await authorsService.GetAuthorByIdAsync(id);
        if (author == null)
            return NotFound(new { message = "Author not found." });
        
        return Ok(author);
    }
    
    [HttpPost]
    // TODO: Role needed to be able to create an Author. An Admin Role
    public async Task<IActionResult> SaveAuthor(AuthorDto authorDto)
    {
        var author = new Author
        {
            FirstName = authorDto.FirstName,
            LastName = authorDto.LastName
        };
        var savedAuthor = await authorsService.AddAuthorAsync(author);
        return Ok(new AuthorDto(){Id = savedAuthor.Id , FirstName = savedAuthor.FirstName, LastName = savedAuthor.LastName});
    }

    [HttpDelete("{id:int}")]
    // TODO: Role needed to be able to create an Author. An Admin Role
    public async Task<IActionResult> DeleteAuthor(int id)
    {
        var author = await authorsService.GetAuthorByIdAsync(id);
        if (author == null) 
            return NotFound(new {message = "Author not found"});
        
        await authorsService.DeleteAuthorAsync(author.Id);
        return NoContent();
    }

    [HttpPut("{id:int}")]
    // TODO: Role needed to be able to create an Author. An Admin Role
    public async Task<IActionResult> UpdateAuthor(int id, AuthorDto authorDto)
    {
        var author = await authorsService.GetAuthorByIdAsync(id);
        if (author == null)
            return NotFound(new {message = "Author not found."});

        if (authorDto.Id == null || authorDto.Id != author.Id)
        {
            return BadRequest(new { message = "Id mismatch" });
        }
        
        author.FirstName = authorDto.FirstName;
        author.LastName = authorDto.LastName;
        
        await authorsService.UpdateAuthorAsync(author);
        return NoContent();
    }
}