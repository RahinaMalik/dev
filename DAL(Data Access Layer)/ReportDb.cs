using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Data_Access_Layer_
{
    public class ReportDb
    {
        public int OrderID { get; set; }
        public string RestaurantName { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public int ItemQuantity { get; set; }
        public double OrderAmount { get; set; }
        public int DiningTableID { get; set; }
        public string Location { get; set; }
        public List<ReportDb> customerInfo { get; set; }
    }

}
