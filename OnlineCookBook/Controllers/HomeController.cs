using OnlineCookBook.MongoDB_DataLayer;
using OnlineCookBook.MongoDB_DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Bson;

namespace OnlineCookBook.Controllers
{
    public class HomeController : Controller
    {
        DataLayer storage = new DataLayer();
        public ActionResult Index()
        {
            ViewBag.User = HttpContext.Application["User"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewBag.User = HttpContext.Application["User"];
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.User = HttpContext.Application["User"];
            return View();
        }

        
        public ActionResult RecepiesView(string type)
        {
            ViewBag.User = HttpContext.Application["User"];
            List<Recipe> r = storage.ReturnRecipesByCategory(type);
            return View(r);
        }

        public ActionResult FullRecepieView(string recepieId)
        {
            ViewBag.User = HttpContext.Application["User"];
            Recipe r = storage.ReturnRecipeById(recepieId);
            return View(r);
        }

        public ActionResult RegisterView()
        {
            
            return View();
        }

        public ActionResult RegisterUser(User user)
        {
            string message="sadasd";
            return Json("{ \"message\" :\"" + message + "\"  }");
        }
        public ActionResult Login(string username, string password)
        {
            string message = "sadasd";
            HttpContext.Application["User"] = username;
            return Json("{ \"message\" :\"" + message + "\"  }");
            
        }
        public ActionResult Logout()
        {
           
            HttpContext.Application["User"] = null;
            return RedirectToAction("Index", "Home");
          

        }
    }
}