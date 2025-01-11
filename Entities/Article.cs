using System.ComponentModel.DataAnnotations;

namespace Newspaper.Entities;

public class Article
{
    public int Id { get; set; }
    
    [Required, MaxLength(250)]
    public required string Title { get; set; }

    [Required, MaxLength(500000)] 
    public required string Body { get; set; }

    public bool IsPublished { get; set; }
    
    public DateTime? PublishDate { get; set; }
    
    public DateTime? LastEditDate { get; set; }

    public List<Author> Authors { get; set; }

    [MaxLength(250)]
    public string? Section { get; set; }
}