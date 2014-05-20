using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newBlog.Controllers
{
    public class HomeController : Controller
    {
        //Step 1. Set up database access
        Models.newBlogEntities db = new Models.newBlogEntities();


        //
        // GET: /Home/

        public ActionResult Index()
        {
            var list = db.Posts.OrderByDescending(x => x.PostedOn);
            return View(list);
        }

        public ActionResult Like(int id)
        {
            //Gets the post from the database
            var post = db.Posts.Where(x => x.PostID == id).First();
            //Increments the respects
            post.PostLikes += 1;
            //Save changes to the database
            db.SaveChanges();
            //Return to index
            return Content(post.PostLikes + " Likes");
        }

        public ActionResult AddComment(int id, FormCollection values)
        {
            //Making a new comment
            var comment = new Models.Comment();
            comment.PostID = id;
            //comment.CommentAuthor = values["author"];
            comment.CommentText = values["body"];
            comment.CommentedOn = DateTime.Now;
            comment.CommentLikes = 0;
            //Add the comment to the database
            db.Comments.Add(comment);
            db.SaveChanges();
            //Return to index

            //Get the post
            return PartialView("Comment", comment);
        }
    }
}
