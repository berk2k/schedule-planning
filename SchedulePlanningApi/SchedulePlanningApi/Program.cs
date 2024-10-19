using DotNetEnv; // DotNetEnv k�t�phanesini ekliyoruz
using Microsoft.EntityFrameworkCore;
using SchedulePlanningApi.Context;
using SchedulePlanningApi.Services;
using SchedulePlanningApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// .env dosyas�n� y�kleyelim
Env.Load();

// Connection string'i .env dosyas�ndan al�yoruz
var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

// E�er connection string bo�sa, hata f�rlatabiliriz
if (string.IsNullOrEmpty(connectionString))
{
    throw new Exception("Connection string is not found in environment variables.");
}

builder.Services.AddControllers();
builder.Services.AddScoped<ITaskService, TaskService>();

// Veritaban� ba�lant�s�n� kuruyoruz
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
