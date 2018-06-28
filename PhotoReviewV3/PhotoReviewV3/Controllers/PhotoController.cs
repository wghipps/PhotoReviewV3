using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhotoReviewV3.Models;
using PagedList;

namespace PhotoReviewV3.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoReviewV3Db db = new PhotoReviewV3Db();

        // GET: Photo
        public ActionResult Index(string searchTerm = null, int ddlProjects = -1, int ddlStores = -1, int ddlStatus = -1, int page = 1)
        {
            var model =
                db.Photos
                .Where(r => (searchTerm == null || r.Name.Contains(searchTerm)) && (ddlProjects <= 0 || r.ProjectId == ddlProjects)
                            && (ddlStores <= 0 || r.StoreId == ddlStores) && (ddlStatus <= 0 || r.StatusId == ddlStatus))
            #region WGH - one join to project
                    //.Join(db.Projects, ph => ph.ProjectId, pr => pr.Id, (ph, pr)
                    //=> new AdvPhotoReviewGridVM
                    //   {
                    //       Id = ph.Id,
                    //       Name = ph.Name,
                    //       Project = pr.Name,
                    //       Store = "store",
                    //       Description = ph.Description,
                    //       Status = "status"
                    //   })
            #endregion

            #region WGH - two joins to project and store
                    //.Join(db.Projects, ph => ph.ProjectId, pr => pr.Id, (ph, pr) => new { ph, pr })
                    //.Join(db.Stores, ph2 => ph2.ph.StoreId, st => st.Id, (ph2, st) //=> new { ph2, st })
                    //=> new AdvPhotoReviewGridVM
                    //{
                    //    Id = ph2.ph.Id,
                    //    Name = ph2.ph.Name,
                    //    Project = ph2.pr.Name,
                    //    Store = st.Name,
                    //    Description = ph2.ph.Description,
                    //    Status = "status"
                    //})
            #endregion

            #region WGH - three joins to project, store and status
                    .Join(db.Projects, ph => ph.ProjectId, pr => pr.Id, (ph, pr) => new { ph, pr })
                    .Join(db.Stores, ph2 => ph2.ph.StoreId, st => st.Id, (ph2, st) => new { ph2, st })
                    .Join(db.Statuses, ph3 => ph3.ph2.ph.StatusId, stat => stat.Id, (ph3, stat) //=> new { ph2, st })
                    => new AdvPhotoReviewGridVM
                    {
                        Id = ph3.ph2.ph.Id,
                        Name = ph3.ph2.ph.Name,
                        Project = ph3.ph2.pr.Name,
                        Store = ph3.st.Name,
                        Description = ph3.ph2.ph.Description,
                        Status = stat.Name
                    })
            #endregion
                    .OrderBy(r => r.Id)
                    .ToPagedList(page, 10);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_SearchResults", model);
            }
            return View(model);

        }

        // GET: Photo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // GET: Photo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ProjectId")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Photos.Add(photo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photo);
        }

        // GET: Photo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ProjectId")] Photo photo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photo);
        }

        // GET: Photo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photo photo = db.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photo);
        }

        // POST: Photo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = db.Photos.Find(id);
            db.Photos.Remove(photo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
