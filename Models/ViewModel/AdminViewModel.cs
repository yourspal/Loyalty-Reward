using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyaltyReward.Models.ViewModel
{
    public class AdminViewModel
    {
        public int UserId { get; set; }
        public string LoginName { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }
        public string StatusVal { get; set; }
        public int IsAdmin { get; set; }
        public string VideoPath { get; set; }
        public string VideoName { get; set; }   
        public int Amount { get; set; } 
    }
}