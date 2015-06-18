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
    public class CompaniesController : Controller
    {
        private CompanyBO db = new CompanyBO();
       
        // GET: Companies
        public ActionResult Index(int? page)
        {
            var projectedCompanyList = new List<ICM.Web.Models.Company>();
            var realCompanyList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realCompanyList, projectedCompanyList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: Companies/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(company, new ICM.Web.Models.Company());
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID,TrandeName,Address1,Address2,City,ProvinceOrStateID,PostalCodeOrZipCode,CountryID,Phone,PhoneExtension,Fax,Email,HCAIFacilityRegistryID,TaxRegistrationNumber,By,CreatedOrUpdated,Version")] ICM.Web.Models.Company company)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(company, new Data.Company());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ICM.Web.Models.Company());

            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID,TrandeName,Address1,Address2,City,ProvinceOrStateID,PostalCodeOrZipCode,CountryID,Phone,PhoneExtension,Fax,Email,HCAIFacilityRegistryID,TaxRegistrationNumber,By,CreatedOrUpdated,Version")] ICM.Web.Models.Company company)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(company, new Data.Company());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            return View(company);
        }

        // GET: Companies/Delete/5
        /*public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
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
