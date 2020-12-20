using Linq2SqlDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linq2SqlDemo.Controllers
{
    public class HomeController : Controller
    {
        DataClasses1DataContext dbcontext = new DataClasses1DataContext() ;
        public ActionResult Index()
        {
            users u = new users();
            return View(u);
        }
        [HttpPost]
        public ActionResult Index(users user)
        {
            User u1 = dbcontext.Users.SingleOrDefault(emp => (emp.emailId==user.emailId) && (emp.password==user.password));
            if (u1!=null)
            {
                dbcontext.SubmitChanges();
                return RedirectToAction("Home");
            }
           
            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            List<SelectListItem> objList = new List<SelectListItem>();
            var c = dbcontext.cities.Select(city=>city);
            users u1 = new users();
            foreach (city i in c)
            {
                objList.Add(new SelectListItem{Text=i.cityName, Value=i.cityId.ToString() });
            }
            u1.Cities = objList;
            return View(u1);
        }

        [HttpPost]
        public ActionResult Create(users user)
        {
            User u2 = new User(user);
            dbcontext.Users.InsertOnSubmit(u2);
            dbcontext.SubmitChanges();
            return RedirectToAction("About");
        }

        public ActionResult Home()
        {
            ViewBag.msg = "Welcome Home Adinath";
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
    }
}