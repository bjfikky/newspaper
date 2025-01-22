namespace Newspaper.DTOs;

public record ArticleDto(
    int? Id,
    string Title,
    string? Subtitle,
    List<int> AuthorIds,
    List<int> TopicIds,
    string? ImageUrl,
    string Body,
    bool IsPublished,
    DateTime? PublishDate,
    DateTime? LastEditDate)
{
    public ArticleDto(int Id, string Title,
        string? Subtitle,
        List<int> AuthorIds,
        List<int> TopicIds,
        string? ImageUrl,
        string Body,
        bool IsPublished) : this(Id, Title, Subtitle, AuthorIds, TopicIds, ImageUrl, Body, IsPublished, null, null) { }
    
    public ArticleDto(
        string Title,
        string? Subtitle,
        List<int> AuthorIds,
        List<int> TopicIds,
        string? ImageUrl,
        string Body,
        bool IsPublished,
        DateTime PublishDate,
        DateTime LastEditDate) : this(null, Title, Subtitle, AuthorIds, TopicIds, ImageUrl, Body, IsPublished, PublishDate, LastEditDate) { }
    
    public ArticleDto() : this(null, string.Empty, null, [], [], null, string.Empty, false, null, null) { }
}