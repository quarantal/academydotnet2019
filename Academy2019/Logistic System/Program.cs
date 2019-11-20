using Logistic_System.Framework;
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
            TransportCreator transportCreator = new TransportCreator();
            transportCreator.RegisterAdditionalTransport<AviationTransport.AvionTranport>();
            Console.WriteLine("Please enter starting point:");
            var from = Console.ReadLine();
            Console.WriteLine("Please enter ending point:");
            var to = Console.ReadLine();
            Console.WriteLine("Please choose a delivery strategy ('FASTEST','CHEAPEST'):");
            var strategy = Console.ReadLine();

            Location fromLocation = mapManager.FindLocationByName(from);
            Location toLocation = mapManager.FindLocationByName(to);
            var hops = mapManager.GetHops(fromLocation, toLocation); 
            foreach (var hop in hops)
            {
                ITransport mean = transportCreator.CreateTransportForHop(hop, strategy);
                Console.WriteLine($"For hop {hop.PointA.Name} - {hop.PointB.Name} vector {mean.Description} has been selected. {mean.GetTransportReport()}");
            }
            Console.ReadLine();
        }
    }
}
