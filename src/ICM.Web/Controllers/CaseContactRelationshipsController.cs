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
    public class CaseContactRelationshipsController : Controller
    {
        private CaseContactRelationshipBO db = new CaseContactRelationshipBO();

        // GET: CaseContactRelationships
        public ActionResult Index(int? page)
        {
            var projectedCaseRelationshipList = new List<CaseContactRelationship>();
            var realCaseRelationshipList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realCaseRelationshipList, projectedCaseRelationshipList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: CaseContactRelationships/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseRelationship = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(caseRelationship, new CaseContactRelationship());
            if (caseRelationship == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: CaseContactRelationships/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseContactRelationships/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseContactRelationshipID,Description,Code,By,CreatedOrUpdated,Version,Active")] CaseContactRelationship caseContactRelationship)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(caseContactRelationship, new Data.CaseContactRelationship());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(caseContactRelationship);
        }

        // GET: CaseContactRelationships/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseContactRelationship = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseContactRelationship());

            if (caseContactRelationship == null)
            {
                return HttpNotFound();
            }
            return View(caseContactRelationship);
        }

        // POST: CaseContactRelationships/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseContactRelationshipID,Description,Code,By,CreatedOrUpdated,Version,Active")] CaseContactRelationship caseContactRelationship)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(caseContactRelationship, new Data.CaseContactRelationship());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(caseContactRelationship);
        }

        // GET: CaseContactRelationships/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseContactRelationship = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseContactRelationship());
            if (caseContactRelationship == null)
            {
                return HttpNotFound();
            }
            return View(caseContactRelationship);
        }

        // POST: CaseContactRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var caseContactRelationship = db.GetByKey(id);
            db.Delete(caseContactRelationship);
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

        public ActionResult Search()
        {
            return View();
        }

        public PartialViewResult SearchContactRelationship(string keyword)
        {
            var result = new List<CaseContactRelationship>();
            if (keyword == null || keyword.Equals(""))
            {
                return PartialView(result);
            }

            var data = db.GetRelationshipsSearched(keyword);
            result = ModelAdapter.GetConvertedModelList(data, result);

            return PartialView(result);
        }
    }
}
