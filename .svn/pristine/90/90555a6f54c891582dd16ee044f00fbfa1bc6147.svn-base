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

namespace ICM.Web.Controllers
{
    public class CaseContactSpecialitiesController : Controller
    {
        private CaseContactSpecialityBO db = new CaseContactSpecialityBO();

        // GET: CaseContactSpecialities
        public ActionResult Index(int? page)
        {
            var projectedContactSpeciality = new List<CaseContactSpeciality>();
            var realSpecialityList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realSpecialityList, projectedContactSpeciality);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: CaseContactSpecialities/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseContactSpeciality = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(caseContactSpeciality, new CaseContactSpeciality());
            if (caseContactSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: CaseContactSpecialities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseContactSpecialities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseContactSpecialityID,Description,Code,By,CreatedOrUpdated,Version,Active")] CaseContactSpeciality caseContactSpeciality)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(caseContactSpeciality, new Data.CaseContactSpeciality());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(caseContactSpeciality);
        }

        // GET: CaseContactSpecialities/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseContactSpeciality = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseContactSpeciality());

            if (caseContactSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(caseContactSpeciality);
        }

        // POST: CaseContactSpecialities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseContactSpecialityID,Description,Code,By,CreatedOrUpdated,Version,Active")] CaseContactSpeciality caseContactSpeciality)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(caseContactSpeciality, new Data.CaseContactSpeciality());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(caseContactSpeciality);
        }

        // GET: CaseContactSpecialities/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseContactSpeciality = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseContactSpeciality());
            if (caseContactSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(caseContactSpeciality);
        }

        // POST: CaseContactSpecialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var caseContactSpeciality = db.GetByKey(id);
            db.Delete(caseContactSpeciality);
            db.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
