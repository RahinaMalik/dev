using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;

namespace DAL_Data_Access_Layer_
{
    public class BillsDb
    {
        private RestaurantDBEntities dbObj;
        public BillsDb()
        {
            dbObj = new RestaurantDBEntities();
        }
        public List<OrderTable> GetAllOrders()
        {
            //List<OrderTable> todaysOrder = dbObj.OrderTables.Where(x => x.OrderDate.Date == DateTime.Now.Date).ToList();
            //return todaysOrder;
            return dbObj.OrderTables.ToList();
            
        }
        public List<Restaurant> GetAllRestaurant()
        {
            return dbObj.Restaurants.ToList();
        }
        public List<Customer> GetAllCustomer()
        {
            return dbObj.Customers.ToList();
        }
        public OrderTable GetOrderById(int OrderId)
        {
            return dbObj.OrderTables.Find(OrderId);
        }


        public int BillsID { get; set; }
        public int OrderID { get; set; }
        public int RestaurantID { get; set; }
        public double BillAmount { get; set; }
        public int CustomerID { get; set; }

    }
}
