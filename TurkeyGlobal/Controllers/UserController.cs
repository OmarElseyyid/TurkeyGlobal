using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TurkeyGlobal.Context;

namespace TurkeyGlobal.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        turkeyGlobalContext db = new turkeyGlobalContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                using (turkeyGlobalContext db = new turkeyGlobalContext())
                {
                    var obj = db.Users.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        if (obj.UserRolid==1)
                        {
                            return RedirectToAction("Index", "Buyer");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Seller");
                        }
                       
                    }
                    else
                    {
                        return View(user);
                    }
                }
            }
            else
            {
                return View(user);
            }
        }


        [ValidateInput(false)]
        public ActionResult Register(User user)
        {
            if (Request.HttpMethod == "POST")
            {
                user.IsActive = true;
                user.LastDateTime = DateTime.Now;
                user.Wallet = 0;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login", "User");
            }
            else
            {
                return View();
            }
        }
    }
}