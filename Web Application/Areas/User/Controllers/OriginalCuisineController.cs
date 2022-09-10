using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_;

namespace Web_Application.Areas.User.Controllers
{
    public class OriginalCuisineController : Controller
    {
        private CuisineBs objBs;
        public OriginalCuisineController()
        {
            objBs = new CuisineBs();
        }
        // GET: User/Cuisine
        public ActionResult Index()
        {
            var cuisines = objBs.GetAll();
            return View(cuisines);
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Create(Cuisine cuisine)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.Insert(cuisine);
                    TempData["SuccessMsg"] = "Record added successfully";
                    return RedirectToAction("Create");
                }
                else
                {
                    return View();
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMsg"] = "Record added failed. " + ex.Message;
                return RedirectToAction("Create");

            }
            
            
        }

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Edit(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    objBs.GetById(1);
                    TempData["SuccessMsg"] = "Record Updated successfully";
                    return RedirectToAction("Edit");
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = "Record Updated failed. " + ex.Message;
                return RedirectToAction("Edit");

            }


        }


    }
}