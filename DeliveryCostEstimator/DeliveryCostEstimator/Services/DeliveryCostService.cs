using DeliveryCostEstimator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostEstimator.Services
{
    public class DeliveryCostService
    {
        private readonly OfferService _offerService;

        public DeliveryCostService(OfferService offerService)
        {
            _offerService = offerService;
        }

        public (double discount, double totalCost) Calculate(Package package, double baseCost )
        {
            double deliveryCost = baseCost + (package.Weight * 10) + (package.Distance * 5);

            double discount = _offerService.CalculateDiscount(
                package.OfferCode,
                package.Weight,
                package.Distance,
                deliveryCost
                );

            return (discount, deliveryCost - discount);
        }
    }
}
