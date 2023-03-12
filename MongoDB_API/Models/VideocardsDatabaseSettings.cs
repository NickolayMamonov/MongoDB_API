namespace MongoDB_API.Models;

public class VideocardsDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string VideocardsCollectionName { get; set; } = null!;
}