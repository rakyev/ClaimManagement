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
    public class BenefitTypeController : Controller
    {
        private BenefitTypeBO db = new BenefitTypeBO();

        // GET: /BenefitType/
        public ActionResult Index(int? page)
        {
            var benefitTypeList = new List<BenefitType>();
            var realProStateList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realProStateList, benefitTypeList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: /BenefitType/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var benefittype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new BenefitType());
            if (benefittype == null)
            {
                return HttpNotFound();
            }
            return View(benefittype);
        }

        // GET: /BenefitType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /BenefitType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BenefitTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] BenefitType benefittype)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(benefittype, new Data.BenefitType());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(benefittype);
        }

        // GET: /BenefitType/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var benefitType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new BenefitType());
            if (benefitType == null)
            {
                return HttpNotFound();
            }
            return View(benefitType);
        }

        // POST: /BenefitType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BenefitTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] BenefitType benefittype)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(benefittype, new Data.BenefitType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(benefittype);
        }

        // GET: /BenefitType/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var benefittype = ModelAdapter.GetConvertedModel(db.GetByKey(id), new BenefitType());
            if (benefittype == null)
            {
                return HttpNotFound();
            }
            return View(benefittype);
        }

        // POST: /BenefitType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var benefittype = db.GetByKey(id);
            db.Delete(benefittype);
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
