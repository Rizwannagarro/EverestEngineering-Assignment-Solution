using DeliveryCostEstimator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostEstimator.Services
{
    public class OfferService
    {
        private readonly IEnumerable<IOfferStrategy> _offers;

        public OfferService(IEnumerable<IOfferStrategy> offers)
        {
            _offers = offers;
        }

        public double CalculateDiscount(string offerCode, double weight, double distance, double deliveryCost)
        {
            var offer = _offers.FirstOrDefault(o => o.Code == offerCode);

            if(offer == null || !offer.IsApplicable(weight,distance))
                return 0;

            return offer.GetDiscount(deliveryCost);
        }
    }
}
