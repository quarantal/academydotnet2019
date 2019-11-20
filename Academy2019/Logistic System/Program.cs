using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic_System
{
    class Program
    {
        static void Main(string[] args)
        {
            MapManager mapManager = new MapManager();
            Console.WriteLine("Please enter starting point:");
            var from=Console.ReadLine();
            Console.WriteLine("Please enter ending point:");
            var to = Console.ReadLine();
            Console.WriteLine("Please choose a delivery strategy ('FASTEST','CHEAPEST'):");
            var strategy = Console.ReadLine().ToLower();

            Location fromLocation = mapManager.FindLocationByName(from);
            Location toLocation = mapManager.FindLocationByName(to);
            var hops = mapManager.GetHops(fromLocation, toLocation);
        }
    }
}
