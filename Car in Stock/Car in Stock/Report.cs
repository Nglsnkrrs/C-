using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_in_Stock
{
    public class Report
    {
        public int CarId { get; set; }
        public string CarName { get; set; }
        public int DateRelease { get; set; }
        public int Cost { get; set; }
        public string Remark { get; set; }
        public string City { get; set; }
        public int StockId { get; set; }
        public string StockDescription { get; set; }

        public override string ToString()
        {
            return $"Warehouse {StockId} ({City}) | Car: {CarName} (ID: {CarId}, Year: {DateRelease}, Cost: {Cost}, Note: {Remark})";
        }


        
    }
}
