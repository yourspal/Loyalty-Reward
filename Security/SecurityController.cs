using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
namespace LoyaltyReward.Security
    
{
    public class SecurityController: ActionFilterAttribute, IAuthenticationFilter
    {
        void IAuthenticationFilter.OnAuthentication(AuthenticationContext filterContext)
        {
            //This function will be executed before it loads  controller

            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["usr"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        void IAuthenticationFilter.OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
            }
        }
    }
}