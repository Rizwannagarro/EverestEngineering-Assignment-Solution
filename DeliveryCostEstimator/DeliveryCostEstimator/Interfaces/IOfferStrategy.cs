using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostEstimator.Interfaces
{
    public interface IOfferStrategy
    {
        string Code {  get; }
        bool IsApplicable(double weight, double distance);
        double GetDiscount(double deliveryCost);
    }
}
