using DeliveryEstimator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryEstimator.Services
{
    public class DeliveryScheduler
    {
        private readonly List<Vehicle> _vehicles;
        private readonly int _speed;

        public DeliveryScheduler(int vehicleCount, int speed)
        {
            _speed = speed;
            _vehicles = Enumerable.Range(0,vehicleCount)
                        .Select(_ => new Vehicle())
                        .ToList();
        }
        public void Deliver(List<Package> packages, int maxWeight)
        {
            var remianing = new List<Package>(packages);

            while(remianing.Any())
            {
                var vehicle = _vehicles.OrderBy(v => v.AvailableAt).First();
                var shipment = ShipmentPlanner.SelectBestShipement(remianing, maxWeight);

                double tripTime = shipment.Max(p => (double)p.Distance / _speed);
                double deliveryTime = vehicle.AvailableAt + tripTime;

                foreach(var pkg in shipment)
                {
                    pkg.DeliveryTime = deliveryTime;
                    remianing.Remove(pkg);
                }

                vehicle.AvailableAt += 2 * tripTime;
            }
            
        }
    }
}
