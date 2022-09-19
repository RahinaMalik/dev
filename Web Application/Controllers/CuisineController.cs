using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using BLL_Business_Logic_Layer_;
using BOL_Business_Object_Layer_;

namespace Web_Application.Controllers
{
    public class CuisineController : Controller
    {
        private RestaurantDBEntities dbObj;
        private CuisineBs objBs;
        HttpClient client = new HttpClient();

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

            IEnumerable<Cuisine> cuisines = null;
            
            client.BaseAddress = new Uri("https://localhost:44330/api/CuisineAPI");
            
            //HTTP GET
            var responseTask = client.GetAsync("CuisineAPI");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Cuisine>>();
                readTask.Wait();

                cuisines = readTask.Result;
            }
            else //web api sent error response 
            {
                //log response status here..

                cuisines = Enumerable.Empty<Cuisine>();

                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(cuisines);

            //var cuisines = objBs.GetAll();
            //return View(cuisines);
        }

        [HttpPost]
        public ActionResult AddCuisine(Cuisine model)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44330/api/CuisineAPI");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<Cuisine>("CuisineAPI", model);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Cuisine added successfully";
                    //TempData["SuccessMsg"] = "Record added successfully";
                    return RedirectToAction("GetCuisineList");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View("AddCuisine");

        }

        [HttpGet]
        public ActionResult EditCuisine(int id)
        {
            Cuisine cuisine = null;

            client.BaseAddress = new Uri("https://localhost:44330/api/CuisineAPI");
            //HTTP GET
            var responseTask = client.GetAsync("CuisineAPI?id=" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Cuisine>();
                readTask.Wait();

                cuisine = readTask.Result;
            }
            return View(cuisine);
            //var data = dbObj.Cuisines.Where(x => x.CuisineID == id).FirstOrDefault();
            // return View(data);
        }

        [HttpPost]
        public ActionResult EditCuisine(Cuisine model)//
        {

            client.BaseAddress = new Uri("https://localhost:44330/api/CuisineAPI");
            //HTTP PUT
            var responseTask = client.PutAsJsonAsync("CuisineAPI?id=", model);
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("GetCuisineList");
                //var readTask = result.Content.ReadAsAsync<Cuisine>();
                //readTask.Wait();

                //cuisine = readTask.Result;
            }
            return View("EditCuisine");
        }

        public ActionResult DeleteCuisine(int id)
        {
            Cuisine cuisine = null;

            client.BaseAddress = new Uri("https://localhost:44330/api/CuisineAPI");
            //HTTP GET
            var responseTask = client.GetAsync("CuisineAPI?id=" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<Cuisine>();
                readTask.Wait();

                cuisine = readTask.Result;
                return RedirectToAction("GetCuisineList");
            }
            return View(cuisine);
        }
        [HttpPost, ActionName("DeleteCuisine")]
        public ActionResult DeleteConfirmed(int id)
        {
            client.BaseAddress = new Uri("https://localhost:44330/api/CuisineAPI");
            //HTTP PUT
            var responseTask = client.DeleteAsync("CuisineAPI/" + id.ToString());
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("GetCuisineList");
                //var readTask = result.Content.ReadAsAsync<Cuisine>();
                //readTask.Wait();

                //cuisine = readTask.Result;
            }
            return View("DeleteCuisine");
        }

        public static string GetApi(string ApiUrl)
        {

            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response1 = request.GetResponse())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;

        }
        public static string PostApi(string ApiUrl, string postData = "")
        {
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            var data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
    }
}