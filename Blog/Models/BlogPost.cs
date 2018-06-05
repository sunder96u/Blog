using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Models
{
    public class BlogPost
    {
        //Constructor - The Constructor is a special method that has the same name as the class and runs
        //when a new instance of the class is instantiated
        public BlogPost ()
        {
            this.Comments = new HashSet<Comment>();
        }

        //Each of these propertiesshow up as columns in a DB Table
        public int Id { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset? Updated { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Abstract { get; set; }
        [AllowHtml]
        public string Body { get; set; }
        public string MediaURL { get; set; }
        public bool Published { get; set; }
        public bool IsDeleted { get; set; }

        // Navigation porperty - This does not show up int the DB Table
        public virtual ICollection<Comment> Comments { get; set; }
    }

}