using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Game.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Index(String AdminID, String Password)
        {
            if (String.IsNullOrEmpty(AdminID) || String.IsNullOrEmpty(Password))
            {
                ViewBag.Message = "Please enter your details ";
            }
            else
            {
                if (AdminID == "adminid" && Password == "password")
                {
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ViewBag.Message = "Invalid Details ";
                }
            }
            return View();
        }
        public ActionResult LogIn()
        {
            return RedirectToAction("Index");
        }
    }

}
