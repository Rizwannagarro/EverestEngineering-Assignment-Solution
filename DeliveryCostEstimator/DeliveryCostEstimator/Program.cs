using DeliveryCostEstimator.Entities;
using DeliveryCostEstimator.Interfaces;
using DeliveryCostEstimator.Model;
using DeliveryCostEstimator.Offers;
using DeliveryCostEstimator.Services;

var offers = new List<IOfferStrategy>()
{
    new OfferOFR001(),
    new OfferOFR002(),
    new OfferOFR003()
};

var offerService = new OfferService(offers);
var deliveryService = new DeliveryCostService(offerService);
var finalResult = new List<ShowResult>();

Console.WriteLine("Enter base cost and number of packages");
var input = Console.ReadLine().Split();

double baseCost = double.Parse(input[0]);
int packageCount = int.Parse(input[1]);

for (int i=0; i<packageCount; i++)
{
    var pkgInput  = Console.ReadLine().Split();
    var package = new Package
    {
        Id = pkgInput[0],
        Weight = double.Parse(pkgInput[1]),
        Distance = double.Parse(pkgInput[2]),
        OfferCode = pkgInput[3]
    };

    var result = deliveryService.Calculate(package, baseCost);

    var temp = new ShowResult(package.Id, result.discount,result.totalCost);
    finalResult.Add(temp);

    //finalResult.Add(item: new ShowResult
    //{
    //    Id = package.Id,
    //    Discount = result.discount,
    //    TotalCost = result.totalCost

    //});

    //Console.WriteLine($"{package.Id}{result.discount:0}{result.totalCost:0}");
}

for(int i=0;i<finalResult.Count;i++)
{
    Console.WriteLine(finalResult[i].Id +" "+finalResult[i].Discount + " " +finalResult[i].TotalCost);
}