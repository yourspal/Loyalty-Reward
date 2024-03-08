using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoyaltyReward.Models
{
    public class BankDetails
    {
        public int UserID { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName {get; set;}
        public int AccountNumber { get; set;}
        public string IFSC { get; set; }
        public int Amount { get; set;}  
    }
}