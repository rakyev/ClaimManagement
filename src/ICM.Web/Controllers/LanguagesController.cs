﻿using System;
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
    public class LanguagesController : Controller
    {
        private LanguageBO db = new LanguageBO();

        // GET: Languages
        public ActionResult Index(int? page)
        {
            var projectedLanguageList = new List<Language>();
            var realLanguageList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realLanguageList, projectedLanguageList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Languages/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var language = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(language, new Language());
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Languages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageID,Description,Code,By,CreatedOrUpdated,Version,Active")] Language language)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(language, new Data.Language());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(language);
        }

        // GET: Languages/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var language = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Language());

            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageID,Description,Code,By,CreatedOrUpdated,Version,Active")] Language language)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(language, new Data.Language());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(language);
        }

        // GET: Languages/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var language = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Language());
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var language = db.GetByKey(id);
            db.Delete(language);
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
