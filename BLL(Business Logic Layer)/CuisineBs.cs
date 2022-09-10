using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;
using DAL_Data_Access_Layer_;
using System.Configuration;
using System.Data;

namespace BLL_Business_Logic_Layer_
{
    public class CuisineBs
    {
        private SqlConnection con;
        private CuisineDb objDb;

        public object ConfigurationManager { get; private set; }

        public CuisineBs()
        {
            objDb = new CuisineDb();
        }

        private void connection()
        {
           // string constr = ConfigurationManager.ConnectionStrings["RestaurantDBEntities"].ToString();
            string constr = "Data Source=DESKTOP-R9B0JF1\\MSSQLSERVER2019;Initial Catalog=RestaurantDB;Integrated Security=True";
            con = new SqlConnection(constr);

        }
        public IEnumerable<Cuisine> GetAll()
        {
            return objDb.GetAllCuisine();
        }
        public Cuisine GetById(int id)
        {
            return objDb.GetById(id);
        }
        public void Insert(Cuisine cuisne)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_Cuisine", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@RestaurantID", cuisne.RestaurantID);
            com.Parameters.AddWithValue("@CuisineName", cuisne.CuisineName);
            com.Parameters.AddWithValue("@Query",1);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

           // objDb.Insert(cuisne);

        }
        public void Update(Cuisine cuisine)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_Cuisine", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CuisineID", cuisine.CuisineID);
            com.Parameters.AddWithValue("@RestaurantID", cuisine.RestaurantID);
            com.Parameters.AddWithValue("@CuisineName", cuisine.CuisineName);
            com.Parameters.AddWithValue("@Query", 2);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            // objDb.Update(cuisine);
        }
        public void Delete(int id)
        {
            connection();
            SqlCommand com = new SqlCommand("CRUD_Cuisine", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@CuisineID", id);
            com.Parameters.AddWithValue("@RestaurantID", 0);
            com.Parameters.AddWithValue("@CuisineName", "");
            com.Parameters.AddWithValue("@Query", 3);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            //objDb.Delete(id);
        }



    }
}
