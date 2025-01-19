using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Newspaper.Entities;

[Index(nameof(Name), IsUnique = true)]
public class Topic
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public required string Name { get; set; }
    [Required, MaxLength(250)]
    public string? Description { get; set; }
    public List<Article>? Articles { get; set; } = [];
}