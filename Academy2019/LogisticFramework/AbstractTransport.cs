using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic_System.Framework
{
    internal abstract class AbstractTransport : ITransport
    {
        public abstract string Description { get; }

        public abstract void DoRoute(string from, string to, MapManager map);

        public abstract long GetCost();

        public abstract long GetDuration();

        public string GetTransportReport()
        {
            return $"This hop costed {GetCost()} € and lasted {GetDuration()} minutes";
        }
        
    }
}
