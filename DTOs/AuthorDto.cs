namespace Newspaper.DTOs;

public record AuthorDto(int? Id, string FirstName, string LastName)
{
    public AuthorDto(string FirstName, string LastName)
        : this(null, FirstName, LastName)
    {
    }
    
    public AuthorDto() 
        : this(null, string.Empty, string.Empty)
    {
    }
}