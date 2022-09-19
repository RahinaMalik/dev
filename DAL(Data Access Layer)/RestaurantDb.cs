using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;

namespace DAL_Data_Access_Layer_
{
    public class RestaurantDb
    {
        private RestaurantDBEntities db;
        public RestaurantDb()
        {
            db = new RestaurantDBEntities();
        }

        public void Insert(Restaurant model)
        {
            db.Restaurants.Add(model);
            Save();
        }
        public void Update(Restaurant model)
        {
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            Restaurant model = db.Restaurants.Find(id);
            db.Restaurants.Remove(model);
            Save();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public int RestaurantID { get; set; }
        [Required]
        public string RestaurantName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string MobileNo { get; set; }
    }
}
