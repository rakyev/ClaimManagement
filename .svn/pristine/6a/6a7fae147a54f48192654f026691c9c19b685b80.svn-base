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
    public class MaritalStatesController : Controller
    {
        private MaritalStateBO db = new MaritalStateBO();

        // GET: MaritalStates
        public ActionResult Index(int? page)
        {
            var projectedMaritalStateList = new List<MaritalState>();
            var realMaritalStateList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realMaritalStateList, projectedMaritalStateList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: MaritalStates/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maritalState = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(maritalState, new MaritalState());
            if (maritalState == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: MaritalStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaritalStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaritalStatusID,Description,Code,By,CreatedOrUpdated,Version,Active")] MaritalState maritalState)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(maritalState, new Data.MaritalState());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(maritalState);
        }

        // GET: MaritalStates/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maritalSate = ModelAdapter.GetConvertedModel(db.GetByKey(id), new MaritalState());

            if (maritalSate == null)
            {
                return HttpNotFound();
            }
            return View(maritalSate);
        }

        // POST: MaritalStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaritalStatusID,Description,Code,By,CreatedOrUpdated,Version,Active")] MaritalState maritalState)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(maritalState, new Data.MaritalState());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(maritalState);
        }

        // GET: MaritalStates/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var maritalState = ModelAdapter.GetConvertedModel(db.GetByKey(id), new MaritalState());
            if (maritalState == null)
            {
                return HttpNotFound();
            }
            return View(maritalState);
        }

        // POST: MaritalStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var maritalState = db.GetByKey(id);
            db.Delete(maritalState);
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
