namespace FuealApplication.Models
{
    public class StationStoreDatabaseSettings : IStationStoreDatabaseSettings
    {
        public  string CollectionName { get; set; } = string.Empty;
        public string CollectionName2 { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public  string DatabaseName { get; set; } = string.Empty; 
    }
}
