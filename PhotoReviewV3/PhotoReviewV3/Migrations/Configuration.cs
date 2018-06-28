namespace PhotoReviewV3.Migrations
{
    using PhotoReviewV3.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhotoReviewV3.Models.PhotoReviewV3Db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PhotoReviewV3.Models.PhotoReviewV3Db context)
        {
            context.Projects.AddOrUpdate(p => p.Name,
                new Project { Name = "Project 1" },
                new Project { Name = "Project 2" },
                new Project { Name = "Project 3" },
                new Project { Name = "Project 4" },
                new Project { Name = "Project 5" },
                new Project { Name = "Project 6" }
                );
            context.SaveChanges();

            context.Stores.AddOrUpdate(s => s.Name,
                new Store { Name = "Store 1" },
                new Store { Name = "Store 2" },
                new Store { Name = "Store 3" },
                new Store { Name = "Store 4" },
                new Store { Name = "Store 5" },
                new Store { Name = "Store 6" }
                );
            context.SaveChanges();

            context.Statuses.AddOrUpdate(s => s.Name,
                new Status { Name = "Received" },
                new Status { Name = "Reviewed" }
                );
            context.SaveChanges();

            var projects = context.Projects.ToDictionary(p => p.Name, p => p.Id);
            var stores = context.Stores.ToDictionary(s => s.Name, s => s.Id);
            var statuses = context.Statuses.ToDictionary(s => s.Name, s => s.Id);

            context.Photos.AddOrUpdate(
                new Photo { Name = "Photo 1", Description = "Description of photo 1", ProjectId = projects["Project 1"], StoreId = stores["Store 1"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 2", Description = "Description of photo 2", ProjectId = projects["Project 2"], StoreId = stores["Store 2"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 3", Description = "Description of photo 3", ProjectId = projects["Project 2"], StoreId = stores["Store 2"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 4", Description = "Description of photo 4", ProjectId = projects["Project 3"], StoreId = stores["Store 3"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 5", Description = "Description of photo 5", ProjectId = projects["Project 3"], StoreId = stores["Store 3"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 6", Description = "Description of photo 6", ProjectId = projects["Project 3"], StoreId = stores["Store 3"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 7", Description = "Description of photo 7", ProjectId = projects["Project 4"], StoreId = stores["Store 4"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 8", Description = "Description of photo 8", ProjectId = projects["Project 4"], StoreId = stores["Store 4"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 9", Description = "Description of photo 9", ProjectId = projects["Project 4"], StoreId = stores["Store 4"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 10", Description = "Description of photo 10", ProjectId = projects["Project 4"], StoreId = stores["Store 4"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 11", Description = "Description of photo 11", ProjectId = projects["Project 5"], StoreId = stores["Store 5"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 12", Description = "Description of photo 12", ProjectId = projects["Project 5"], StoreId = stores["Store 5"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 13", Description = "Description of photo 13", ProjectId = projects["Project 5"], StoreId = stores["Store 5"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 14", Description = "Description of photo 14", ProjectId = projects["Project 5"], StoreId = stores["Store 5"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 15", Description = "Description of photo 15", ProjectId = projects["Project 5"], StoreId = stores["Store 5"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 16", Description = "Description of photo 16", ProjectId = projects["Project 6"], StoreId = stores["Store 6"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 17", Description = "Description of photo 17", ProjectId = projects["Project 6"], StoreId = stores["Store 6"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 18", Description = "Description of photo 18", ProjectId = projects["Project 6"], StoreId = stores["Store 6"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 19", Description = "Description of photo 19", ProjectId = projects["Project 6"], StoreId = stores["Store 6"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 20", Description = "Description of photo 20", ProjectId = projects["Project 6"], StoreId = stores["Store 6"], StatusId = statuses["Received"] },
                new Photo { Name = "Photo 21", Description = "Description of photo 21", ProjectId = projects["Project 6"], StoreId = stores["Store 6"], StatusId = statuses["Received"] }
                );
            context.SaveChanges();

            //context.Projects.AddOrUpdate(r => r.Name,
            //    new Project
            //    {
            //        Name = "Project 1",
            //        Photos =
            //            new List<Photo>
            //            {
            //                new Photo { Name = "Photo 1", Description = "description 1"}
            //            }
            //    },
            //    new Project
            //    {
            //        Name = "Project 2",
            //        Photos =
            //            new List<Photo>
            //            {
            //                new Photo { Name = "Photo 2", Description = "description 2"},
            //                new Photo { Name = "Photo 3", Description = "description 3"}
            //            }
            //    },
            //    new Project
            //    {
            //        Name = "Project 3",
            //        Photos =
            //            new List<Photo>
            //            {
            //                new Photo { Name = "Photo 4", Description = "description 4"},
            //                new Photo { Name = "Photo 5", Description = "description 5"},
            //                new Photo { Name = "Photo 6", Description = "description 6"}
            //            }
            //    },
            //    new Project { Name = "Project 4"},
            //    new Project { Name = "Project 5" },
            //    new Project { Name = "Project 6" }
            //    );
        }
    }
}
