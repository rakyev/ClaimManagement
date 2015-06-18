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
    public class MeasureController : Controller
    {
        private MeasureBO db = new MeasureBO();

        // GET: /Measure/
        public ActionResult Index(int? page)
        {
            var measureList = new List<Measure>();
            var realProStateList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realProStateList, measureList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: /Measure/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var measure = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Measure());
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // GET: /Measure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Measure/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="MeasureID,Description,Code,By,CreatedOrUpdated,Version,Active")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(measure, new Data.Measure());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(measure);
        }

        // GET: /Measure/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var measure = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Measure());
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: /Measure/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="MeasureID,Description,Code,By,CreatedOrUpdated,Version,Active")] Measure measure)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(measure, new Data.Measure());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(measure);
        }

        // GET: /Measure/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var measure = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Measure());
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: /Measure/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var measure = db.GetByKey(id);
            db.Delete(measure);
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
