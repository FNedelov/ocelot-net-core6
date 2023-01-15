using CustomExceptionMiddleware;
using Microservice2.MinimalAPIs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
};

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();
app.MinAPIMethod1();
app.MinAPIMethod2();
app.MinAPIMethod3();
app.MinAPIMethod4();

app.Run();
// https://localhost:7215/api/MinAPI1/MinAPIMethod1