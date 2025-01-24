using Newspaper.Entities;

namespace Newspaper.Services.Interfaces;

public interface ITopicsService
{
    Task AddTopicsAsync(List<Topic> topics);
    Task<List<Topic>> GetTopicsAsync();
    Task<Topic> AddTopicAsync(Topic topic);
    Task DeleteTopicAsync(int id);
    Task UpdateTopicAsync(Topic topic);
    Task<Topic?> GetTopicByIdAsync(int id);
    Task<List<Topic>?> GetTopicsByIdsAsync(List<int> ids);
}