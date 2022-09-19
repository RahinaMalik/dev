using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_;
using DAL_Data_Access_Layer_;

namespace Web_Application.Controllers
{
    public class ReportController : Controller
    {
        private RestaurantDBEntities dbObj;
        private ReportBs bsObj;

        public ReportController()
        {
            dbObj = new RestaurantDBEntities();
            bsObj = new ReportBs();
        }
        // GET: Report
        public ActionResult Report()
        {
            List<ReportDb> searchResult = new List<ReportDb>();
            try
            {
                searchResult = bsObj.getSearchListByParam(null,null,null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();

        }

        [HttpPost]
        public JsonResult GetFilterResult(string FilterBy, string OrderBy, string SearchValue)
        {
            List<ReportDb> searchResult = new List<ReportDb>();
            try
            {
                searchResult = bsObj.getSearchListByParam(FilterBy, OrderBy, SearchValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(searchResult, JsonRequestBehavior.AllowGet);
        }
    }
}