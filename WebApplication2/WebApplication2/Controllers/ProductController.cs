using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult List()
        {
            List <Product> list = new List<Product> ();
            for(int i = 0; i < 10; i++)
            {
                Product p = new Product ();
                p.Id = i+1;
                p.Name = "Product"+i.ToString();
                list.Add (p);
            }
            return View(list);
        }
    }
}