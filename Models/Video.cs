using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoyaltyReward.Models
{
    public class Video
    {
        public int VideoID { get; set; }
        public int UserID { get; set; }
        public string VideoName { get; set; }
        public string VideoPath { get; set; }
        public int Amount { get; set; }

        public DateTime startDate{ get; set; }
        public DateTime endDate { get; set; }

    }
}