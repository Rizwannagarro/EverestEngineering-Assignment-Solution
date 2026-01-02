using DeliveryEstimator.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryEstimator.Services
{
    public static class ShipmentPlanner
    {
        public  static List<Package> SelectBestShipement(List<Package> packages, int maxWeight)
        {
           List<Package> bestShipment = new List<Package>();

            int n = packages.Count;

            for (int mask = 0; mask < (1 << n); mask++)
            {
                var subset = new List<Package>();
                int totalWeight = 0;

                for (int i = 0; i < n; i++)
                {
                    
                   if((mask & (1 << i)) != 0)
                    {
                        subset.Add(packages[i]);
                        totalWeight = totalWeight + packages[i].Weight;
                    }
                }

                if(totalWeight <= maxWeight)
                {
                    if(subset.Count > bestShipment.Count || 
                        (subset.Count == bestShipment.Count && subset.Sum(p => p.Weight) > bestShipment.Sum(p => p.Weight)))
                    {
                        bestShipment = subset;
                    }
                }
            }

            if(!bestShipment.Any())
            {
                var singlePackage = packages
                    .Where(p => p.Weight <= maxWeight)
                    .OrderByDescending(p => p.Weight)
                    .First();

                bestShipment.Add(singlePackage);
            }

            return bestShipment;
        }
    }
}
