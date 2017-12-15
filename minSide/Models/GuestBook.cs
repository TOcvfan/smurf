using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace minSide.Models {
    public class GuestBook {

        //CommentID. This is the Primary Key
        [Key]
        public int PageCommentID { get; set; }

        [DisplayName("Brugernavn")]//UserName. This is the name of the user who made this comment
        public string UserName { get; set; }

        //Subject.  
        [Required]
        [StringLength(250)]
        public string Subject { get; set; }

        //Body
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Dato")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }
    }
}