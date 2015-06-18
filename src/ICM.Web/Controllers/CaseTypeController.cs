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
    public class CaseTypeController : Controller
    {
        private CaseTypeBO db = new CaseTypeBO();

        // GET: /CaseType/
        public ActionResult Index(int? page)
        {
            var caseTypeList = new List<CaseType>();
            var realProStateList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realProStateList, caseTypeList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: /CaseType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var casetype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseType());
            if (casetype == null)
            {
                return HttpNotFound();
            }
            return View(casetype);
        }

        // GET: /CaseType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CaseType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CaseTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] CaseType casetype)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(casetype, new Data.CaseType());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(casetype);
        }

        // GET: /CaseType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var casetype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseType());
            if (casetype == null)
            {
                return HttpNotFound();
            }
            return View(casetype);
        }

        // POST: /CaseType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CaseTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] CaseType casetype)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(casetype, new Data.CaseType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(casetype);
        }

        // GET: /CaseType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var casetype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseType());
            if (casetype == null)
            {
                return HttpNotFound();
            }
            return View(casetype);
        }

        // POST: /CaseType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var casetype = db.GetByKey(id);
            db.Delete(casetype);
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
