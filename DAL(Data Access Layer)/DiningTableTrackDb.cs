using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL_Business_Object_Layer_;

namespace DAL_Data_Access_Layer_
{
    public class DiningTableTrackDb
    {
        private RestaurantDBEntities resDBObj;
        public DiningTableTrackDb()
        {
            resDBObj = new RestaurantDBEntities();
        }
        public void Update(DiningTableTrack model)
        {
            //RestaurantDBEntities dbEntityEntry = resDBObj.Entry(model);
            //if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
            //{
            //    System.Data.Entity.DbSet.Attach(model);
            //}

            //resDBObj.Entry(model).State = System.Data.Entity.EntityState.Detached;
            resDBObj.Entry(model).State = System.Data.Entity.EntityState.Modified;
            // Save();
        }
        public void Save()
        {
            resDBObj.SaveChanges();
        }
    }
}
