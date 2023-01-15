using CustomExceptionMiddleware;
using Microservice3.DAL;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ISampleService, SampleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.MapGet("api/DIService/GetData", async (ISampleService articleService) => await articleService.GetData());
app.MapPost("api/DIService/PostData", async ([FromBody] int id, ISampleService articleService) => await articleService.PostData(id));

app.Run();
// https://localhost:7143/api/DIService/GetData