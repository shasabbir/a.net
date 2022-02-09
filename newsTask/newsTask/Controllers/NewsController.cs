using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using newsTask.Models.Database;
using System.Data.Entity.Migrations;

namespace newsTask.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            newsEntities db = new newsEntities();
            var allnews = db.news.ToList();
            return View(allnews);
            //return View();
        }
        public ActionResult showAll()
        {
            newsEntities db = new newsEntities();
            var allnews = db.news.ToList();
            return View(allnews);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            newsEntities db = new newsEntities();
            var news = (from n in db.news where n.id.Equals(id) select n).FirstOrDefault();
            return View(news);
        }
        [HttpPost]
        public ActionResult Edit(news nn)
        {
            if (ModelState.IsValid)
            {
                newsEntities db = new newsEntities();
                var nw = (from nnn in db.news where nnn.id.Equals(nn.id) select nnn).FirstOrDefault();
                //return View(news);
                db.Entry(nw).CurrentValues.SetValues(nn);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            newsEntities db = new newsEntities();
            var news = (from n in db.news where n.id.Equals(id) select n).FirstOrDefault();
            db.news.Remove(news);
            db.SaveChanges();
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Add()
        {
            //newsEntities db = new newsEntities();
            //var news = (from n in db.news where n.id.Equals(id) select n).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Add(news nn)
        {
            if (ModelState.IsValid)
            {
                newsEntities db = new newsEntities();
                var nw = (from nnn in db.news where nnn.id.Equals(nn.id) select nnn).FirstOrDefault();
                //return View(news);
                db.news.Add(nn);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }

    }
}