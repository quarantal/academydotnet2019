using System;

namespace AviationTransport
{
    public class AvionTranport : Logistic_System.Framework.ITransport
    {
        const long costPerKm= 10;
        const long pacePerKm = 1;

        public string Description => "Airplane";

        public void DoRoute(string from, string to, Logistic_System.Framework.MapManager map)
        {
            throw new NotImplementedException();
        }

        public long GetCost()
        {
            return costPerKm;
        }

        public long GetDuration()
        {
            return pacePerKm;
        }

        public string GetTransportReport()
        {
            return "";
        }
    }
}
