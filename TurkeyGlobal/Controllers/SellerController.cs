using CNR.WEBUI.Content.Helper;
using Entity.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TurkeyGlobal.Context;

namespace TurkeyGlobal.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller
        public ActionResult Index()
        {
            return View();
        }
        turkeyGlobalContext db = new turkeyGlobalContext();
        //Product
        #region Create
        public ActionResult AddProduct()
        {
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title");
            ViewBag.CurrencyTypeid = new SelectList(db.CurrencyTypes.Where(x => x.IsActive == true), "ID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProduct(Product product, HttpPostedFileBase File)
        {
            User user = new User();
            if (ModelState.IsValid)
            {
                if (File != null)
                {
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Products/" + photoName));
                    File.SaveAs(url);
                    product.File = photoName;
                    product.IsActive = true;
                    product.LastDateTime = DateTime.Now;
                    product.Slug = StringHelper.StringReplacer(product.Title.ToLower());
                    product.Sellerid = user.ID;

                    db.Products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Seller");
                }
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", product.ProductCategoryID);
            return View(product);
        }
        #endregion
        #region List
        public ActionResult ProductList()
        {
            var x = db.Products.ToList();
            return View(x);
        }
        #endregion
        #region Update
        public ActionResult UpdateProduct(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", product.ProductCategoryID);
            return View(product);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateProduct(int id, Product product, HttpPostedFileBase File)
        {
            var AU = db.Products.Find(id);
            if (ModelState.IsValid)
            {

                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/Products/" + product.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/Products/" + product.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Products/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;

                }
                AU.Title = product.Title;
                AU.Description = product.Description;
                AU.ShorDescription = product.ShorDescription;
                AU.Price = product.Price;
                AU.CurrencyTypeid = product.CurrencyTypeid;
                AU.ProductCategoryID = product.ProductCategoryID;
                AU.Sellerid = product.Sellerid;
                AU.ProductCategoryID = product.ProductCategoryID;
                AU.IsActive = product.IsActive;
                AU.LastDateTime = DateTime.Now;
                AU.Slug = StringHelper.StringReplacer(AU.Title.ToLower());
                db.SaveChanges();
                return RedirectToAction("Product", "Dashboard");
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", product.ProductCategoryID);
            return View(product);
        }
        #endregion
        #region Delete
        public ActionResult DeleteProduct(int ID)
        {
            Product product = db.Products.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/Products/" + product.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/Products/" + product.File));
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Product", "Dashboard");
        }
        #endregion
        //ProductCategory
        #region Create
        public ActionResult AddProductCategory()
        {

            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddProductCategory(ProductCategory productcategory, HttpPostedFileBase File)
        {
            User user = new User();
            if (ModelState.IsValid)
            {


                productcategory.IsActive = true;
                productcategory.LastDateTime = DateTime.Now;
                productcategory.Slug = StringHelper.StringReplacer(productcategory.Title.ToLower());
                db.ProductCategories.Add(productcategory);
                db.SaveChanges();
                return RedirectToAction("Index", "Seller");

            }

            return View(productcategory);
        }
        #endregion
        #region Delete
        public ActionResult DeleteProductCategory(int ID)
        {
            Product product = db.Products.Where(x => x.ID == ID).SingleOrDefault();
            if (System.IO.File.Exists(Server.MapPath("~/File/Products/" + product.File)))
            {
                System.IO.File.Delete(Server.MapPath("~/File/Products/" + product.File));
            }
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("ProductCategory", "Index");
        }
        #endregion
        #region Update
        public ActionResult UpdateProductCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", product.ProductCategoryID);
            return View(product);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult UpdateProductCategory(int id, Product product, HttpPostedFileBase File)
        {
            var AU = db.Products.Find(id);
            if (ModelState.IsValid)
            {

                if (File != null)
                {
                    if (System.IO.File.Exists(Server.MapPath("~/File/Products/" + product.File)))
                    {
                        System.IO.File.Delete(Server.MapPath("~/File/Products/" + product.File));
                    }
                    string photoName = Path.GetFileName(Guid.NewGuid().ToString() + File.FileName);
                    var url = Path.Combine(Server.MapPath("~/File/Products/" + photoName));
                    File.SaveAs(url);
                    AU.File = photoName;
                }
                AU.Title = product.Title;
                AU.Description = product.Description;
                AU.ShorDescription = product.ShorDescription;
                AU.Price = product.Price;
                AU.CurrencyTypeid = product.CurrencyTypeid;
                AU.ProductCategoryID = product.ProductCategoryID;
                AU.Sellerid = product.Sellerid;
                AU.ProductCategoryID = product.ProductCategoryID;
                AU.IsActive = product.IsActive;
                AU.LastDateTime = DateTime.Now;
                AU.Slug = StringHelper.StringReplacer(AU.Title.ToLower());
                db.SaveChanges();
                return RedirectToAction("Product", "Dashboard");
            }
            ViewBag.ProductCategoryID = new SelectList(db.ProductCategories.Where(x => x.IsActive == true), "ID", "Title", product.ProductCategoryID);
            return View(product);
        }
        #endregion
        #region List
        public ActionResult ProductCategoryList()
        {
            var x = db.ProductCategories.ToList();
            return View(x);
        }
        #endregion

    }
}