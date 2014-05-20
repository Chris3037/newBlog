using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace newBlog.Models
{
    [MetadataType(typeof(AuthorMetaData))]
    public partial class Author
    {
    }

    public class AuthorMetaData
    {
        [Required(ErrorMessage = "You need to enter a user name")
        , Display(Name = "User Name")]
        public string AuthorUserName;

        [Display(Name = "First Name")]
        public string AuthorFirstName;

        [Display(Name = "Last Name")]
        public string AuthorLastName;

        [Display(Name = "Email")]
        public string AuthorEmal;

        [Display(Name = "Date of Birth (xx/xx/xx)")]
        public string AuthorDOB;

        [Required(ErrorMessage = "You need to choose a picture from online")
        , Display(Name = "Picture")]
        public string AuthorPic;

        [Display(Name = "Bio")]
        public string AuthorBio;

    }
}