using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Newspaper.Entities;

public class Author
{
    public int Id { get; set; }
    
    [Required, MaxLength(50)]
    public required string FirstName { get; set; }
    
    [Required, MaxLength(50)]
    public required string LastName { get; set; }
    //TODO: remove and use DTO
    [JsonIgnore]
    public List<Article>? Articles { get; set; } = [];
}