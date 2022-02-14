using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using productTask.Models.Database;
using System.Web.Script.Serialization;

namespace productTask.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            productEntities db = new productEntities();
            var pl = db.products.ToList();
            return View(pl);
        }
        public ActionResult Checkout()
        {
            var pr = Session["cart"].ToString();
            List<product> plist = new JavaScriptSerializer().Deserialize<List<product>>(pr);
            return View(plist);
        }
        public ActionResult Removefromcart(int id)
        {
            productEntities db = new productEntities();
            product p = (from pp in db.products
                         where pp.id.Equals(id)
                         select pp).FirstOrDefault();
            var pr = Session["cart"].ToString();
            List<product> plist = new JavaScriptSerializer().Deserialize<List<product>>(pr);
            plist.Remove(p);
            string json = new JavaScriptSerializer().Serialize(plist);
            Session["cart"] = json;
            return RedirectToAction("Checkout");
            //return View(plist);
        }
        public ActionResult Addtocart(int id)
        {
            productEntities db = new productEntities();
            product p = (from pp in db.products
                         where pp.id.Equals(id)
                         select pp).FirstOrDefault();


            if (Session["cart"] != null)
            {
                var pr = Session["cart"].ToString();
                List<product> plist = new JavaScriptSerializer().Deserialize<List<product>>(pr);
                plist.Add(p);
                string json = new JavaScriptSerializer().Serialize(plist);
                Session["cart"] = json;
                return RedirectToAction("index");
            }
            else
            {

                List<product> plist = new List<product>();
                plist.Add(p);

                string json = new JavaScriptSerializer().Serialize(plist);
                Session["cart"] = json;
                return RedirectToAction("index");
            }
        }
    }
}