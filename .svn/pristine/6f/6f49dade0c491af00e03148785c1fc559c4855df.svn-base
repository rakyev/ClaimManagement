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
    public class InsuranceCompaniesController : Controller
    {
        private InsuranceCompanyBO db = new InsuranceCompanyBO();

        // GET: InsuranceCompanies
        public ActionResult Index(int? page)
        {
            var projectedInsuranceCompanyList = new List<InsuranceCompany>();
            var realInsuranceCompanyList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realInsuranceCompanyList, projectedInsuranceCompanyList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: InsuranceCompanies/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var insuranceCompany = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(insuranceCompany, new InsuranceCompany());
            if (insuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: InsuranceCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InsuranceCompanyID,CompanyName,IBCInsurerID,By,CreatedOrUpdated,Version,Active")] InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(insuranceCompany, new Data.InsuranceCompany());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var insuranceCompany = ModelAdapter.GetConvertedModel(db.GetByKey(id), new InsuranceCompany());

            if (insuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(insuranceCompany);
        }

        // POST: InsuranceCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InsuranceCompanyID,CompanyName,IBCInsurerID,By,CreatedOrUpdated,Version,Active")] InsuranceCompany insuranceCompany)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(insuranceCompany, new Data.InsuranceCompany());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(insuranceCompany);
        }

        // GET: InsuranceCompanies/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var insuranceCompany = ModelAdapter.GetConvertedModel(db.GetByKey(id), new InsuranceCompany());
            if (insuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(insuranceCompany);
        }

        // POST: InsuranceCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var insuranceCompany = db.GetByKey(id);
            db.Delete(insuranceCompany);
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
