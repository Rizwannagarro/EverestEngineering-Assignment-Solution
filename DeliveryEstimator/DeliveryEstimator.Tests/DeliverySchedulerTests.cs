using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeliveryEstimator.Domain;
using DeliveryEstimator.Services;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryEstimator.Tests
{
    [TestClass]
    public class DeliverySchedulerTests
    {
        [TestMethod]
        public void Deliver_AssignsDeliveryTimeToAllPackages()
        {
            // Arrange
            var packages = new List<Package>
            {
                new Package("P1", 10, 100, "NA"),
                new Package("P2", 20, 50, "NA")
            };

            int vehicles = 1;
            int speed = 50;
            int maxWeight = 50;

            var scheduler = new DeliveryScheduler(vehicles, speed);

            // Act
            scheduler.Deliver(packages, maxWeight);

            // Assert
            Assert.IsTrue(packages.All(p => p.DeliveryTime > 0));
        }

        [TestMethod]
        public void Deliver_UsesVehicleAvailabilityCorrectly()
        {
            // Arrange
            var packages = new List<Package>
            {
                new Package("P1", 10, 100, "NA"),
                new Package("P2", 10, 100, "NA")
            };

            var scheduler = new DeliveryScheduler(vehicleCount: 1, speed: 50);

            // Act
            scheduler.Deliver(packages, maxWeight: 20);

            // Assert
            Assert.AreEqual(packages[0].DeliveryTime, packages[1].DeliveryTime, 0.01);
        }
    }
}
