using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurkeyGlobal.Context;

namespace TurkeyGlobal.Controllers
{
    public class BuyerController : Controller
    {
        turkeyGlobalContext db = new turkeyGlobalContext();
        // GET: Buyer
        public ActionResult Index()
        {
            return View();
        }
        #region Create
        public ActionResult AddOrder()
        {
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title");
            ViewBag.CurrencyTypeid = new SelectList(db.CurrencyTypes.Where(x => x.IsActive == true), "ID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddOrder(Order order, HttpPostedFileBase File)
        {
            User user = new User();
            if (ModelState.IsValid)
            {

                    order.IsActive = true;
                    order.LastDateTime = DateTime.Now;
                    db.Orders.Add(order);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Buyer");
                
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", order.ProductCategoryid);
            ViewBag.CurrencyTypeid = new SelectList(db.CurrencyTypes.Where(x => x.IsActive == true), "ID", "Name");
            return View(order);
        }
        #endregion
        #region List
        public ActionResult OrdertList()
        {
            var x = db.Orders.ToList();
            return View(x);
        }
        public ActionResult OrderListleme()
        {
            var x = db.Orders.ToList();
            return View(x);
        }
        public ActionResult ProductList()
        {
            var x = db.Products.ToList();
            return View(x);
        }
        #endregion
        #region Update
        public ActionResult UpdateOrder(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", order.ProductCategoryid);
            ViewBag.CurrencyTypeid = new SelectList(db.CurrencyTypes.Where(x => x.IsActive == true), "ID", "Name");
            return View(order);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateOrder(int id, Order order, HttpPostedFileBase File)
        {
            var AU = db.Orders.Find(id);
            if (ModelState.IsValid)
            {
                AU.Description = order.Description;
                
                AU.OfferPrice = order.OfferPrice;
                AU.ProductCategoryid = order.ProductCategoryid;
               
               
                AU.IsActive = order.IsActive;
                AU.LastDateTime = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index", "Buyer");
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", order.ProductCategoryid);
            return View(order);
        }
        #endregion
        #region Delete
        public ActionResult DeleteOrder(int ID)
        {
            Order order = db.Orders.Where(x => x.ID == ID).SingleOrDefault();
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index", "Buyer");
        }
        public ActionResult DeleteProduct(int ID)
        {
            Product product = db.Products.Where(x => x.ID == ID).SingleOrDefault();
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index", "Buyer");
        }
        #endregion

    }
}