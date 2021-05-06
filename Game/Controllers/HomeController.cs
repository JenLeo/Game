using Game.Models;
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
        public ActionResult Index()
        {
            Login obj = new Login();
            return View(obj);
        }
        [HttpPost]
        public ActionResult Index(Login objuserlogin)
        {
            var display = Userloginvalues().Where(m => m.AdminID == objuserlogin.AdminID && m.Password == objuserlogin.Password).FirstOrDefault();
            if (display != null)
            {
                ViewBag.Status = "Correct details";
            }
            else
            {
                ViewBag.Status = "Incorrect details";
            }
            return View(objuserlogin);
        }
        public List<Login> Userloginvalues()
        {
            List<Login> objModel = new List<Login>();
            objModel.Add(new Login { AdminID = "user1", Password = "password1" });
            objModel.Add(new Login { AdminID = "user2", Password = "password2" });
            objModel.Add(new Login { AdminID = "user3", Password = "password3" });
            objModel.Add(new Login { AdminID = "user4", Password = "password4" });
            objModel.Add(new Login { AdminID = "user5", Password = "password5" });
            return objModel;
        }
        public ActionResult LogIn()
        {
            return RedirectToAction("Index");
        }
    }
}
//        // GET: HomeController
//        public ActionResult Index()
//        {
//            return View();

//        }


//        [HttpPost]
//        public ActionResult Index(String AdminID, String Password)
//        {
//            if (String.IsNullOrEmpty(AdminID) || String.IsNullOrEmpty(Password))
//            {
//                ViewBag.Message = "Please enter your details ";
//            }
//            else
//            {
//                if (AdminID == "adminid" && Password == "password")
//                {
//                    return RedirectToAction("Welcome", "Home");
//                }
//                else
//                {
//                    ViewBag.Message = "Invalid Details ";
//                }
//            }
//            return View();
//        }
//        public ActionResult LogIn()
//        {
//            return RedirectToAction("Index");
//        }
//    }

//}
