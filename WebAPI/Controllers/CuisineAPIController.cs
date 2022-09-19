using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_;

namespace WebAPI.Controllers
{
    public class CuisineAPIController : ApiController
    {
        private RestaurantDBEntities dbObj;
        private CuisineBs objBs;

        public CuisineAPIController()
        {
            dbObj = new RestaurantDBEntities();
            objBs = new CuisineBs();
        }

        [System.Web.Http.HttpGet]// Cuisine/GetCuisineList
        [Route("api/CuisineAPI/GetCuisineList")]
        public IHttpActionResult GetCuisineList()
        {
            List<Cuisine> obj = dbObj.Cuisines.ToList();
            return Ok(obj);
        }

        [System.Web.Http.HttpGet]
        [Route("api/CuisineAPI/GetCuisineById")]
        public IHttpActionResult GetCuisineById(int id)
        {
            var obj = dbObj.Cuisines.Where(model => model.CuisineID == id).FirstOrDefault();
            return Ok(obj);
        }

        //Insert
        [System.Web.Http.HttpPost]
        [Route("api/CuisineAPI/Insert")]
        public IHttpActionResult Insert(Cuisine model)
        {
            try
            {
                if(model == null)
                {
                    return Ok("Null reference");
                }
                else
                {
                    objBs.Insert(model);
                    return Ok(model);
                }    
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //Update
        [System.Web.Http.HttpPut]
        [Route("api/CuisineAPI/Update")]
        public IHttpActionResult Update(Cuisine model)
        {
            try
            {
                if(model.CuisineID != 0)
                {
                    var data = dbObj.Cuisines.Where(x => x.CuisineID == model.CuisineID).FirstOrDefault();
                    if (data != null)
                    {
                        data.RestaurantID = model.RestaurantID;
                        data.CuisineName = model.CuisineName;
                    }
                    objBs.Update(data);
                    return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [System.Web.Http.HttpDelete]
        [Route("api/CuisineAPI/Delete")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if(id != 0)
                {
                    //var data = dbObj.Cuisines.Where(x => x.CuisineID == id).FirstOrDefault();
                    objBs.Delete(id);
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
    }
}
