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
    //[Authorize]
    public class BenefitsController : Controller
    {
        // GET: Benefits
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BenefitDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseBenefitBO bo = new CaseBenefitBO();
            var test = bo.GetByKey(id);
            var caseModels = ModelAdapter.GetConvertedModel(test, new ICM.Web.Models.CaseBenefit());
            return View(caseModels);
        }

        public ActionResult Create()
        {
            long caseid = Convert.ToInt64(TempData["caseid"]);
            ViewBag.BenefitCaseID = caseid;

            ViewBag.BenefitTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetBenefits(), "BenefitTypeID", "Description");

            return View();
        }

        // POST: ClientModelTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseBenefitID,CaseID,BenefitTypeID,Description,By,CreatedOrUpdated,Version,Active")] ICM.Web.Models.CaseBenefit benefit)
        {
            long caseid = Convert.ToInt64(TempData["caseID"]);
            benefit.CaseID = caseid;

            if (ModelState.IsValid)
            {
                CaseBenefitBO bo = new CaseBenefitBO();
                var ben = ModelAdapter.GetConvertedModel(benefit, new ICM.Data.CaseBenefit());
                bo.Add(ben);
                bo.Save();
                return RedirectToAction("Edit", "ClientCase", new { id = benefit.CaseID });
            }
            ViewBag.BenefitTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetBenefits(), "BenefitTypeID", "Description", benefit.BenefitTypeID);

            return View(benefit);
        }
        public ActionResult ModifyCaseBenefit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseBenefitBO bo = new CaseBenefitBO();
            var ac = bo.GetByKey(id);
            var activityModels = ModelAdapter.GetConvertedModel(ac, new ICM.Web.Models.CaseBenefit());
            ViewBag.BenefitTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetBenefits(), "BenefitTypeID", "Description", activityModels.BenefitTypeID);
            return View(activityModels);
        }

        [HttpPost]
        public ActionResult ModifyCaseBenefit([Bind(Include = "CaseBenefitID,CaseID,BenefitTypeID,Description,By,CreatedOrUpdated,Version,Active")] ICM.Web.Models.CaseBenefit clientCaseClientModels)
        {

            if (ModelState.IsValid)
            {
                CaseBenefitBO bo = new CaseBenefitBO();
                var test = ModelAdapter.GetConvertedModel(clientCaseClientModels, new ICM.Data.CaseBenefit());
                bo.Update(test);
                return RedirectToAction("Edit", "ClientCase", new { id = clientCaseClientModels.CaseID });
            }

            ViewBag.BenefitTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetBenefits(), "BenefitTypeID", "Description", clientCaseClientModels.BenefitTypeID);
            return View(clientCaseClientModels);
        }
    }
}