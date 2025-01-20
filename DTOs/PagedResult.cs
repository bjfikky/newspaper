using System.Text.Json.Serialization;

namespace Newspaper.DTOs;

public record PagedResult<T>(
    List<T> Items,
    int TotalCount,
    int Page,
    int PageSize
)
{
    [JsonInclude]
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    [JsonInclude]
    public bool HasPreviousPage => Page > 1;
    [JsonInclude]
    public bool HasNextPage => Page < TotalPages;
}
