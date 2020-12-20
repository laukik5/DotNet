using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstApplication.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        //public string Index()
        //{
        //    return "Hello <b>World</b>";
        //}
        public ActionResult Method2()
        {
            return View();
        }

        //only receiving id
        //url will be http://localhost:57000/Controller/Action/Id
        public ActionResult First(int id=0)
        {
            ViewBag.Id = id;
            return View();
        }

        //receiving other parameters
        //url will be http://localhost:57000/Controller/Action/Id?a=10&b=20&c=Vik

        public ActionResult Second(int id = 0, int a=0, int b=0, string c= "")
        {
            ViewBag.Id = id;
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;
            return View();
        }
    }
}