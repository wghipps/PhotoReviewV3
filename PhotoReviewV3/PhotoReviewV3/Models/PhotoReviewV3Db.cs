using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PhotoReviewV3.Models
{
    public class PhotoReviewV3Db : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }
}