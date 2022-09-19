using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;
using DAL_Data_Access_Layer_;

namespace BLL_Business_Logic_Layer_
{
    public class OrderBs
    {
         private OrderDb objDb;
        //private DiningTableTrackDb objTableTrackDb;
         private RestaurantDBEntities dbObj;
         private SqlConnection con;
        public OrderBs()
        {
          
            objDb = new OrderDb();
            //objTableTrackDb = new DiningTableTrackDb();
            dbObj = new RestaurantDBEntities();
        }
        private void connection()
        {
            // string constr = ConfigurationManager.ConnectionStrings["RestaurantDBEntities"].ToString();
            string constr = "Data Source=DESKTOP-R9B0JF1\\MSSQLSERVER2019;Initial Catalog=RestaurantDB;Integrated Security=True";
            con = new SqlConnection(constr);

        }
        public void Insert(OrderTable order)
        {
            objDb.Insert(order);
        }
        public void Update(DiningTableTrack model)
        {
            objDb.Update(model);
        }
        public List<Restaurant> GetRestaurantList()
        {
            return objDb.GetAllRestaurant();
        }
        public List<RestaurantMenuItem> GetMenuListByRestaurantID(int RestaurantID)
        {
          
            var MenuItems = new List<RestaurantMenuItem>();


            List<Cuisine> cuisines = dbObj.Cuisines.ToList();
            List<RestaurantMenuItem> menuItems = dbObj.RestaurantMenuItems.ToList();

             MenuItems = (from m in menuItems
                             join c in cuisines on m.CuisineID equals c.CuisineID
                             where c.RestaurantID == RestaurantID
                             orderby m.MenuItemID
                            select new RestaurantMenuItem { MenuItemID = m.MenuItemID, ItemName = m.ItemName }).ToList();

            return MenuItems;
        }
        public List<DiningTable> GetAllDiningTablebyRestaurantID(int RestaurantID)
        {
            List<DiningTable> tables = dbObj.DiningTables.ToList();

            var diningTables = (from d in tables
                                where d.RestaurantID == RestaurantID
                                orderby d.DiningTableID
                                select new DiningTable { DiningTableID = d.DiningTableID, Location = d.Location }).ToList();

           // var diningTables = new List<DiningTable>();
           //diningTables = dbObj.DiningTables.Where(x => x.RestaurantID == RestaurantID).ToList();

            return diningTables;
        }
        public string TableStatus(int tableID)
        {
            //var diningTables = dbObj.DiningTableTracks.Where(x => x.DiningTableID == tableID).FirstOrDefault();
            var diningTables = dbObj.DiningTableTracks.AsNoTracking().Where(x => x.DiningTableID == tableID).FirstOrDefault();
            if (diningTables != null)
            {
                return diningTables.TableStatus;
            }
            else
            {
                return "";
            }  
        }

        public DiningTableTrack GetDiningTableTrackData(int tableID)
        {
            //var diningTables = dbObj.DiningTableTracks.AsNoTracking().Where(x => x.DiningTableID == tableID).FirstOrDefault();

            //var DiningTrack = dbObj.Set<DiningTableTrack>()
            //             .Local
            //             .FirstOrDefault(f => f.DiningTableID == tableID);
            var DiningTrack = dbObj.DiningTableTracks.AsNoTracking().Where(x => x.DiningTableID == tableID).FirstOrDefault();
            return DiningTrack;
        }
        public float getToatlItemPrice(int MenuItemID,int Qty)
        {
            var MenuPrice = dbObj.RestaurantMenuItems.Single(r => r.MenuItemID == MenuItemID).ItemPrice;
            int totalAmt = Convert.ToInt32(MenuPrice * Qty);

            return totalAmt;
        }


    }
}
