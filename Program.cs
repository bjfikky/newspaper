using Newspaper.Data;
using Newspaper.Services;
using Newspaper.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<NewspaperDbContext>();

builder.Services.AddScoped<IAuthorsService, AuthorsService>();
builder.Services.AddScoped<IArticlesService, ArticlesService>();
builder.Services.AddScoped<ITopicsService, TopicsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();