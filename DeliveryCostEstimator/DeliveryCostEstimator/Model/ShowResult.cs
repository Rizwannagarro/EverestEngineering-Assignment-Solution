using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryCostEstimator.Model
{
    public class ShowResult
    {
        public string Id {  get; set; }
        public double Discount { get; set; }
        public double TotalCost {  get; set; }

        public ShowResult(string id,double discount, double totalCost) {
            Id = id;
            Discount = discount;
            TotalCost = totalCost;
        }
    }
}
