using Microsoft.EntityFrameworkCore;
using KatrinasDotNetApp.Models;
using KatrinasDotNetApp.Services;

var  myAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<VideospieleDatabaseSettings>(
builder.Configuration.GetSection("VideospieleDatenbank"));
builder.Services.AddSingleton<VideospieleService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: myAllowSpecificOrigins,
        policy  =>
        {
            policy.WithOrigins("http://localhost:5084",
                "http://localhost:5173");
        });
});

builder.Services.AddControllers()
    .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);;

var app = builder.Build();
app.UseHttpsRedirection();
app.UseCors(myAllowSpecificOrigins);
app.MapControllers();
app.Run();