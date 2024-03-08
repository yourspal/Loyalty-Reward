using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace LoyaltyReward.Models.ViewModel
{
    public class UserVeiwModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string LoginName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        
    }
}