using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryEstimator.Domain
{
    public class Package
    {
        public string Id { get; set; }
        public int  Weight { get; set; }    
        public int Distance { get; set; }

        public string OfferCode { get; set; }

        public double DeliveryTime { get; set; }
        //public int Discount { get; set; }
        //public int TotalCost { get; set; }

        public Package(string id, int weight,int distance, string offerCode)
        {
            Id = id;
            Weight = weight;
            Distance = distance;
            OfferCode = offerCode;

            //Discount = 0;
            //TotalCost = 100 + weight * 10 + distance * 5;
        }

        public bool HasOffer => OfferCode != "NA";
    }
}
