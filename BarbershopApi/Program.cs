using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using BarbershopApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add this line after builder initialization
builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7234; // Use your preferred port number
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddDbContext<BookingContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Add these lines before app.Run()
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();