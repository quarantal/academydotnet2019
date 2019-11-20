using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic_System.Framework
{
    public interface ITransport
    {
        string Description { get; }
        void DoRoute(string from, string to, MapManager map);
        long GetCost();
        long GetDuration();
        string GetTransportReport();
    }
}
