using FuealApplication.Models;

namespace FuealApplication.Services
{
    public interface IStationServices
    {

        List<Station> GetStations();
        Station GetStation(string id);
        Station CreateStation(Station station);
        void UpdateStation(string id,Station station);
        void RemoveStation(string id);
    }
}
