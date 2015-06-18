using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICM.Data;

namespace ICM.Web.Controllers
{
    //[Authorize]
    public class AdjustersController : Controller
    {
        private ICMDBContext db = new ICMDBContext();

        // GET: Adjusters
        public ActionResult Index()
        {var adjusters = db.Adjusters.Include(a => a.InsuranceCompanyBranch);
            return View(adjusters.ToList());
        }

        // GET: Adjusters/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adjuster adjuster = db.Adjusters.Find(id);
            if (adjuster == null)
            {
                return HttpNotFound();
            }
            return View(adjuster);
        }

        // GET: Adjusters/Create
        public ActionResult Create()
        {
            ViewBag.InsuranceCompanyBranchID = new SelectList(db.InsuranceCompanyBranches, "InsuranceCompanyBranchID", "Description");
            return View();
        }

        // POST: Adjusters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdjusterID,InsuranceCompanyBranchID,FirstName,MiddleName,LastName,Phone,PhoneExtension,CellPhone,OtherPhone,Email,Fax,Code,By,CreatedOrUpdated,Version,Active")] Adjuster adjuster)
        {
            if (ModelState.IsValid)
            {
                db.Adjusters.Add(adjuster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InsuranceCompanyBranchID = new SelectList(db.InsuranceCompanyBranches, "InsuranceCompanyBranchID", "Description", adjuster.InsuranceCompanyBranchID);
            return View(adjuster);
        }

        // GET: Adjusters/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adjuster adjuster = db.Adjusters.Find(id);
            if (adjuster == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsuranceCompanyBranchID = new SelectList(db.InsuranceCompanyBranches, "InsuranceCompanyBranchID", "Description", adjuster.InsuranceCompanyBranchID);
            return View(adjuster);
        }

        // POST: Adjusters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdjusterID,InsuranceCompanyBranchID,FirstName,MiddleName,LastName,Phone,PhoneExtension,CellPhone,OtherPhone,Email,Fax,Code,By,CreatedOrUpdated,Version,Active")] Adjuster adjuster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adjuster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.InsuranceCompanyBranchID = new SelectList(db.InsuranceCompanyBranches, "InsuranceCompanyBranchID", "Description", adjuster.InsuranceCompanyBranchID);
            return View(adjuster);
        }

        // GET: Adjusters/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adjuster adjuster = db.Adjusters.Find(id);
            if (adjuster == null)
            {
                return HttpNotFound();
            }
            return View(adjuster);
        }

        // POST: Adjusters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Adjuster adjuster = db.Adjusters.Find(id);
            db.Adjusters.Remove(adjuster);
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
