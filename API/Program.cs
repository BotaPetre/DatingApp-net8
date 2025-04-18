using API.Extensions;
using API.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(x => x.AllowAnyHeader().AllowAnyHeader().WithOrigins("http://localhost:4200", "https://localhost:4200")); // Configure the HTTP request pipeline

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();