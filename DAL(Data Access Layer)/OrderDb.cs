using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;
using System.ComponentModel.DataAnnotations;

namespace DAL_Data_Access_Layer_
{
    public class OrderDb
    {
        private RestaurantDBEntities resDBObj;
        //Intialize object within constructor
        public OrderDb()
        {
           
            resDBObj = new RestaurantDBEntities();
        }

        public List<Restaurant> GetAllRestaurant()
        {
            return resDBObj.Restaurants.ToList();
        }

        public void Insert(OrderTable model)
        {

            resDBObj.OrderTables.Add(model);
            Save();
        }
        public void Update(DiningTableTrack model)
        {
            if(model != null)
            {
                resDBObj.Entry(model).State = System.Data.Entity.EntityState.Detached;
            }

            resDBObj.Entry(model).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
        public void Save()
        {
            resDBObj.SaveChanges();
        }

        public List<SelectListItem> AvailableRestaurants { get; set; }
        public List<SelectListItem> AvailableMenuItems { get; set; }
        public List<SelectListItem> AvailableDiningTables { get; set; }
        public void MenuItemModel()
        {
            AvailableRestaurants = new List<SelectListItem>();
            AvailableMenuItems = new List<SelectListItem>();
            AvailableDiningTables = new List<SelectListItem>();
        }

        public int OrderID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime OrderDate { get; set; }
        [Required]
        public int RestaurantID { get; set; }
        [Required]
        public int MenuItemID { get; set; }
        [Required]
        public int ItemQuantity { get; set; }
        [Required]
        public double OrderAmount { get; set; }
        [Required]
        public int DiningTableId { get; set; }

        public class RestaurantMenuItem
        {
            public int MenuItemID { get; set; }
            public int CuisineID { get; set; }
            public string ItemName { get; set; }
            public float ItemPrice { get; set; }
        }

        public class DiningTable
        {
            public int DiningTableID { get; set; }
            public int RestaurantID { get; set; }
            public string Location { get; set; }
        }


    }
}
