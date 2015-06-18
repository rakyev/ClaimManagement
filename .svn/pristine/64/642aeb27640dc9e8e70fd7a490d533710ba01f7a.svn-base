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
    public class AppointmentResourceChargeOutTypeModelsController : Controller
    {
        private AppointmentResourceChargeOutTypeBO db = new AppointmentResourceChargeOutTypeBO();

        // GET: AppointmentResourceChargeOutTypeModels
        public ActionResult Index(int? page)
        {
            var projectedResourceChargeOutTypeList = new List<ICM.Web.Models.AppointmentResourceChargeOutTypeModels>();
            var realResourceChargeOutTypeList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realResourceChargeOutTypeList, projectedResourceChargeOutTypeList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: AppointmentResourceChargeOutTypeModels/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceChargeOutType = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(appointmentResourceChargeOutType, new AppointmentResourceChargeOutTypeModels());
            if (appointmentResourceChargeOutType == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: AppointmentResourceChargeOutTypeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentResourceChargeOutTypeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentResourceChargeOutTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] AppointmentResourceChargeOutTypeModels appointmentResourceChargeOutTypeModels)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(appointmentResourceChargeOutTypeModels, new Data.AppointmentResourceChargeOutType());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(appointmentResourceChargeOutTypeModels);
        }

        // GET: AppointmentResourceChargeOutTypeModels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceChargeOutTypeModels = ModelAdapter.GetConvertedModel(db.GetByKey(id), new AppointmentResourceChargeOutTypeModels());

            if (appointmentResourceChargeOutTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResourceChargeOutTypeModels);
        }

        // POST: AppointmentResourceChargeOutTypeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentResourceChargeOutTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] AppointmentResourceChargeOutTypeModels appointmentResourceChargeOutTypeModels)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(appointmentResourceChargeOutTypeModels, new Data.AppointmentResourceChargeOutType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(appointmentResourceChargeOutTypeModels);
        }

        // GET: AppointmentResourceChargeOutTypeModels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceChargeOutTypeModels = ModelAdapter.GetConvertedModel(db.GetByKey(id), new AppointmentResourceChargeOutTypeModels());
            if (appointmentResourceChargeOutTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResourceChargeOutTypeModels);
        }

        // POST: AppointmentResourceChargeOutTypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var appointmentResourceChargeOutType = db.GetByKey(id);
            db.Delete(appointmentResourceChargeOutType);
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
