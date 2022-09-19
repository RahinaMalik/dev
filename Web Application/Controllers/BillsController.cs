using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_;

namespace Web_Application.Controllers
{
    public class BillsController : Controller
    {

        private RestaurantDBEntities dbObj;
        private BillsBs objBs;
        public BillsController()
        {
            dbObj = new RestaurantDBEntities();

            objBs = new BillsBs();

            var orderList = objBs.GetOrderList();
            ViewBag.OrderList = new SelectList(orderList, "OrderID", "OrderID");

            var customerList = objBs.GetCustomerList();
            ViewBag.CustomerList = new SelectList(customerList, "CustomerID", "CustomerName");
        }

       

        // GET: Bills
        public ActionResult AddBills(Bill model)
        {
            try { 
                if(model.OrderID != 0)
                {
                    objBs.Insert(model);
                    ViewBag.Message = "Bill added successfully";
                }
            }
            catch(Exception ex)
            {
                TempData["ErrorMsg"] = "Record added failed. " + ex.Message;
                return RedirectToAction("AddBills");
            }
            return View();
        }
    }
}