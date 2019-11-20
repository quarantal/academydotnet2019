namespace Logistic_System
{
    public class Location
    {
        public Location(string name, bool isAirportAvailable, bool isTrainStationAvailable)
        {
            Name = name;
            IsAirportAvailable = isAirportAvailable;
            IsTrainStationAvailable = isTrainStationAvailable;
        }

        public string Name { get; }
        public bool IsAirportAvailable { get; }
        public bool IsTrainStationAvailable { get; }

        public override bool Equals(object obj)
        {
            Location objLocation = obj as Location;
            if (objLocation != null)
            {
                return this.Name == objLocation.Name;
            }
            return false;
        }
    }
}