using FuealApplication.Models;
using MongoDB.Driver;

namespace FuealApplication.Services
{
    public class StationService : IStationServices
    {
        private readonly IMongoCollection<Station> _stations;
        public StationService(IStationStoreDatabaseSettings settings, IMongoClient mongoClient)
        {
          var database= mongoClient.GetDatabase(settings.DatabaseName);
            _stations = database.GetCollection<Station>(settings.CollectionName);
        }
        public Station CreateStation(Station station)
        {
            //throw new NotImplementedException();
            _stations.InsertOne(station);
            return station;
        }

        public Station GetStation(string id)
        {
            //throw new NotImplementedException();
            return _stations.Find(station => station.Id == id).FirstOrDefault();
          
        }

        public List<Station> GetStations()
        {
            //throw new NotImplementedException();
            return _stations.Find(station => true).ToList();
        }

        public void RemoveStation(string id)
        {
            //throw new NotImplementedException();
            _stations.DeleteOne(station => station.Id == id);   
        }

        public void UpdateStation(string id, Station station)
        {
            //throw new NotImplementedException();
            _stations.ReplaceOne(station => station.Id == id, station);
        }
    }
}
