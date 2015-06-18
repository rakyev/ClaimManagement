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
    public class PaymentTypesController : Controller
    {
        private PaymentTypeBO db = new PaymentTypeBO();

        // GET: PaymentTypes
        public ActionResult Index(int? page)
        {
            var paymentTypeList = new List<PaymentType>();
            var realProStateList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realProStateList, paymentTypeList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: PaymentTypes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new PaymentType());
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // GET: PaymentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(paymentType, new Data.PaymentType());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(paymentType);
        }

        // GET: PaymentTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new PaymentType());
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // POST: PaymentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] PaymentType paymentType)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(paymentType, new Data.PaymentType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(paymentType);
        }

        // GET: PaymentTypes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var paymentType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new PaymentType());
            if (paymentType == null)
            {
                return HttpNotFound();
            }
            return View(paymentType);
        }

        // POST: PaymentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var paymentType = db.GetByKey(id);
            db.Delete(paymentType);
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
