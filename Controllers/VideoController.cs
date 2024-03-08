using LoyaltyReward.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoyaltyReward.Security;

namespace LoyaltyReward.Controllers
{
    [SecurityController]
    public class VideoController : Controller
    {
        IUserBal obj = new UserBal();
        public ActionResult Index()
        {
            int UID = Convert.ToInt32(Session["UID"]);
            var t = obj.GetVideo(UID);
            return View(t);
        }
        public ActionResult TotalUser()
        {
            var t=obj.TotalUsers();
            return Json(t, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TotalVideos()
        {
            var t = obj.TotalVideos();
            return Json(t,JsonRequestBehavior.AllowGet);
        }
        public ActionResult TotalEarned()
        {
            var t = obj.TotalEarned();
            return Json(t, JsonRequestBehavior.AllowGet);
        }
        public ActionResult MostEarned(string id)
        {
            var uid = Convert.ToInt32(id);
            var t = obj.MostEarned(uid);
            return Json(t, JsonRequestBehavior.AllowGet);
        }

        public ActionResult TotalWatched(int id)
        {
            var t = obj.TotalWatched(id);
            return Json(t, JsonRequestBehavior.AllowGet);
        }
    }
}