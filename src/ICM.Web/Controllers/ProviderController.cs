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
    public class ProviderController : Controller
    {
        //[Authorize]
        // GET: Provider
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Create()
        {
            long caseid = Convert.ToInt64(TempData["caseid"]);
            ViewBag.ProviderCaseID = caseid;
            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "FirstName");
            return View();
        }

        // POST: ClientModelTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseProviderID,CaseID,AppointmentResourceID,By,CreatedOrUpdated,Version,Active")] ICM.Web.Models.CaseProvider provider)
        {
            long caseid = Convert.ToInt64(TempData["caseID"]);
            provider.CaseID = caseid;

            if (ModelState.IsValid)
            {
                CaseProviderBO bo = new CaseProviderBO();
                var prov = ModelAdapter.GetConvertedModel(provider, new ICM.Data.CaseProvider());
                bo.Add(prov);
                bo.Save();
                return RedirectToAction("Edit", "ClientCase", new { id = provider.CaseID });
            }

            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "FirstName", provider.AppointmentResourceID);
            return View(provider);
        }
        public ActionResult ModifyCaseProvider(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseProviderBO bo = new CaseProviderBO();
            var ac = bo.GetByKey(id);
            var activityModels = ModelAdapter.GetConvertedModel(ac, new ICM.Web.Models.CaseProvider());

            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "FirstName", activityModels.AppointmentResourceID);
            return View(activityModels);
        }

        [HttpPost]
        public ActionResult ModifyCaseProvider([Bind(Include = "CaseProviderID,CaseID,AppointmentResourceID,By,CreatedOrUpdated,Version,Active")] ICM.Web.Models.CaseProvider clientCaseClientModels)
        {

            if (ModelState.IsValid)
            {
                CaseProviderBO no = new CaseProviderBO();
                var test = ModelAdapter.GetConvertedModel(clientCaseClientModels, new ICM.Data.CaseProvider());
                no.Update(test);
                return RedirectToAction("Edit", "ClientCase", new { id = clientCaseClientModels.CaseID });
            }

            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "FirstName", clientCaseClientModels.AppointmentResourceID);
            return View(clientCaseClientModels);
        }

        public ActionResult ProviderDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseProviderBO bo = new CaseProviderBO();
            var test = bo.GetByKey(id);
            var caseModels = ModelAdapter.GetConvertedModel(test, new ICM.Web.Models.CaseProvider());
            return View(caseModels);
        }
    }
}