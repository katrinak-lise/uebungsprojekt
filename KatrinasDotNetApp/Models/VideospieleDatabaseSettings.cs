namespace KatrinasDotNetApp.Models;

public class VideospieleDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string VideospieleCollectionName { get; set; } = null!;
}