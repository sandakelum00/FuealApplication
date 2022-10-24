namespace FuealApplication.Models
{
    public interface IStationStoreDatabaseSettings
    {
        string CollectionName { get; set; }
        string CollectionName2 { get; set; }
        string ConnectionString { get; set; }   

        string DatabaseName { get; set; }
    }
}
