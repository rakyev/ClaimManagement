using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using ICM.Web.Models;
using PagedList;
using ICM.Web.DashboardBasics;

namespace ICM.Web.Controllers
{
    public class AdjusterController : Controller
    {
        private AdjusterBO db = new AdjusterBO();

        // GET: /Adjuster/
        public ActionResult Index(int? page)
        {
            var adjusterList = new List<Adjuster>();
            var realAdjuster = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realAdjuster, adjusterList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Adjuster/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adjuster = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Adjuster());
            if (adjuster == null)
            {
                return HttpNotFound();
            }
            return View(adjuster);
        }

        // GET: /Adjuster/Create
        public ActionResult Create()
        {
            ViewBag.InsuranceCompanyBranchID = new SelectList(new ForeignKeysForAdjusterModel().GetInsuranceCompanyBranch(), "InsuranceCompanyBranchID", "Description");
            return View();
        }

        // POST: /Adjuster/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="AdjusterID,InsuranceCompanyBranchID,FirstName,MiddleName,LastName,Phone,PhoneExtension,CellPhone,OtherPhone,Email,Fax,Code,By,CreatedOrUpdated,Version,Active")] Adjuster adjuster)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(adjuster, new Data.Adjuster());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.InsuranceCompanyBranchID = new SelectList(new ForeignKeysForAdjusterModel().GetInsuranceCompanyBranch(), "InsuranceCompanyBranchID", "Description");
            return View(adjuster);
        }

        // GET: /Adjuster/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adjuster = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Adjuster());
            if (adjuster == null)
            {
                return HttpNotFound();
            }
            ViewBag.InsuranceCompanyBranchID = new SelectList(new ForeignKeysForAdjusterModel().GetInsuranceCompanyBranch(), "InsuranceCompanyBranchID", "Description");
            return View(adjuster);
        }

        // POST: /Adjuster/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="AdjusterID,InsuranceCompanyBranchID,FirstName,MiddleName,LastName,Phone,PhoneExtension,CellPhone,OtherPhone,Email,Fax,Code,By,CreatedOrUpdated,Version,Active")] Adjuster adjuster)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(adjuster, new Data.Adjuster());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            ViewBag.InsuranceCompanyBranchID = new SelectList(new ForeignKeysForAdjusterModel().GetInsuranceCompanyBranch(), "InsuranceCompanyBranchID", "Description");
            return View(adjuster);
        }

        // GET: /Adjuster/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var adjuster = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Adjuster());
            if (adjuster == null)
            {
                return HttpNotFound();
            }
            return View(adjuster);
        }

        // POST: /Adjuster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var adjuster = db.GetByKey(id);
            db.Delete(adjuster);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
