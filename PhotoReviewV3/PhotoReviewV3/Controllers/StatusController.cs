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
    public class StatusController : Controller
    {
        private PhotoReviewV3Db db = new PhotoReviewV3Db();

        public ActionResult GetSearchList()
        {
            //return View(db.Stores.ToList());
            return PartialView("_SearchCriteria", db.Statuses.ToList());
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