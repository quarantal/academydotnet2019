namespace Logistic_System
{
    public class Hop
    {
        public Hop(Location a, Location b, long distance)
        {
            PointA = a;
            PointB = b;
            Distance = distance;
        }

        public Location PointA { get; }
        public Location PointB { get; }
        public long Distance { get; }

        public bool MatchesLocation(Location loc)
        {
            return loc.Equals(PointA) || loc.Equals(PointB);
        }

        public bool HasOverlappingLocation(Hop hop)
        {
            return PointA.Equals(hop.PointA) || PointB.Equals(hop.PointB) || PointA.Equals(hop.PointB) || PointB.Equals(hop.PointA);
        }
    }
}