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
    public class RestaurantBs
    {
        private SqlConnection con;
        private RestaurantDb objDb;
        public RestaurantBs()
        {
            objDb = new RestaurantDb();
        }
        private void connection()
        {
            // string constr = ConfigurationManager.ConnectionStrings["RestaurantDBEntities"].ToString();
            string constr = "Data Source=DESKTOP-R9B0JF1\\MSSQLSERVER2019;Initial Catalog=RestaurantDB;Integrated Security=True";
            con = new SqlConnection(constr);
        }
        public void Insert(Restaurant model)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_Restaurant", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@RestaurantName", model.RestaurantName);
            com.Parameters.AddWithValue("@Address", model.Address);
            com.Parameters.AddWithValue("@MobileNo", model.MobileNo);
            com.Parameters.AddWithValue("@Query", 1);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
        }
        public void Update(Restaurant model)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_Restaurant", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@RestaurantID", model.RestaurantID);
            com.Parameters.AddWithValue("@RestaurantName", model.RestaurantName);
            com.Parameters.AddWithValue("@Address", model.Address);
            com.Parameters.AddWithValue("@MobileNo", model.MobileNo);
            com.Parameters.AddWithValue("@Query", 2);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_Restaurant", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@RestaurantID", id);
            com.Parameters.AddWithValue("@RestaurantName", "");
            com.Parameters.AddWithValue("@Address", "");
            com.Parameters.AddWithValue("@MobileNo", "");
            com.Parameters.AddWithValue("@Query", 3);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
        }
    }
}
