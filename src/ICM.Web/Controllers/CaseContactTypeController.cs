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
    public class CaseContactTypeController : Controller
    {
        private CaseContactTypeBO db = new CaseContactTypeBO();

        // GET: /CaseContactType/
        public ActionResult Index(int? page)
        {
            var caseContactTypeList = new List<CaseContactType>();
            var realProStateList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realProStateList, caseContactTypeList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: /CaseContactType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var caseContactType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseContactType());
            if (caseContactType == null)
            {
                return HttpNotFound();
            }
            return View(caseContactType);
        }

        // GET: /CaseContactType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CaseContactType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CaseContactTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] CaseContactType casecontacttype)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(casecontacttype, new Data.CaseContactType());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(casecontacttype);
        }

        // GET: /CaseContactType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var casecontacttype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseContactType());
            if (casecontacttype == null)
            {
                return HttpNotFound();
            }
            return View(casecontacttype);
        }

        // POST: /CaseContactType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CaseContactTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] CaseContactType casecontacttype)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(casecontacttype, new Data.CaseContactType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(casecontacttype);
        }

        // GET: /CaseContactType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var casecontacttype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new CaseContactType());
            if (casecontacttype == null)
            {
                return HttpNotFound();
            }
            return View(casecontacttype);
        }

        // POST: /CaseContactType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var casecontacttype = db.GetByKey(id);
            db.Delete(casecontacttype);
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
