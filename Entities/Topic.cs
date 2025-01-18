using System.ComponentModel.DataAnnotations;

namespace Newspaper.Entities;

public class Topic
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public required string Name { get; set; }
    [Required, MaxLength(250)]
    public string? Description { get; set; }
    public List<Article>? Articles { get; set; } = [];
}