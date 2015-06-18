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
    public class ActivitySubTypeController : Controller
    {
        private ActivitySubTypeBO db = new ActivitySubTypeBO();

        // GET: /ActivitySubType/
        public ActionResult Index(int? page)
        {
            var activitySubTypeList = new List<ActivitySubType>();
            var realProStateList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realProStateList, activitySubTypeList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: /ActivitySubType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var activitysubtype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ActivitySubType());
            if (activitysubtype == null)
            {
                return HttpNotFound();
            }
            return View(activitysubtype);
        }

        // GET: /ActivitySubType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ActivitySubType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ActivitySubTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] ActivitySubType activitysubtype)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(activitysubtype, new Data.ActivitySubType());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(activitysubtype);
        }

        // GET: /ActivitySubType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var activitysubtype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ActivitySubType());
            if (activitysubtype == null)
            {
                return HttpNotFound();
            }
            return View(activitysubtype);
        }

        // POST: /ActivitySubType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ActivitySubTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] ActivitySubType activitysubtype)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(activitysubtype, new Data.ActivitySubType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(activitysubtype);
        }

        // GET: /ActivitySubType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var activitysubtype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ActivitySubType());
            if (activitysubtype == null)
            {
                return HttpNotFound();
            }
            return View(activitysubtype);
        }

        // POST: /ActivitySubType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var activitysubtype = db.GetByKey(id);
            db.Delete(activitysubtype);
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
