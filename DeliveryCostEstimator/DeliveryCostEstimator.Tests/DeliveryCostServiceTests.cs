using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliveryCostEstimator.Entities;
using DeliveryCostEstimator.Offers;
using DeliveryCostEstimator.Services;
using DeliveryCostEstimator.Interfaces;
using System.Collections.Generic;

namespace DeliveryCostEstimator.Tests
{
    [TestClass]
    public class DeliveryCostServiceTests
    {
        private DeliveryCostService _deliveryService;

        [TestInitialize]
        public void Setup()
        {
            var offers = new List<IOfferStrategy>
            {
                new OfferOFR001(),
                new OfferOFR002(),
                new OfferOFR003()
            };

            var offerService = new OfferService(offers);
            _deliveryService = new DeliveryCostService(offerService);
        }

        [TestMethod]
        public void Calculate_ReturnsCorrectTotalCost_WithDiscount()
        {
            var package = new Package
            {
                Id = "PKG1",
                Weight = 100,
                Distance = 100,
                OfferCode = "OFR001"
            };

            var result = _deliveryService.Calculate(package, baseCost: 100);

            Assert.AreEqual(160, result.discount);
            Assert.AreEqual(1440, result.totalCost);
        }

        [TestMethod]
        public void Calculate_ReturnsFullCost_WhenNoOfferApplied()
        {
            var package = new Package
            {
                Id = "PKG2",
                Weight = 10,
                Distance = 10,
                OfferCode = "NA"
            };

            var result = _deliveryService.Calculate(package, baseCost: 100);

            Assert.AreEqual(0, result.discount);
            Assert.AreEqual(250, result.totalCost);
        }
    }
}
