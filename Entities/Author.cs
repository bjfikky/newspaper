using System.ComponentModel.DataAnnotations;

namespace Newspaper.Entities;

public class Author
{
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public required string FirstName { get; set; }
    
    [Required, MaxLength(50)]
    public required string LastName { get; set; }

    public List<Article>? Articles { get; set; }
}