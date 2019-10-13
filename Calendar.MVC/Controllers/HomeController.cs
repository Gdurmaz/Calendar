using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Calendar.MVC.Models;

namespace Calendar.MVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ReadJsonData()
        {
            List<Models.Calendar> getcalendars = new List<Models.Calendar>();
            //Calendar.Mvc projesinin içinde content klasöründe data.json'dan veri okuma
            using (StreamReader rdr = new StreamReader(Server.MapPath(@"~/Content/data.json")))
            {
                getcalendars = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Models.Calendar>>(rdr.ReadToEnd());
            }
            //linq sorgusuyla okunan veriyi oluşturma
            var ListCalendars = from I in getcalendars
                                select new
                                {
                                    id = I.ID,
                                    title =I.Title,
                                    start = I.StartingDate,
                                    end = I.EndDate
                                };

            return Json(ListCalendars.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}