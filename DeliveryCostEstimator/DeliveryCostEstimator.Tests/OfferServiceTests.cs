using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliveryCostEstimator.Offers;
using DeliveryCostEstimator.Services;
using DeliveryCostEstimator.Interfaces;
using System.Collections.Generic;

namespace DeliveryCostEstimator.Tests
{
    [TestClass]
    public class OfferServiceTests
    {
        private OfferService _offerService;

        [TestInitialize]
        public void Setup()
        {
            var offers = new List<IOfferStrategy>
            {
                new OfferOFR001(),
                new OfferOFR002(),
                new OfferOFR003()
            };

            _offerService = new OfferService(offers);
        }

        [TestMethod]
        public void CalculateDiscount_ReturnsZero_WhenOfferCodeIsInvalid()
        {
            double discount = _offerService.CalculateDiscount(
                "INVALID", 100, 100, 300);

            Assert.AreEqual(0, discount);
        }

        [TestMethod]
        public void CalculateDiscount_ReturnsDiscount_WhenOfferIsApplicable()
        {
            double discount = _offerService.CalculateDiscount(
                "OFR001", 100, 150, 300);

            Assert.AreEqual(30, discount);
        }

        [TestMethod]
        public void CalculateDiscount_ReturnsZero_WhenOfferNotApplicable()
        {
            double discount = _offerService.CalculateDiscount(
                "OFR001", 50, 300, 300);

            Assert.AreEqual(0, discount);
        }
    }
}
