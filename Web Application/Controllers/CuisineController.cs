using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_;

namespace Web_Application.Controllers
{
    public class CuisineController : Controller
    {

        private RestaurantDBEntities dbObj;
        private CuisineBs objBs;
        public CuisineController()
        {
            dbObj = new RestaurantDBEntities();
            objBs = new CuisineBs();

            //Get restaurant list item from DB object
            var restaurnatList = dbObj.Restaurants.ToList();
            ViewBag.RestaurnatList = new SelectList(restaurnatList, "RestaurantID", "RestaurantName");
        }
        // GET: User/Cuisine
        [HttpGet]
        public ActionResult GetCuisineList()
        {
            var cuisines = objBs.GetAll();

            return View(cuisines);
        }


        //[AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [HttpPost]
        public ActionResult AddCuisine(Cuisine model)
        {
            
            try
            {
                if (model.RestaurantID != 0)
                {
                    if (ModelState.IsValid)
                    {
                        objBs.Insert(model);
                        ViewBag.Message = "Cuisine added successfully";
                        //TempData["SuccessMsg"] = "Record added successfully";
                        return RedirectToAction("GetCuisineList");
                    }
                    else
                    {
                        return View("AddCuisine");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = "Record added failed. " + ex.Message;
                return RedirectToAction("AddCuisine");

            }
            return View();

        }
        [HttpGet]
        public ActionResult EditCuisine(int id)
        {
            var data = dbObj.Cuisines.Where(x => x.CuisineID == id).FirstOrDefault();
            
            return View(data);
        }

        //[AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        [HttpPost]
        public ActionResult EditCuisine(Cuisine model)//
        {
            
            if (model != null)
            {
                var data = dbObj.Cuisines.Where(x => x.CuisineID == model.CuisineID).FirstOrDefault();
                if(data != null)
                {
                    data.RestaurantID = model.RestaurantID;
                    data.CuisineName = model.CuisineName;
                }
                objBs.Update(data);
                
            }
            return RedirectToAction("GetCuisineList");

        }

        public ActionResult DeleteCuisine(int id)
        {
            var data = dbObj.Cuisines.Where(x => x.CuisineID == id).FirstOrDefault();
            objBs.Delete(id);

            return RedirectToAction("GetCuisineList");

        }
    }
}