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
    public class AppointmentResourceTypeModelsController : Controller
    {
        private AppointmentResourceTypeBO db = new AppointmentResourceTypeBO();

        // GET: AppointmentResourceTypeModels
        public ActionResult Index(int? page)
        {
            var projectedAppointmentResourceTypeList = new List<ICM.Web.Models.AppointmentResourceTypeModels>();
            var realAppointmentResourceTypeList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realAppointmentResourceTypeList, projectedAppointmentResourceTypeList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: AppointmentResourceTypeModels/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var projectedAppointmentResourceType = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(projectedAppointmentResourceType, new Gender());
            if (projectedAppointmentResourceType == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: AppointmentResourceTypeModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentResourceTypeModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentResourceTypeID,Description,Code,OccupationCode,By,CreatedOrUpdated,Version,Active")] AppointmentResourceTypeModels appointmentResourceTypeModels)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(appointmentResourceTypeModels, new Data.AppointmentResourceType());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(appointmentResourceTypeModels);
        }

        // GET: AppointmentResourceTypeModels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceType = ModelAdapter.GetConvertedModel(db.GetByKey(id), new AppointmentResourceTypeModels());

            if (appointmentResourceType == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResourceType);
        }

        // POST: AppointmentResourceTypeModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentResourceTypeID,Description,Code,OccupationCode,By,CreatedOrUpdated,Version,Active")] AppointmentResourceTypeModels appointmentResourceTypeModels)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(appointmentResourceTypeModels, new Data.AppointmentResourceType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(appointmentResourceTypeModels);
        }

        // GET: AppointmentResourceTypeModels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceTypeModels = ModelAdapter.GetConvertedModel(db.GetByKey(id), new AppointmentResourceTypeModels());
            if (appointmentResourceTypeModels == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResourceTypeModels);
        }

        // POST: AppointmentResourceTypeModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var appointmentResourceType = db.GetByKey(id);
            db.Delete(appointmentResourceType);
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
