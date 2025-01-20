namespace Newspaper.DTOs;

public record ArticleDto(
    int? Id,
    string Title,
    string? Subtitle,
    List<int> AuthorIds,
    List<int> TopicIds,
    string? ImageUrl,
    string Body,
    bool IsPublished)
{
    public ArticleDto(
        string Title,
        string? Subtitle,
        List<int> AuthorIds,
        List<int> TopicIds,
        string? ImageUrl,
        string Body,
        bool IsPublished) : this(null, Title, Subtitle, AuthorIds, TopicIds, ImageUrl, Body, IsPublished) { }
    
    public ArticleDto() : this(null, string.Empty, null, [], [], null, string.Empty, false) { }
}