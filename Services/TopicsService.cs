using Microsoft.EntityFrameworkCore;
using Newspaper.Data;
using Newspaper.Entities;
using Newspaper.Services.Interfaces;

namespace Newspaper.Services;

public class TopicsService(NewspaperDbContext context) : ITopicsService
{
    public async Task AddTopicsAsync(List<Topic> topics)
    {
        await context.Topics.AddRangeAsync(topics);
        await context.SaveChangesAsync();
    }

    public async Task<List<Topic>> GetTopicsAsync()
    {
        return await context.Topics.OrderBy(t => t.Name).ToListAsync();
    }

    public async Task<Topic> AddTopicAsync(Topic topic)
    {
        await context.Topics.AddAsync(topic);
        await context.SaveChangesAsync();
        return topic;
    }

    public async Task DeleteTopicAsync(int id)
    {
        var topic = await context.Topics.FindAsync(id);
        if (topic == null)
            throw new KeyNotFoundException($"Topic with id {id} was not found");

        context.Topics.Remove(topic);
        await context.SaveChangesAsync();
    }

    public async Task UpdateTopicAsync(Topic topic)
    {
        if (await context.Topics.FindAsync(topic.Id) == null)
            throw new KeyNotFoundException($"Topic with id {topic.Id} was not found");
        
        context.Topics.Update(topic);
        await context.SaveChangesAsync();
    }

    public async Task<Topic?> GetTopicByIdAsync(int id)
    {
        return await context.Topics.FindAsync(id);
    }

    public async Task<List<Topic>?> GetTopicsByIdsAsync(List<int> ids)
    {
        return await context.Topics.Where(t => ids.Contains(t.Id)).ToListAsync();
    }
}