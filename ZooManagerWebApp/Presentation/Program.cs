using ZooManagerWebApp.Application;
using ZooManagerWebApp.Domain.Interfaces;
using ZooManagerWebApp.Domain.ValueObjects.AnimalValueObjects;
using ZooManagerWebApp.Domain.ValueObjects.EnclosureValueObjects;
using ZooManagerWebApp.Domain.ValueObjects.FeedingScheduleValueObjects;
using ZooManagerWebApp.Domain.Entities;
using ZooManagerWebApp.Infrastructure.Storages;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new Dictionary<AnimalId, Animal>());
builder.Services.AddSingleton(new Dictionary<EnclosureId, Enclosure>());
builder.Services.AddSingleton(new Dictionary<FeedingScheduleId, FeedingSchedule>());

builder.Services.AddScoped<ZooStatisticsService>();
builder.Services.AddScoped<IAnimalStorage, InMemoryAnimalStorage>();
builder.Services.AddScoped<IEnclosureStorage, InMemoryEnclosureStorage>();
builder.Services.AddScoped<IFeedingScheduleStorage, InMemoryFeedingScheduleStorage>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();