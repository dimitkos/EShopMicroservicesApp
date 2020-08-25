namespace Catalog.API.Settings
{
    public interface ICatalogDatabaseSettings
    {
        string ConnactionString { get; set; }
        string DatabaseName { get; set; }
        string CollactionName { get; set; }
    }
}
