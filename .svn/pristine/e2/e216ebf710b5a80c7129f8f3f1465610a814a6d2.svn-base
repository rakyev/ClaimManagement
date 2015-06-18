using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using ICM.Data;
using ICM.Data.Business.BusinessObject;
using ICM.Web.DashboardBasics;
using ICM.Web.Infrastructure;
using ICM.Web.Models;
using PagedList;

namespace ICM.Web.Controllers
{ 
   // [Authorize]
    public class ActivityBookingController : Controller
    {
        private ActivityBookingBO db = new ActivityBookingBO();

        // GET: ActivityBooking
        public ActionResult Index(int? page)
        {
            var projectedAppointmentBookingList = new List<ActivityBookingModels>();
            var realAppointmentBookingList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realAppointmentBookingList, projectedAppointmentBookingList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: ActivityBooking/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var realModel = db.GetByKey(id);
            ActivityBookingModels activityBookingModels = ModelAdapter.GetConvertedModel(realModel, new ActivityBookingModels());

            if (activityBookingModels == null)
            {
                return HttpNotFound();
            }
            return View(activityBookingModels);
        }

        // GET: ActivityBooking/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetAppointmentResources(), "AppointmentResourceID", "FirstName");
            ViewBag.CaseActivityID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetCaseActivities(), "CaseActivityID", "Description");
            ViewBag.GoodAndServiceID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetGoodAndServices(), "GoodAndServiceID", "Description");
            return View();
        }

        // POST: ActivityBooking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActivityBookingID,CaseActivityID,Description,StartTime,EndTime,AppointmentResourceID,ActivityID,OutlookEntryId,RelatedEntryId,GoodAndServiceID,By,CreatedOrUpdated,Version,Active")] ActivityBookingModels activityBookingModels)
        {

            if (ModelState.IsValid)
            {
                var acitivityBookingRealModel = ModelAdapter.GetConvertedModel(activityBookingModels, new ActivityBooking());
                db.Add(acitivityBookingRealModel);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetAppointmentResources(), "AppointmentResourceID", "FirstName", activityBookingModels.AppointmentResourceID);
            ViewBag.CaseActivityID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetCaseActivities(), "CaseActivityID", "Description", activityBookingModels.CaseActivityID);
            ViewBag.GoodAndServiceID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetGoodAndServices(), "GoodAndServiceID", "Description", activityBookingModels.GoodAndServiceID);
            return View(activityBookingModels);
        }

        // GET: ActivityBooking/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var activityBookingModels = db.GetByKey(id);

            if (activityBookingModels == null)
            {
                return HttpNotFound();
            }
            ActivityBookingModels projectionModel = ModelAdapter.GetConvertedModel(activityBookingModels, new ActivityBookingModels());
            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetAppointmentResources(), "AppointmentResourceID", "FirstName", activityBookingModels.AppointmentResourceID);
            ViewBag.CaseActivityID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetCaseActivities(), "CaseActivityID", "Description", activityBookingModels.CaseActivityID);
            ViewBag.GoodAndServiceID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetGoodAndServices(), "GoodAndServiceID", "Description", activityBookingModels.GoodAndServiceID);
            return View(projectionModel);
        }

        // POST: ActivityBooking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActivityBookingID,CaseActivityID,Description,StartTime,EndTime,AppointmentResourceID,ActivityID,OutlookEntryId,RelatedEntryId,GoodAndServiceID,By,CreatedOrUpdated,Version,Active")] ActivityBookingModels activityBookingModels)
        {
            if (ModelState.IsValid)
            {
                var realActivityBooking = ModelAdapter.GetConvertedModel(activityBookingModels, new ActivityBooking());
                db.Update(realActivityBooking);
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetAppointmentResources(), "AppointmentResourceID", "FirstName", activityBookingModels.AppointmentResourceID);
            ViewBag.CaseActivityID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetCaseActivities(), "CaseActivityID", "Description", activityBookingModels.CaseActivityID);
            ViewBag.GoodAndServiceID = new SelectList(ForeignKeysModelProxy.GetActivityBookingsForeignKeysInstance().GetGoodAndServices(), "GoodAndServiceID", "Description", activityBookingModels.GoodAndServiceID);
            return View(activityBookingModels);
        }

        // GET: ActivityBooking/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var realActivityBooking = db.GetByKey(id);
            ActivityBookingModels activityBookingModels = ModelAdapter.GetConvertedModel(realActivityBooking, new ActivityBookingModels());

            if (activityBookingModels == null)
            {
                return HttpNotFound();
            }
            return View(activityBookingModels);
        }

        // POST: ActivityBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var activityBookingModels = db.GetByKey(id);
            db.Delete(activityBookingModels);
            db.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Search(String description)
        //{
        //    if (description == null || description.Equals(""))
        //    {
        //        return View();
        //    }
        //    var list = db.GetDoctorsSearched(description);
        //    var projection = ModelAdapter.GetConvertedModelList(list, new List<DoctorsAppointment>());

        //    return View(projection);
        //}

        public PartialViewResult SearchPeople(string keyword)
        {
            var result = new List<DoctorsAppointment>();
            if (keyword == null || keyword.Equals(""))
            {
                return PartialView(result);
            }

            var data = db.GetAppointmentSearched(keyword);
            result = ModelAdapter.GetConvertedModelList(data, result);

            return PartialView(result);
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
