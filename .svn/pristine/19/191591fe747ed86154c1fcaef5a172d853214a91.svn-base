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
    public class AppointmentResourceNationalHolidayModelsController : Controller
    {
        private AppointmentResourceNationalHolidayBO db = new AppointmentResourceNationalHolidayBO();

        // GET: AppointmentResourceNationalHolidayModels
        public ActionResult Index(int? page)
        {
            var projectedAppointmentResourceNationalHolidayList = new List<ICM.Web.Models.Gender>();
            var realAppointmentResourceNationalHolidayList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realAppointmentResourceNationalHolidayList, projectedAppointmentResourceNationalHolidayList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: AppointmentResourceNationalHolidayModels/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceNationalHoliday = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(appointmentResourceNationalHoliday, new AppointmentResourceNationalHolidayModels());
            if (appointmentResourceNationalHoliday == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: AppointmentResourceNationalHolidayModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentResourceNationalHolidayModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentResourceNationalHolidayID,HolidayDate,Description,Code,By,CreatedOrUpdated,Version,Active")] AppointmentResourceNationalHolidayModels appointmentResourceNationalHolidayModels)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(appointmentResourceNationalHolidayModels, new Data.AppointmentResourceNationalHoliday());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(appointmentResourceNationalHolidayModels);
        }

        // GET: AppointmentResourceNationalHolidayModels/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceNationalHolidayModels = ModelAdapter.GetConvertedModel(db.GetByKey(id), new AppointmentResourceNationalHolidayModels());

            if (appointmentResourceNationalHolidayModels == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResourceNationalHolidayModels);
        }

        // POST: AppointmentResourceNationalHolidayModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentResourceNationalHolidayID,HolidayDate,Description,Code,By,CreatedOrUpdated,Version,Active")] AppointmentResourceNationalHolidayModels appointmentResourceNationalHolidayModels)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(appointmentResourceNationalHolidayModels, new Data.AppointmentResourceNationalHoliday());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(appointmentResourceNationalHolidayModels);
        }

        // GET: AppointmentResourceNationalHolidayModels/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceNationalHolidayModels = ModelAdapter.GetConvertedModel(db.GetByKey(id), new AppointmentResourceNationalHolidayModels());
            if (appointmentResourceNationalHolidayModels == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResourceNationalHolidayModels);
        }

        // POST: AppointmentResourceNationalHolidayModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var appointmentResourceNationalHoliday = db.GetByKey(id);
            db.Delete(appointmentResourceNationalHoliday);
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
