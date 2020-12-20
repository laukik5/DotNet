
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace UserProfile.Models
{
    public class Users
    {
        [Key]
        public int userId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter UserName.")]

        public string userName { get; set; }

        [Required(ErrorMessage = "Please Enter Password.")]
        [DataType(DataType.Password)]
        [MinLength(6), MaxLength(15)]
        public string password { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Enter Full Name.")]
        public string fullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Please Enter Email Id.")]
        [Remote("IsExist", "Place", ErrorMessage = "Email Id Already Exist!")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string emailId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required.")]
        [Compare("password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter Phone No. ")]
        public long phoneNo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Please Select City Name")]
        public int cityId { get; set; }

        public List<SelectListItem> Cities { get; set; }
        public bool RememberMe { get; set; }
    }
}