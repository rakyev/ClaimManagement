﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICM.Web.Models;
using ICM.Data.Business.BusinessObject;
using ICM.Web.Infrastructure;
using PagedList;
using PagedList.Mvc;

namespace ICM.Web.Controllers
{
    public class ActivityTypeController : Controller
    {
        private ActivityTypeBO db = new ActivityTypeBO();

        // GET: /ActivityType/
        public ActionResult Index(int? page)
        {
            var activityTypeList = new List<ActivityType>();
            var realActivityList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realActivityList, activityTypeList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: /ActivityType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var activityType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ActivityType());
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // GET: /ActivityType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ActivityType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ActivityTypeID,ActivitySubTypeID,Description,Code,GoodAndServiceID,By,CreatedOrUpdated,Version,Active")] ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(activityType, new Data.ActivityType());
                db.Add(realModel);
                return RedirectToAction("Index");
            }

            return View(activityType);
        }

        // GET: /ActivityType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var activityType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ActivityType());
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // POST: /ActivityType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ActivityTypeID,ActivitySubTypeID,Description,Code,GoodAndServiceID,By,CreatedOrUpdated,Version,Active")] ActivityType activityType)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(activityType, new Data.ActivityType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(activityType);
        }

        // GET: /ActivityType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var activityType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ActivityType());
            if (activityType == null)
            {
                return HttpNotFound();
            }
            return View(activityType);
        }

        // POST: /ActivityType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var activityType = db.GetByKey(id);
            db.Delete(activityType);
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
