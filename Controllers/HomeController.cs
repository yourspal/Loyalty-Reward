using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoyaltyReward.BAL;
using LoyaltyReward.Models;
using LoyaltyReward.Security;
using Microsoft.Ajax.Utilities;

namespace LoyaltyReward.Controllers
{
    [SecurityController]
    public class HomeController : Controller
    {
        IUserBal obj = new UserBal();  
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("UserLogin", "User");
        }
        public ActionResult Interface()
        {
            int UID = Convert.ToInt32(Session["UID"]);
            var t=obj.GetVideo(UID);
            return View(t);
        }
        public ActionResult UserDashBoard()
        {
            return View();
        }
        public ActionResult UserWallet()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserWallet(BankDetails user)
        {
            user.UserID = Convert.ToInt32(Session["UID"]);
            obj.WalletRedeem(user);
            UserController objUser = new UserController();
            objUser.ShowBalance(user.UserID);
            return View();
        }
    }
}