using System;
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
    public class AppointmentResourceBookingTypesController : Controller
    {
        private AppointmentResourceBookingTypeBO db = new AppointmentResourceBookingTypeBO();

        // GET: AppointmentResourceBookingTypes
        public ActionResult Index(int? page)
        {
            var projectedAppointmentResourceBookingList = new List<ICM.Web.Models.AppointmentResourceBookingType>();
            var realResourceBookingList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realResourceBookingList, projectedAppointmentResourceBookingList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: AppointmentResourceBookingTypes/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var resourceBooking = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(resourceBooking, new AppointmentResourceBookingType());
            if (resourceBooking == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: AppointmentResourceBookingTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentResourceBookingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentResourceBookingTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] AppointmentResourceBookingType appointmentResourceBookingType)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(appointmentResourceBookingType, new Data.AppointmentResourceBookingType());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(appointmentResourceBookingType);
        }

        // GET: AppointmentResourceBookingTypes/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceBooking = ModelAdapter.GetConvertedModel(db.GetByKey(id), new Gender());

            if (appointmentResourceBooking == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResourceBooking);
        }

        // POST: AppointmentResourceBookingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentResourceBookingTypeID,Description,Code,By,CreatedOrUpdated,Version,Active")] AppointmentResourceBookingType appointmentResourceBookingType)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(appointmentResourceBookingType, new Data.AppointmentResourceBookingType());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(appointmentResourceBookingType);
        }

        // GET: AppointmentResourceBookingTypes/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var appointmentResourceBooking = ModelAdapter.GetConvertedModel(db.GetByKey(id), new AppointmentResourceBookingType());
            if (appointmentResourceBooking == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResourceBooking);
        }

        // POST: AppointmentResourceBookingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var appointmentResourceBooking = db.GetByKey(id);
            db.Delete(appointmentResourceBooking);
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
