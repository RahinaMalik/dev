using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;

namespace DAL_Data_Access_Layer_
{
    public class CuisineDb
    {
        private RestaurantDBEntities db;
        //Intialize object within constructor
        public CuisineDb()
        {
            db = new RestaurantDBEntities();
        }

        public int CuisineID { get; set; }
        [Required]
        public int RestaurantID { get; set; }
        [Required]
        public int CuisineName { get; set; }

        //Get List by Using IEnumerable class
        public IEnumerable<Cuisine> GetAllCuisine()
        {
            return db.Cuisines.ToList();
        }
        //Get Selected record
        public Cuisine GetById(int id)
        {
            return db.Cuisines.Find(id);
        }
        public void Insert(Cuisine cuisine)
        {
            db.Cuisines.Add(cuisine);
            Save();
        }
        public void Update(Cuisine cuisine)
        {
            db.Entry(cuisine).State = System.Data.Entity.EntityState.Modified;
            Save();
        }
        public void Delete(int id)
        {
            Cuisine cuisine = db.Cuisines.Find(id);
            db.Cuisines.Remove(cuisine);
            Save();
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }

}
