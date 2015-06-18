using System;
using System.Net;
using System.Web.Mvc;
using ICM.Data.Business.BusinessObject;
using ICM.Web.DashboardBasics;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.Controllers
{
   // [Authorize]
    public class MVAController : Controller
    {
        // GET: MVA
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MVADetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseMvaBO bo = new CaseMvaBO();
            var test = bo.GetByKey(id);
            var caseModels = ModelAdapter.GetConvertedModel(test, new CaseMVA());
            return View(caseModels);
        }

        public ActionResult Create()
        {
            long caseid = Convert.ToInt64(TempData["caseid"]);
            ViewBag.MVACaseID = caseid;
            ViewBag.LanguageID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetLanguages(), "LanguageID", "Description");
            ViewBag.AdjusterID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetAdjusters(), "AdjusterID", "Email");


            return View();
        }

        // POST: ClientModelTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include =
                    "CaseMVAID,CaseID,DateofAccident,ClaimNumber,PolicyNumber,AdjusterID,CAT,TransportationRequired, InterpreterRequired, LanguageID, PolicyHolderSameAsApplicant, PolicyHolderFirstName, PolicyHolderLastName," +
                    " IsThereOtherInsuranceCoverage, Closed, ClosedDate, OtherInsurer1Name, OtherInsurer1Plan, OtherInsurer1PolicyNumber, OtherInsurer1NameofThePlanMember, OtherInsurer1Identifier, OtherInsurer2Name, " +
                    "OtherInsurer2Plan, OtherInsurer2PolicyNumber, OtherInsurer2NameofThePlanMember, OtherInsurer2Identifier,By,CreatedOrUpdated,Version,Active")] CaseMVA mva)
        {
            long caseid = Convert.ToInt64(TempData["caseID"]);
            mva.CaseID = caseid;

            if (ModelState.IsValid)
            {
                CaseMvaBO bo = new CaseMvaBO();
                var casemva = ModelAdapter.GetConvertedModel(mva, new Data.CaseMVA());
                bo.Add(casemva);
                bo.Save();
                return RedirectToAction("Edit", "ClientCase", new { id = mva.CaseID });
            }

            ViewBag.LanguageID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetLanguages(), "LanguageID", "Description", mva.LanguageID);
            ViewBag.AdjusterID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetAdjusters(), "AdjusterID", "Email", mva.AdjusterID);

            return View(mva);
        }
        public ActionResult ModifyCaseMVA(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseMvaBO bo = new CaseMvaBO();
            var ac = bo.GetByKey(id);
            var activityModels = ModelAdapter.GetConvertedModel(ac, new CaseMVA());
            ViewBag.LanguageID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetLanguages(), "LanguageID", "Description", activityModels.LanguageID);
            ViewBag.AdjusterID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetAdjusters(), "AdjusterID", "Email", activityModels.AdjusterID);

            return View(activityModels);

        }

        [HttpPost]
        public ActionResult ModifyCaseMVA(
            [Bind(
                Include =
                    "CaseMVAID,CaseID,DateofAccident,ClaimNumber,PolicyNumber,AdjusterID,CAT,TransportationRequired, InterpreterRequired, LanguageID, PolicyHolderSameAsApplicant, PolicyHolderFirstName, PolicyHolderLastName," +
                    " IsThereOtherInsuranceCoverage, Closed, ClosedDate, OtherInsurer1Name, OtherInsurer1Plan, OtherInsurer1PolicyNumber, OtherInsurer1NameofThePlanMember, OtherInsurer1Identifier, OtherInsurer2Name, " +
                    "OtherInsurer2Plan, OtherInsurer2PolicyNumber, OtherInsurer2NameofThePlanMember, OtherInsurer2Identifier,By,CreatedOrUpdated,Version,Active")] CaseMVA clientCaseClientModels)
        {
            if (ModelState.IsValid)
            {
                CaseMvaBO bo = new CaseMvaBO();
                var test = ModelAdapter.GetConvertedModel(clientCaseClientModels, new Data.CaseMVA());
                bo.Update(test);
                return RedirectToAction("Edit", "ClientCase", new { id = clientCaseClientModels.CaseID });
            }

            ViewBag.LanguageID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetLanguages(), "LanguageID", "Description", clientCaseClientModels.LanguageID);
            ViewBag.AdjusterID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetAdjusters(), "AdjusterID", "Email", clientCaseClientModels.AdjusterID);

            return View(clientCaseClientModels);

        }
    }
}