using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoyaltyReward.Models.ViewModel
{
    public class LoginViewModel
    {
        public string LoginName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}