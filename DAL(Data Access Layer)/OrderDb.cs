using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;

namespace DAL_Data_Access_Layer_
{
    public class OrderDb
    {
        private RestaurantDBEntities db;
        //Intialize object within constructor
        public OrderDb()
        {
            db = new RestaurantDBEntities();
        }

        public int OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int RestaurantID { get; set; }
        public int MenuItemID { get; set; }
        public int ItemQuantity { get; set; }
        public double OrderAmount { get; set; }
        public int DiningTableId { get; set; }

        public void Insert(OrderTable order)
        {
            db.OrderTables.Add(order);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

       
    }
}
