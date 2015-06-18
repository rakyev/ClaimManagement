using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ICM.Data;
using ICM.Data.Business.BusinessObject;
using ICM.Web.DashboardBasics;
using ICM.Web.Infrastructure;
using ICM.Web.Models;
using Newtonsoft.Json;
using PagedList;
using CaseBenefit = ICM.Web.Models.CaseBenefit;
using CaseContact = ICM.Web.Models.CaseContact;
using CaseInjury = ICM.Web.Models.CaseInjury;
using CaseManagement = ICM.Web.Models.CaseManagement;
using CaseMVA = ICM.Web.Models.CaseMVA;
using CaseNote = ICM.Web.Models.CaseNote;
using CaseProvider = ICM.Web.Models.CaseProvider;

namespace ICM.Web.Controllers
{
    //[Authorize]
    public class ClientCaseController : Controller
    {
        private ClientCaseBO db = new ClientCaseBO();
        // GET: ClientCase
        public ActionResult Index(int? page)
        {

            dynamic list = db.GetAllClientandCases();
            List<ClientCaseClientModels> objList = JsonConvert.DeserializeObject<List<ClientCaseClientModels>>(list);
            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable
            return View(objList.ToPagedList(pageNumber, pageSize));
        }

        // GET: ClientCase/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View();
        }

        // GET: ClientCase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientCase/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseID,CaseTypeID,Description,FirstName,LastName,DateofBirth,PostalCodeOrZipCode,By")] ClientCaseClientModels clientCaseClientModels)
        {
            //if (ModelState.IsValid)
            //{
            //    db.ClientCaseClientModels.Add(clientCaseClientModels);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            return View(clientCaseClientModels);
        }

        // GET: ClientCase/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            var test = db.GetByKey(id);
            TempData["caseId"] = id;

            var clientcaseModels = ModelAdapter.GetConvertedModel(test, new ClientCaseModels());

            CaseActivityBO bo = new CaseActivityBO();
            CaseContactBO cc = new CaseContactBO();
            CaseProviderBO cp = new CaseProviderBO();
            CaseBenefitBO cb = new CaseBenefitBO();
            CaseInjuryBO ci = new CaseInjuryBO();
            CaseMvaBO mv = new CaseMvaBO();
            CaseManagementBO manage = new CaseManagementBO();
            CaseNoteBO notes = new CaseNoteBO();
            CaseProviderBO prov = new CaseProviderBO();


            var act = bo.GetCaseActivitybyCaseId(id);
            var con = cc.GetCaseContactbyCaseId(id);
            var ben = cb.GetCaseBenefitByCaseId(id);
            var caseInjury = ci.GetCaseInjuryByCaseId(id);
            var mva = mv.GetCaseMVAByCaseId(id);
            var man = manage.GetCaseManagementByCaseId(id);
            var note = notes.GetCaseNoteByCaseId(id);
            var provider = prov.GetCaseProviderByCaseId(id);
            var cl = db.GetClientbyCaseId(id);

            ViewBag.Client = ModelAdapter.GetConvertedModelList(cl, new List<ProjectionClient>());
            ViewBag.CaseActivity = ModelAdapter.GetConvertedModelList(act, new List<CaseActivityModels>());
            ViewBag.CaseContact = ModelAdapter.GetConvertedModelList(con, new List<CaseContact>());
            ViewBag.CaseBenefit = ModelAdapter.GetConvertedModelList(ben, new List<CaseBenefit>());
            ViewBag.CaseInjury = ModelAdapter.GetConvertedModelList(caseInjury, new List<CaseInjury>());
            ViewBag.CaseMVA = ModelAdapter.GetConvertedModelList(mva, new List<CaseMVA>());
            ViewBag.CaseManagement = ModelAdapter.GetConvertedModelList(man, new List<CaseManagement>());
            ViewBag.CaseNote = ModelAdapter.GetConvertedModelList(note, new List<CaseNote>());
            ViewBag.CaseProvider = ModelAdapter.GetConvertedModelList(provider, new List<CaseProvider>());
            ViewBag.CaseTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetCaseTypes(), "CaseTypeID", "Description", clientcaseModels.CaseTypeID);
            ViewBag.CoordinatorUserID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetUsers(), "UserID", "UserFullName", clientcaseModels.CoordinatorUserID);

            return View(clientcaseModels);


        }

        // POST: ClientCase/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseID,CaseTypeID,ClientID,Description,ReferralDate,CoordinatorUserID,CreatedOrUpdated,Version,Active,FirstName,LastName,DateofBirth,PostalCodeOrZipCode,By")] ClientCaseClientModels clientCaseClientModels)
        {
            if (ModelState.IsValid)
            {
                var test = ModelAdapter.GetConvertedModel(clientCaseClientModels, new ClientCase());
                db.Update(test);
                return RedirectToAction("Index");
            }
            ViewBag.CaseTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetCaseTypes(), "CaseTypeID", "Description", clientCaseClientModels.CaseTypeID);
            ViewBag.CoordinatorUserID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetUsers(), "UserID", "UserFullName", clientCaseClientModels.CoordinatorUserID);
            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "appFirstName", clientCaseClientModels.AppointmentResourceID);

            return View(clientCaseClientModels);

        }


        public ActionResult Search()
        {
            return View();
        }


        //[HttpPost]
        //public ActionResult Search(string description)
        //{
        //    if (description == null || description.Equals(""))
        //    {
        //        return View();
        //    }
        //    string list = db.GetClientandCases(description);
        //    List<ClientCaseClientModels> objList = JsonConvert.DeserializeObject<List<ClientCaseClientModels>>(list);
        //    return View(objList);
        //}

        public PartialViewResult SearchPeople(string keyword)
        {
            
            if (keyword == null || keyword.Equals(""))
            {
                 List<ClientCaseClientModels> objList1 = new List<ClientCaseClientModels>();
                 return PartialView(objList1);
            }

            var data = db.GetClientandCases(keyword);
            List<ClientCaseClientModels> objList = JsonConvert.DeserializeObject<List<ClientCaseClientModels>>(data);
            return PartialView(objList);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
