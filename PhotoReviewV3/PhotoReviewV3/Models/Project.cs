using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoReviewV3.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}