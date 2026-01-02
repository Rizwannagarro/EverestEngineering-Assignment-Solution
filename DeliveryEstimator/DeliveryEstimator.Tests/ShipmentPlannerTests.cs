using global::DeliveryEstimator.Domain;
using global::DeliveryEstimator.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryEstimator.Tests
{
    [TestClass]
    public class ShipmentPlannerTests
    {
        [TestMethod]
        public void SelectBestShipment_ReturnsMaxPackagesWithinWeight()
        {
            // Arrange
            var packages = new List<Package>
            {
                new Package("P1", 10, 10, "NA"),
                new Package("P2", 20, 20, "NA"),
                new Package("P3", 30, 30, "NA")
            };

            int maxWeight = 30;

            // Act
            var result = ShipmentPlanner.SelectBestShipement(packages, maxWeight);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(30, result.Sum(p => p.Weight));
        }

        [TestMethod]
        public void SelectBestShipment_WhenNoCombinationFits_ReturnsHeaviestSinglePackage()
        {
            // Arrange
            var packages = new List<Package>
            {
                new Package("P1", 50, 10, "NA"),
                new Package("P2", 40, 20, "NA")
            };

            int maxWeight = 45;

            // Act
            var result = ShipmentPlanner.SelectBestShipement(packages, maxWeight);

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("P2", result[0].Id);
        }
    }
}
