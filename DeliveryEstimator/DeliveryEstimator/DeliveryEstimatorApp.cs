using DeliveryEstimator.Domain;
using DeliveryEstimator.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryEstimator
{
    public static class DeliveryEstimatorApp
    {
       public static List<Package> ReadPackages(int count)
        {
            var packages = new List<Package>();

            for(int i=0;i<count;i++)
            {
                var parts = Console.ReadLine().Split(' ');
                packages.Add(new Package(
                    parts[0],
                    int.Parse(parts[1]),
                    int.Parse(parts[2]),
                    parts[3]
                    ));
            }

            return packages;
        }
    }
}
