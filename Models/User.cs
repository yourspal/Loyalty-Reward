using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoyaltyReward.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
       
    }
}