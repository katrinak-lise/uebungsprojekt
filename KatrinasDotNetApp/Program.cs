using Microsoft.EntityFrameworkCore;
using KatrinasDotNetApp.Models;
using KatrinasDotNetApp.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<VideospieleDatabaseSettings>(
builder.Configuration.GetSection("VideospieleDatenbank"));
builder.Services.AddSingleton<VideospieleService>();
builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();