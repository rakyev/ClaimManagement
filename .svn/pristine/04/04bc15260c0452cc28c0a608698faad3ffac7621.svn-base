using ICM.Data.Business.BusinessObject;
using ICM.Web.DashboardBasics;
using ICM.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ICM.Web.Controllers
{
    //Authorize]
    public class InjuryController : Controller
    {
        // GET: Injury
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult InjuryDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseInjuryBO bo = new CaseInjuryBO();
            var test = bo.GetByKey(id);
            var caseModels = ModelAdapter.GetConvertedModel(test, new ICM.Web.Models.CaseInjury());
            return View(caseModels);
        }

        public ActionResult Create()
        {
            long caseid = Convert.ToInt64(TempData["caseid"]);
            ViewBag.InjuryCaseID = caseid;

            ViewBag.InjuryCodeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetInjuries(), "InjuryCodeID", "Description");
            return View();
        }

        // POST: ClientModelTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseInjuryID,CaseID,InjuryCodeID,Description,Code,By,CreatedOrUpdated,Version,Active")] ICM.Web.Models.CaseInjury injury)
        {
            long caseid = Convert.ToInt64(TempData["caseID"]);
            injury.CaseID = caseid;

            if (ModelState.IsValid)
            {
                CaseInjuryBO bo = new CaseInjuryBO();
                var inj = ModelAdapter.GetConvertedModel(injury, new ICM.Data.CaseInjury());
                bo.Add(inj);
                bo.Save();
                return RedirectToAction("Edit", "ClientCase", new { id = injury.CaseID });
            }

            ViewBag.InjuryCodeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetInjuries(), "InjuryCodeID", "Description", injury.InjuryCodeID);
            return View(injury);
        }

        public ActionResult ModifyCaseInjury(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseInjuryBO bo = new CaseInjuryBO();
            var ac = bo.GetByKey(id);
            var activityModels = ModelAdapter.GetConvertedModel(ac, new ICM.Web.Models.CaseInjury());
            ViewBag.InjuryCodeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetInjuries(), "InjuryCodeID", "Description", activityModels.InjuryCodeID);
            return View(activityModels);
        }

        [HttpPost]
        public ActionResult ModifyCaseInjury([Bind(Include = "CaseInjuryID,CaseID,InjuryCodeID,Description,Code,By,CreatedOrUpdated,Version,Active")] ICM.Web.Models.CaseInjury clientCaseClientModels)
        {

            if (ModelState.IsValid)
            {
                CaseInjuryBO bo = new CaseInjuryBO();
                var test = ModelAdapter.GetConvertedModel(clientCaseClientModels, new ICM.Data.CaseInjury());
                bo.Update(test);
                return RedirectToAction("Edit", "ClientCase", new { id = clientCaseClientModels.CaseID });
            }

            ViewBag.InjuryCodeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetInjuries(), "InjuryCodeID", "Description", clientCaseClientModels.InjuryCodeID);
            return View(clientCaseClientModels);
        }
    }
}