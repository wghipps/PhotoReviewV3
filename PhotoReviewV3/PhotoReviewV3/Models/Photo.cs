using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhotoReviewV3.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }
        public int StoreId { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
    }
}