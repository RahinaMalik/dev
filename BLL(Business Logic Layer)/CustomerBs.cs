using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;
using DAL_Data_Access_Layer_;

namespace BLL_Business_Logic_Layer_
{
    public class CustomerBs
    {
        private CustomerDb objDb;
        public CustomerBs()
        {
            objDb = new CustomerDb();
        }
        public void Insert(Customer model)
        {
            objDb.Insert(model);
        }
        public List<Restaurant> GetRestaurantList()
        {
            return objDb.GetAllRestaurant();
        }
    }
}
