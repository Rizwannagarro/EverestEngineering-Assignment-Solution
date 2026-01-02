using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliveryEstimator.Domain;

namespace DeliveryEstimator.Tests
{
    [TestClass]
    public class PackageTests
    {
        [TestMethod]
        public void HasOffer_ReturnsFalse_WhenOfferCodeIsNA()
        {
            var pkg = new Package("P1", 10, 10, "NA");
            Assert.IsFalse(pkg.HasOffer);
        }

        [TestMethod]
        public void HasOffer_ReturnsTrue_WhenOfferCodeIsPresent()
        {
            var pkg = new Package("P1", 10, 10, "OFR001");
            Assert.IsTrue(pkg.HasOffer);
        }
    }
}
