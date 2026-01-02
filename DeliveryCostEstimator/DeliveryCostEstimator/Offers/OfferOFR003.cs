using DeliveryCostEstimator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostEstimator.Offers
{
    public class OfferOFR003 : IOfferStrategy
    {
        public string Code => "OFR003";

        public double GetDiscount(double deliveryCost)
        {
            return deliveryCost * 0.05;
        }

        public bool IsApplicable(double weight, double distance)
        {
            return distance >= 50 && distance <= 250 && weight >= 10 && weight <= 150;
        }
    }
}
