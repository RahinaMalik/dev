using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_;
using static BLL_Business_Logic_Layer_.OrderBs;

namespace Web_Application.Controllers
{
    public class OrderController : Controller
    {
        private RestaurantDBEntities dbObj;
        private OrderBs objBs;
     

        public OrderController()
      {
            dbObj = new RestaurantDBEntities();

            objBs = new OrderBs();

            //Get restaurant list item from DB object
            //Bind Restaurant Dropdown
            var restaurnatList = objBs.GetRestaurantList();
            ViewBag.RestaurnatList = new SelectList(restaurnatList, "RestaurantID", "RestaurantName");

            List<RestaurantMenuItem> menuList = new List<RestaurantMenuItem>();
            ViewBag.AvailableMenuList = new SelectList(menuList, "", "");

            List<DiningTable> diningList = new List<DiningTable>();
            ViewBag.AvailableDiningTables = new SelectList(diningList, "","");
        }
        // GET: Order
        public ActionResult Order()
        {
            try
            {
                var restaurnatList = objBs.GetRestaurantList();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = "Faile to get RestaurantList. " + ex.Message;
            }


            return View();
        }

       

        //Get MenuItem list by Restaurant ID
        [HttpGet]
        public ActionResult GetMenuItemListByRestaurantID(int RestaurantID)
        {
            dbObj.Configuration.ProxyCreationEnabled = false;

            var menuItems = objBs.GetMenuListByRestaurantID(RestaurantID);
           
            var result = (from m in menuItems
                          select new
                          {
                              id = m.MenuItemID,
                              name = m.ItemName
                          }).ToList();
            ViewBag.AvailableMenuList = new SelectList(result, "MenuItemID", "ItemName");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetDiningTableList(int RestaurantID)
        {
            dbObj.Configuration.ProxyCreationEnabled = false;
            //if (String.IsNullOrEmpty(RestaurantID))
            //{
            //    throw new ArgumentNullException("RestaurantID");
            //}
            ////List<DiningTable> 
            //int id = 0;
            //bool isValid = Int32.TryParse(RestaurantID, out id);
            var diningTables = objBs.GetAllDiningTablebyRestaurantID(RestaurantID);
           
           
            var result = (from m in diningTables
                          select new
                          {
                              id = m.DiningTableID,
                              name = m.Location
                          }).ToList();
            //ViewBag.AvailableDiningTables = new SelectList(result, "", "");
            ViewBag.AvailableDiningTables = result;


            return Json(ViewBag.AvailableDiningTables, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getTotalMenuItemPrice(int MenuItemID,int Qty)
        {
            var price = objBs.getToatlItemPrice(MenuItemID, Qty);
            ViewBag.Price = price;
            return Json(ViewBag.Price, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult getTableStatus(int DiningTableId)
        {
            var status = objBs.TableStatus(DiningTableId);
            ViewBag.Status = status;
            return Json(ViewBag.Status, JsonRequestBehavior.AllowGet);
        }
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult AddOrder(OrderTable model)//OrderTable model
        {
            if(model.DiningTableId != 0)
            {
                if (ModelState.IsValid)
                {
                    var status = objBs.TableStatus(model.DiningTableId);
                    if(status == "Vacant" && status != null)
                    {

                        var trackModel = objBs.GetDiningTableTrackData(model.DiningTableId);
                        if (trackModel != null)
                        {
                            trackModel.DiningTableID = model.DiningTableId;
                            trackModel.TableStatus = "Occupied";
                        }
                        objBs.Insert(model); 
                        objBs.Update(trackModel);
                       
                    }
                    else
                    {
                        ViewBag.Status = "Table is Occupied";
                    }
                }
                else
                {
                    return View("AddOrder");
                }
            }
            else
            {
                return View("AddOrder");
            }
             //OrderTable obj = new OrderTable();
             
            return View();
        }
    }
}