using DeliveryCostEstimator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostEstimator.Offers
{
    public class OfferOFR001 : IOfferStrategy
    {
        public string Code => "OFR001";

        public double GetDiscount(double deliveryCost)
        {
            return deliveryCost * 0.10;
        }

        public bool IsApplicable(double weight, double distance)
        {
            return distance < 200 && weight >= 70 && weight <= 200;
        }
    }
}
