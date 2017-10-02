using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace minSide.Models {
    public class UsersContext : DbContext {
        public UsersContext() {

        }

    }
    public class LoginModel {
        //UserName
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        //Password
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //Remember Me
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    //A  model for registering
    public class RegisterModel {
        //UserName
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LName { get; set; }

        [Required]
        [Display(Name = "e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "What are you to me")]
        public string Role { get; set; }

        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        //Password
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {8} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        //Confirm Password
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Your Age")]
        public int Age { get; set; }
    }

    //This model is for resetting the password
    public class LocalPasswordModel {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {8} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}