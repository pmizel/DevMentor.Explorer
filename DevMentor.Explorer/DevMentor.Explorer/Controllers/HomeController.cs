using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevMentor.Explorer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var key = form["key"];
            Session["key"] = key;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Download(string name)
        {
            var filename = System.IO.Path.Combine(Server.MapPath("~/App_Data/"), name.Replace("..",""));
            if (System.IO.File.Exists(filename))
            {
                this.Response.AddHeader("content-disposition", "attachment; filename=" + name);
                return this.File(filename, "application/octet-stream");
            }

           throw new NotImplementedException(filename);
        }
    }
}