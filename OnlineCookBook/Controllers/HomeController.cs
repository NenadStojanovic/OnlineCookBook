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

        
        public ActionResult RecepiesView(string type)
        {
            string t = "dinner";
            List<Recipe> r = storage.ReturnRecipesByCategory(t);

            

            List<Recipe> lr = storage.ReturnRecipesByPartialName("not");


            Recipe p = new Recipe();
            ObjectId idp = ObjectId.Parse("589dbe11e4661e631df197c6");
            //p.Id = idp;
            p.Name = "janko";
            storage.InsertRecipeToDB(p);

            Recipe l = storage.ReturnRecipeById("589dbe11e4661e631df197c5");

            storage.DeleteRecipeFromDB(idp);

            return View(r);
        }
    }
}