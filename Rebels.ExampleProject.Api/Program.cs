using Rebels.ExampleProject.Core;
using Rebels.ExampleProject.Core.AutoMapper;
using Rebels.ExampleProject.Core.Services;
using Rebels.ExampleProject.Core.Services.Implementations;
using Rebels.ExampleProject.Data;
using Rebels.ExampleProject.Data.Repositories;
using Rebels.ExampleProject.Data.Repositories.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddAutoMapper(typeof(AutomapperProfile));

builder.Services.AddTransient<IRebelRepository, RebelRepository>();
builder.Services.AddTransient<IRebelService, RebelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DataContext>();

    if (!db.Database.EnsureCreated()) throw new InvalidProgramException("Creating and seeding of memory database failed.");
}

app.Run();
