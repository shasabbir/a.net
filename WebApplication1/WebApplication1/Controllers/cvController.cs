using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class cvController : Controller
    {
        // GET: cv
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult education()
        {
            return View();
        }
        public ActionResult projects()
        {
            return View();
        }
        public ActionResult reference()
        {
            return View();
        }
    }
}