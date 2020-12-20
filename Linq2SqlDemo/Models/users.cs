using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Linq2SqlDemo.Models
{
    public class users
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter UserName.")]

        public string userName { get; set; }

        [Required(ErrorMessage = "Please Enter Password.")]
        [DataType(DataType.Password)]
        [MinLength(6), MaxLength(15)]
        public string password { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Full Name.")]
        public string fullName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Email Id.")]
        [Remote("IsExist", "Place", ErrorMessage = "Email Id Already Exist!")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string emailId { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Required.")]
        [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Phone No. ")]
        public string phoneNo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Select City Name")]
        public int? cityId { get; set; }

        public List<SelectListItem> Cities { get; set; }
        public bool RememberMe { get; set; }

        public users(User u)
        {
            this.userId = u.userId;
            this.userName = u.userName;
            this.fullName = u.fullName;
            this.emailId = u.emailId;
            this.phoneNo = u.phoneNo;
            this.password = u.password;
            this.cityId = u.cityid;
        }

        public users()
        {
        }
    }
}