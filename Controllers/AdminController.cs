using LoyaltyReward.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoyaltyReward.Models.ViewModel;
using LoyaltyReward.Models;
using LoyaltyReward.Security;

namespace LoyaltyReward.Controllers
{
    [SecurityController]
    public class AdminController : Controller
    {
        IUserBal balObj = new UserBal();
        // GET: Admin
        public ActionResult Index()
        {
            var t = balObj.Getall();
            return View(t);
        }
        public ActionResult EditStatus(int id)
        {
            balObj.Approve(id);
            return RedirectToAction("Index", "User");
        }

        public ActionResult BlockUser(int id)
        {
            balObj.Block(id);
            return RedirectToAction("Index", "User");
        }
        [HttpGet]
        public ActionResult AddVideo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVideo(VideoAddViewModel vid)
        {

            balObj.AddVideo(vid);
            ModelState.Clear();
            return View();
        }
        public ActionResult RemoveVideo()
        {
            var id = Convert.ToInt32(Request.QueryString["videoID"]);
            balObj.RemoveVideo(id);
            return RedirectToAction("Index", "Video");
        }
    }
}