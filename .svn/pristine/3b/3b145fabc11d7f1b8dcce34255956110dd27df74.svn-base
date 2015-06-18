using System;
using System.Net;
using System.Web.Mvc;
using ICM.Data;
using ICM.Data.Business.BusinessObject;
using ICM.Web.DashboardBasics;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.Controllers
{
   // [Authorize]
    public class ActivityController : Controller
    {
        // GET: Activity
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ActivityDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseActivityBO bo = new CaseActivityBO();
            var test = bo.GetByKey(id);
            var caseModels = ModelAdapter.GetConvertedModel(test, new CaseActivityModels());
            return View(caseModels);

        }

        public ActionResult Create()
        {
            long caseid = Convert.ToInt64(TempData["caseid"]);
            ViewBag.ActivityCaseID = caseid;
            ViewBag.ActivityTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetActivities(), "ActivityTypeID", "Description");
            return View();
        }

        // POST: ClientModelTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseActivityID,ActivityTypeID,CaseID,Description,Completed,By,CreatedOrUpdated,Version,Active")] CaseActivityModels activity)
        {
            long caseid = Convert.ToInt64(TempData["caseID"]);
            activity.CaseID = caseid;

            if (ModelState.IsValid)
            {
                CaseActivityBO bo = new CaseActivityBO();
                var caseactivities = ModelAdapter.GetConvertedModel(activity, new CaseActivity());
                bo.Add(caseactivities);
                bo.Save();
                return RedirectToAction("Edit", "ClientCase", new { id = activity.CaseID });
            }
            ViewBag.ActivityTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetActivities(), "ActivityTypeID", "Description", activity.ActivityTypeID);
            return View(activity);
        }
        public ActionResult ModifyCaseActivity(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseActivityBO bo = new CaseActivityBO();
            var ac = bo.GetByKey(id);
            var activityModels = ModelAdapter.GetConvertedModel(ac, new CaseActivityModels());
            ViewBag.ActivityTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetActivities(), "ActivityTypeID", "Description", activityModels.ActivityTypeID);
            return View(activityModels);
        }

        [HttpPost]
        public ActionResult ModifyCaseActivity([Bind(Include = "CaseActivityID,ActivityTypeID,CaseID,Description,Completed,By,CreatedOrUpdated,Version,Active")] CaseActivityModels clientCaseClientModels)
        {

            if (ModelState.IsValid)
            {
                CaseActivityBO bo = new CaseActivityBO();
                var test = ModelAdapter.GetConvertedModel(clientCaseClientModels, new CaseActivity());
                bo.Update(test);
                return RedirectToAction("Edit", "ClientCase", new { id = clientCaseClientModels.CaseID });
            }

            ViewBag.ActivityTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetActivities(), "ActivityTypeID", "Description", clientCaseClientModels.ActivityTypeID);
            return View(clientCaseClientModels);
        }
    }
}