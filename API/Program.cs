using API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyHeader().WithOrigins("http://localhost:4200", "https://localhost:4200")); // Configure the HTTP request pipeline

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();