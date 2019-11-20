using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic_System.Framework
{
    public class TransportCreator
    {
        private List<ITransport> _knownTranports=new List<ITransport> ();

        public TransportCreator()
        {
            // register built-in transports
            RegisterAdditionalTransport<RailwayTransport>();
            RegisterAdditionalTransport<RoadwayTransport>();
        }
        public ITransport CreateTransportForHop(Hop hop, string strategy)
        {
            if (strategy == "FASTEST")
            {
                long duration = -1;
                ITransport fastestTranport = null;
                foreach (ITransport transport in _knownTranports)
                {
                    if (duration == -1 || transport.GetDuration() < duration)
                    {
                        duration = transport.GetDuration();
                        fastestTranport = transport;
                    }
                }
                return fastestTranport;
            }
            if (strategy == "CHEAPEST")
            {
                long cost = -1;
                ITransport cheapestTransport = null;
                foreach (ITransport transport in _knownTranports)
                {
                    if (cost == -1 || transport.GetCost() < cost)
                    {
                        cost = transport.GetCost();
                        cheapestTransport = transport;
                    }
                }
                return cheapestTransport;
            }
            throw new ApplicationException("Cannot find appropriate transport for strategy");
        }

        public void RegisterAdditionalTransport<T>() where T : ITransport, new()
        {
            _knownTranports.Add(new T());
        }
    }

    class RailwayTransport : AbstractTransport
    {
        const long costPerKm = 5;
        const long pacePerKm = 5;
 
        public override string Description => "Railway";


        public override void DoRoute(string from, string to, MapManager map)
        {

        }

        public override long GetCost()
        {
            return costPerKm;
        }

        public override long GetDuration()
        {
            return pacePerKm;
        }
    }

    class RoadwayTransport : AbstractTransport
    {
        const long costPerKm = 3;
        const long pacePerKm = 2;

        public override string Description => "Road";

        public override void DoRoute(string from, string to, MapManager map)
        {
            throw new NotImplementedException();
        }

        public override long GetCost()
        {
            return costPerKm;
        }

        public override long GetDuration()
        {
            return pacePerKm;
        }
    }
}
