using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL_Business_Object_Layer_;

namespace Web_Application.Controllers
{
    public class OrderController : Controller
    {
        RestaurantDBEntities dbObj;

        public OrderController()
        {
            dbObj = new RestaurantDBEntities();
            
        }
        // GET: Order
        public ActionResult Order()
        {
            return View();
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AddOrder()//OrderTable model
        {
           // OrderTable obj = new OrderTable();

            return View();
        }
    }
}