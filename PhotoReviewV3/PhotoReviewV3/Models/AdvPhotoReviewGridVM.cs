using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PhotoReviewV3.Models
{
    [NotMapped]
    public class AdvPhotoReviewGridVM
    {
        public int Id { get; set; }
        [Display(Name = "Photo")]
        public string Name { get; set; }
        [Display(Name = "Project Name")]
        public string Project { get; set; }
        [Display(Name = "Store Name")]
        public string Store { get; set; }
        public string Description { get; set; }
        [Display(Name = "Photo Status")]
        public string Status { get; set; }
    }
}