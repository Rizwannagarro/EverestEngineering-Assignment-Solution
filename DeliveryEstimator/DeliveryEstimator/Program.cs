using DeliveryEstimator;
using DeliveryEstimator.Services;

var firstLine = Console.ReadLine().Split(' ');
int baseCost = int.Parse(firstLine[0]);
int packageCount = int.Parse(firstLine[1]);

var packages = DeliveryEstimatorApp.ReadPackages(packageCount);

var vehicleInput = Console.ReadLine().Split(' ');
int vehicles = int.Parse(vehicleInput[0]);
int speed =  int.Parse(vehicleInput[1]);
int maxWeight = int.Parse(vehicleInput[2]);

var deliveryService = new DeliveryScheduler(vehicles, speed);
deliveryService.Deliver(packages, maxWeight);

foreach(var pkg in packages)
{
    int cost = baseCost + (pkg.Weight * 10) + (pkg.Distance * 5);
    Console.WriteLine($"{pkg.Id} 0 {cost} {pkg.DeliveryTime:F2}");
}