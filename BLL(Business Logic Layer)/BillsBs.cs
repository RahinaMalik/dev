using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;
using DAL_Data_Access_Layer_;

namespace BLL_Business_Logic_Layer_
{
    public class BillsBs
    {
        private SqlConnection con;
        private BillsDb objDb;
        private RestaurantDBEntities restaurantDBObj;
        public BillsBs()
        {
            objDb = new BillsDb();
            restaurantDBObj = new RestaurantDBEntities();
        }

        private void connection()
        {
            // string constr = ConfigurationManager.ConnectionStrings["RestaurantDBEntities"].ToString();
            string constr = "Data Source=DESKTOP-R9B0JF1\\MSSQLSERVER2019;Initial Catalog=RestaurantDB;Integrated Security=True";
            con = new SqlConnection(constr);

        }

        public List<OrderTable> GetOrderList()
        {
            return objDb.GetAllOrders();
        }
        public List<Restaurant> GetRestaurantList()
        {
            return objDb.GetAllRestaurant();
        }
        public List<Customer> GetCustomerList()
        {
            return objDb.GetAllCustomer();
        }
        public void Insert(Bill bill)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_Bills", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@OrderID", bill.OrderID);
            com.Parameters.AddWithValue("@BillStatus", "processed");
            com.Parameters.AddWithValue("@CustomerID", bill.CustomerID);
            com.Parameters.AddWithValue("@Query", 1);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            // objDb.Insert(cuisne);

        }
    }
}
