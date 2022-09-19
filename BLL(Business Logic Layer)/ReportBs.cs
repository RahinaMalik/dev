using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_Data_Access_Layer_;

namespace BLL_Business_Logic_Layer_
{
    public class ReportBs
    {
        private SqlConnection con;
        public ReportDb reportDbs;

        public ReportBs()
        {
            reportDbs = new ReportDb();
        }
        private void connection()
        {
            //string constr = ConfigurationManager.ConnectionStrings["RestaurantDBEntities"].ToString();
            string constr = "Data Source=DESKTOP-R9B0JF1\\MSSQLSERVER2019;Initial Catalog=RestaurantDB;Integrated Security=True";
            con = new SqlConnection(constr);
        }

        public List<ReportDb> getSearchListByParam(string FilterBy,string OrderBy,string SearchValue)
        {
            connection();
            ReportDb custList = new ReportDb();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
         
                    con.Open();
                     SqlCommand cmd = new SqlCommand("getFilterByOrderByAllCustomerDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FilterBy", FilterBy);
                    cmd.Parameters.AddWithValue("@OrderBy", OrderBy);
                    cmd.Parameters.AddWithValue("@UserInput", SearchValue);
                   
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    List<ReportDb> customerList = new List<ReportDb>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ReportDb cobj = new ReportDb();

                        cobj.OrderID = Convert.ToInt32(ds.Tables[0].Rows[i]["OrderID"]); //show records with selected columns  
                        cobj.RestaurantName = ds.Tables[0].Rows[i]["RestaurantName"].ToString();
                        cobj.OrderDate = Convert.ToDateTime(ds.Tables[0].Rows[i]["OrderDate"]);
                        cobj.CustomerID = Convert.ToInt32(ds.Tables[0].Rows[i]["CustomerID"].ToString());
                        cobj.CustomerName =ds.Tables[0].Rows[i]["CustomerName"].ToString();
                        cobj.ItemQuantity = Convert.ToInt32(ds.Tables[0].Rows[i]["ItemQuantity"].ToString());
                        cobj.OrderAmount = Convert.ToDouble(ds.Tables[0].Rows[i]["OrderAmount"].ToString());
                        cobj.DiningTableID = Convert.ToInt32(ds.Tables[0].Rows[i]["DiningTableID"].ToString());
                        cobj.Location = ds.Tables[0].Rows[i]["Location"].ToString();
                        customerList.Add(cobj);
                    }
                      custList.customerInfo = customerList;
                
                con.Close();
            
            return customerList;
        }
    }
}
