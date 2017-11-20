using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace minSide.Models {
    [Table("UserNotes")]
    public class User {

        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual RegisterModel Model { get; set; }

        [Required]
        [Display(Name = "e-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "First name")]
        public string FName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        public string LName { get; set; }

        [Required]
        [Display(Name = "What are you to me")]
        public string Role { get; set; }

        [Display(Name = "Phone number")]
        public string Phone { get; set; }

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
}