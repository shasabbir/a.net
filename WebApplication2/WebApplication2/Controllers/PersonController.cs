using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult home()
        {
            /*ViewBag.name = "Sabbir";
            ViewBag.id = 1234;*/
            Person p = new Person();
            p.Name = "Sabbir-M";
            p.Id = 1234;
            return View(p);
        }
        public ActionResult list()
        {
            /*string[] names = { "nafis", "salman", "samin", "jamil" };
            ViewBag.list=names;*/
            Person[] p= new Person[10];
            for(int i = 0; i < p.Length; i++)
            {
                p[i] = new Person();
                p[i].Id = i+1;
                p[i].Name = "person"+(i+1);
            }
            return View(p);
        }
    }
}