using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;

namespace DAL_Data_Access_Layer_
{
    public class CustomerDb
    {
        private RestaurantDBEntities db;
        //Intialize object within constructor
        public CustomerDb()
        {
            db = new RestaurantDBEntities();
        }
        public void Insert(Customer model)
        {
            db.Customers.Add(model);
            Save();
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public List<Restaurant> GetAllRestaurant()
        {
            return db.Restaurants.ToList();
        }

        public int CustomerID { get; set; }
        public int RestaurantID { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
    }
}
