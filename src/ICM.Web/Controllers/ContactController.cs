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
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            long caseid = Convert.ToInt64(TempData["caseid"]);
            ViewBag.ContactCaseID = caseid;

            ViewBag.CaseContactTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetContactTypes(), "CaseContactTypeID", "Description");
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.PrefixID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetPrexises(), "PrefixID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            ViewBag.CaseContactRelationshipID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetContactRelationshipTypes(), "CaseContactRelationshipID", "Description");
            ViewBag.CaseContactSpecialityID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetContactSpecialityTypes(), "CaseContactSpecialityID", "Description");
            return View();
        }

        // POST: CaseActivity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseContactID,CaseContactTypeID,CaseID,PrefixID,FirstName,MiddleName,LastName,Address1,Address2,City,ProvinceOrStateID,PostalCodeOrZipCode,CountryID,HomePhone,CellPhone,PersonalEmail,CompanyName,WorkPhone,WorkPhoneExtension,WorkFax,WorkEmail,CaseContactRelationshipID,CaseContactSpecialityID,By,CreatedOrUpdated,Version,Active")] ICM.Web.Models.CaseContact contact)
        {
            long caseid = Convert.ToInt64(TempData["caseID"]);
            contact.CaseID = caseid;

            if (ModelState.IsValid)
            {
                CaseContactBO bo = new CaseContactBO();
                var casecontact = ModelAdapter.GetConvertedModel(contact, new ICM.Data.CaseContact());
                bo.Add(casecontact);
                bo.Save();
                return RedirectToAction("Edit", "ClientCase", new { id = contact.CaseID });
            }


            ViewBag.CaseContactTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetContactTypes(), "CaseContactTypeID", "Description");
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            ViewBag.PrefixID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetPrexises(), "PrefixID", "Description");
            ViewBag.ContactRelationshipID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetContactRelationshipTypes(), "CaseContactRelationshipID", "Description");
            ViewBag.ContactSpecialityID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetContactSpecialityTypes(), "CaseContactSpecialityID", "Description");
            return View(contact);
        }
        public ActionResult ModifyCaseContact(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseContactBO bo = new CaseContactBO();
            var ac = bo.GetByKey(id);
            var activityModels = ModelAdapter.GetConvertedModel(ac, new ICM.Web.Models.CaseContact());
            ViewBag.CaseContactTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetContactTypes(), "CaseContactTypeID", "Description", activityModels.CaseContactTypeID);
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.PrefixID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetPrexises(), "PrefixID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");

            return View(activityModels);
        }


        [HttpPost]
        public ActionResult ModifyCaseContact([Bind(Include = "CaseContactID,CaseContactTypeID,CaseID,PrefixID,FirstName,MiddleName,LastName,Address1,Address2,City,ProvinceOrStateID,PostalCodeOrZipCode,CountryID,HomePhone,CellPhone,PersonalEmail,CompanyName,WorkPhone,WorkPhoneExtension,WorkFax,WorkEmail,CaseContactRelationshipID,CaseContactSpecialityID,By,CreatedOrUpdated,Version,Active")] ICM.Web.Models.CaseContact clientCaseClientModels)
        {

            if (ModelState.IsValid)
            {
                CaseContactBO bo = new CaseContactBO();
                var test = ModelAdapter.GetConvertedModel(clientCaseClientModels, new ICM.Data.CaseContact());
                bo.Update(test);
                return RedirectToAction("Edit", "ClientCase", new { id = clientCaseClientModels.CaseID });
            }
            ViewBag.CaseContactTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetContactTypes(), "CaseContactTypeID", "Description", clientCaseClientModels.CaseContactTypeID);
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            ViewBag.PrefixID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetPrexises(), "PrefixID", "Description");
            return View(clientCaseClientModels);
        }
        public ActionResult ContactDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseContactBO bo = new CaseContactBO();
            var test = bo.GetByKey(id);
            var caseModels = ModelAdapter.GetConvertedModel(test, new ICM.Web.Models.CaseContact());

            return View(caseModels);
        }
    }
}