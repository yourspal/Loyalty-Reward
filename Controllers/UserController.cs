using LoyaltyReward.BAL;
using LoyaltyReward.Models;
using LoyaltyReward.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoyaltyReward.Controllers
{
    public class UserController : Controller
    {

        IUserBal balObj = new UserBal();
        public ActionResult GetUser()
        {
            var t = balObj.Getall();
            return View(t);
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(UserVeiwModel user)
        {
            balObj.Create(user);
            ViewBag.Result = "User Creation Successful You will be able to login Once Verified By Administrator";
            ModelState.Clear();
            return View();
        }
        public ActionResult UserLogin()
        {
            ViewBag.Result = "";
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(LoginViewModel user, AdminViewModel au)
        {
            AdminViewModel adminViewModel = balObj.Login(user);
            if (adminViewModel != null)
            {
                Session["UID"] = adminViewModel.UserId;
                Session["adm"] = adminViewModel.IsAdmin;
                Session["Name"] = adminViewModel.FirstName;

                if (adminViewModel.Status == 0)
                {
                    ViewBag.Result = "User verification pending!!!";
                }
                else if (adminViewModel.Status == -1)
                {
                    ViewBag.Result = "Account Blocked Contact Admin for Support!";
                }
                else
                {
                    if (adminViewModel.IsAdmin == 0)
                    {
                        Session["usr"] = user.LoginName;
                        return RedirectToAction("UserDashBoard", "Home");
                    }
                    else
                    {
                        Session["usr"] = user.LoginName;
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            else
            {
                ViewBag.Result = "Incorrect User Name or Password!!!";
            }
            return View();
        }

        [HttpPost]
        public ActionResult UserLoginByID()
        {

            var UID = Convert.ToInt32(Session["UID"]);
            AdminViewModel adminViewModel = balObj.LoginByID(UID);
            if (adminViewModel != null)
            {
                Session["UID"] = adminViewModel.UserId;
                Session["adm"] = adminViewModel.IsAdmin;
                Session["Name"] = adminViewModel.FirstName;

            }
            else
            {
                ViewBag.Result = "Incorrect User Name or Password!!!";
            }
            return View();
        }
        [HttpGet]
        public ActionResult AddBalance(int userid, int videoid)
        {
            // Call the stored procedure UDSP_AddBalance with the provided userId
            // Execute the stored procedure logic here
            balObj.AddBalance(userid, videoid);
            // Assuming you have called the stored procedure successfully and obtained the result
            var result = new { success = true, message = "Balance added successfully" };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult ShowBalance(int userid)
        {
            var result = balObj.TotalBalance(userid);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Index()
        {
            var t = balObj.Getall();
            return View(t);
        }
    }
}