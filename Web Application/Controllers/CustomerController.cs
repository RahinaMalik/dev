using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_;

namespace Web_Application.Controllers
{
    public class CustomerController : Controller
    {
        private RestaurantDBEntities dbObj;
        private CustomerBs objBs;

        public CustomerController()
        {
            dbObj = new RestaurantDBEntities();
            objBs = new CustomerBs();
        }

        // GET: Customer
        public ActionResult AddCustomer(Customer model)
        {
            var restaurnatList = objBs.GetRestaurantList();
            ViewBag.RestaurnatList = new SelectList(restaurnatList, "RestaurantID", "RestaurantName");

            try
            {
                if (model.RestaurantID != 0)
                {
                    if (ModelState.IsValid)
                    {
                        objBs.Insert(model);
                        ViewBag.Message = "Customer added successfully";
                        TempData["SuccessMsg"] = "Record added successfully";
                    }
                    else
                    {
                        return View("AddCustomer");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = "Record added failed. " + ex.Message;
                return RedirectToAction("AddCustomer");

             }

                return View();
        }
    }
}