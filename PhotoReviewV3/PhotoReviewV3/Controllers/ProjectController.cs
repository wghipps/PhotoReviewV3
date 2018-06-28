using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PhotoReviewV3.Models;

namespace PhotoReviewV3.Controllers
{
    public class ProjectController : Controller
    {
        private PhotoReviewV3Db db = new PhotoReviewV3Db();

        public ActionResult GetSearchList()
        {
            //return View(db.Projects.ToList());
            return PartialView("_SearchCriteria", db.Projects.ToList());
        }
        
        // GET: Project
        public ActionResult Index()
        {
            return View(db.Projects.ToList());
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
