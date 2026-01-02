using DeliveryCostEstimator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostEstimator.Offers
{
    public class OfferOFR002 : IOfferStrategy
    {
        public string Code => "OFR002";

        public double GetDiscount(double deliveryCost)
        {
            return deliveryCost * 0.07;
        }

        public bool IsApplicable(double weight, double distance)
        {
            return distance >= 50 && distance <= 150 && weight >= 100 && weight <= 250;
        }
    }
}
