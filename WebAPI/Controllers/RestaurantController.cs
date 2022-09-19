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
    public class RestaurantController : ApiController
    {
        private RestaurantDBEntities dbObj;
        private RestaurantBs objBs;
        public RestaurantController()
        {
            dbObj = new RestaurantDBEntities();
            objBs = new RestaurantBs();
        }

        //Insert
        [System.Web.Http.HttpPost]
        public IHttpActionResult Insert(Restaurant model)
        {
            try
            {
                if (model.RestaurantName != "")
                {
                       objBs.Insert(model);
                        return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

        //Update
        [System.Web.Http.HttpPut]
        public IHttpActionResult Update(Restaurant model)
        {
            try
            {
                if (model.RestaurantID != 0)
                {
                        objBs.Update(model);
                        return Ok(model);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        //Delete
        [System.Web.Http.HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                if (id != 0)
                {
                    objBs.Delete(id);
                    return Ok(id);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
