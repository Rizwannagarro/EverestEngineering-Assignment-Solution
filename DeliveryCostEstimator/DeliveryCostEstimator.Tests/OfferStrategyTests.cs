using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliveryCostEstimator.Offers;

namespace DeliveryCostEstimator.Tests
{
    [TestClass]
    public class OfferStrategyTests
    {
        [TestMethod]
        public void OFR001_IsApplicable_ReturnsTrue_WhenConditionsMatch()
        {
            var offer = new OfferOFR001();

            bool result = offer.IsApplicable(weight: 100, distance: 150);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void OFR002_IsApplicable_ReturnsFalse_WhenWeightOutOfRange()
        {
            var offer = new OfferOFR002();

            bool result = offer.IsApplicable(weight: 90, distance: 100);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void OFR003_GetDiscount_ReturnsCorrectDiscount()
        {
            var offer = new OfferOFR003();

            double discount = offer.GetDiscount(200);

            Assert.AreEqual(10, discount);
        }
    }
}

