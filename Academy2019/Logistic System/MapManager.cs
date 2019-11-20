using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic_System
{
    public class MapManager
    {
        private readonly List<Location> _locations = new List<Location>();
        private readonly List<Hop> _hops = new List<Hop>();
        public MapManager()
        {
            _locations.Add(new Location("Milano", true, true));
            _locations.Add(new Location("Roma", true, true));
            _locations.Add(new Location("Bari", false, true));
            _locations.Add(new Location("Taranto", false, false));

            _hops.Add(new Hop(_locations[0], _locations[1], 574)); // from Milano to Roma
            _hops.Add(new Hop(_locations[1], _locations[2], 372)); // from Roma to Bari
            _hops.Add(new Hop(_locations[2], _locations[3], 93)); // from Bari to Taranto
        }

        public Location FindLocationByName(string name)
        {
            return _locations.First(p => p.Name.ToLower() == name.ToLower());
        }

        public List<Hop> GetHops(Location from, Location to)
        {
            List<Hop> hopsFromDepartureToDestination = new List<Hop>();
            var startingHop = _hops.FirstOrDefault(p => p.MatchesLocation(from));
            if (startingHop == null)
            {
                throw new ApplicationException($"Cannot find a valid hop between {from.Name} to {to.Name}");
            }
            hopsFromDepartureToDestination.Add(startingHop);
            var lastHop = startingHop;
            while (!lastHop.MatchesLocation(to)) // while I didn't reach destination
            {
                // I look for another from connection (hop) from lastHop possibly to final destination or intermediate destination
                var nextHop = _hops.FirstOrDefault(p => p.HasOverlappingLocation(lastHop) && !hopsFromDepartureToDestination.Contains(p));
                if (nextHop == null)
                {
                    throw new ApplicationException($"Cannot find a valid hop between {from.Name} to {to.Name}");
                }
                hopsFromDepartureToDestination.Add(nextHop);
                lastHop = nextHop;
            }
            return hopsFromDepartureToDestination;
        }
    }
}
