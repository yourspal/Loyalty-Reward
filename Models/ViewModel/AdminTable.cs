using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyaltyReward.Models.ViewModel
{
    public class AdminTable
    {
        public string VideoName { get; set; }
        public DateTime startDate { get; set; }
        public int RewardEarned { get; set; }
    }
}