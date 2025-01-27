using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<VideospielContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("VideospielContext") ?? throw new InvalidOperationException("Connection string 'VideospielContext' not found.")));
builder.Services.AddDbContext<VideospielDb>(opt => opt.UseInMemoryDatabase("VideospieleListe"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/testing", () => {
    return Results.Json("Helloww");
});

app.MapGet("/videospiele", async (VideospielDb db) =>
    await db.Videospiele.ToListAsync());

//app.MapGet("/videospiele/complete", async (VideospielDb db) =>
//    await db.Videospiele.Where(v => v.IsComplete).ToListAsync());

app.MapGet("/videospiele/{id}", async (int id, VideospielDb db) =>
    await db.Videospiele.FindAsync(id)
        is Videospiel todo
            ? Results.Ok(todo)
            : Results.NotFound());

app.MapPost("/videospiele", async (Videospiel videospiel, VideospielDb db) =>
{
    db.Videospiele.Add(videospiel);
    await db.SaveChangesAsync();

    return Results.Created($"/videospiele/{videospiel.Id}", videospiel);
});

app.MapPut("/videospiele/{id}", async (int id, Videospiel inputVideospiel, VideospielDb db) =>
{
    var videospiel = await db.Videospiele.FindAsync(id);

    if (videospiel is null) return Results.NotFound();

    videospiel.Titel = inputVideospiel.Titel;
    videospiel.Beschreibung = inputVideospiel.Beschreibung;
    videospiel.Entwickler = inputVideospiel.Entwickler;
    videospiel.Erscheinungsjahr = inputVideospiel.Erscheinungsjahr;
    videospiel.Bewertung = inputVideospiel.Bewertung;
    videospiel.Trailer = inputVideospiel.Trailer;
    videospiel.Console = inputVideospiel.Console;

    await db.SaveChangesAsync();

    return Results.NoContent();
});

app.MapDelete("/videospiele/{id}", async (int id, VideospielDb db) =>
{
    if (await db.Videospiele.FindAsync(id) is Videospiel videospiel)
    {
        db.Videospiele.Remove(videospiel);
        await db.SaveChangesAsync();
        return Results.NoContent();
    }

    return Results.NotFound();
});

app.Run();