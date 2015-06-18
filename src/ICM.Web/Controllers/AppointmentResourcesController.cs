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
    public class AppointmentResourcesController : Controller
    {
        private AppointmentResourceBO db = new AppointmentResourceBO();

        // GET: AppointmentResources
        public ActionResult Index(int? page)
        {
            var projectedAppoitmentResourceList = new List<AppointmentResourceModels>();
            var realAppointmentResourceList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realAppointmentResourceList, projectedAppoitmentResourceList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable
            return View(model.ToPagedList(pageNumber, pageSize));

        }

        // GET: AppointmentResources/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var test = db.GetByKey(id);
            var appointmentResourceModel = new AppointmentResourceModels();
            var projectedAppointmentResource = ModelAdapter.GetConvertedModel(test, appointmentResourceModel);

            if (projectedAppointmentResource == null)
            {
                return HttpNotFound();
            }
            return View(projectedAppointmentResource);
        }

        // GET: AppointmentResources/Create
        public ActionResult Create()
        {
            ViewBag.AppointmentResourceBookingTypeID = new SelectList(ForeignKeysModelProxy.GetAppointmentResourceForeignKeysInstance().GetAppointmentResourceBookingTypes(), "AppointmentResourceBookingTypeID", "Description");
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            return View();
        }

        // POST: AppointmentResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AppointmentResourceID,AppointmentResourceBookingTypeID,CompanyBranchID,FirstName,LastName,Description,HCAIProviderRegistryID,CollegeRegistrationNumber,WebAccessCode,DoubleBookingAllowed,Address1,Address2,Address3,City,ProvinceOrStateID,PostalCodeOrZipCode,CountryID,CellPhone,WorkPhone,WorkPhoneExtension,WorkFax,OtherPhone,WorkEmail,AdditionalEmail,Credentials,Comments,ResumeName,By,CreatedOrUpdated,Version,Active")] AppointmentResourceModels appointmentResource)
        {
            if (ModelState.IsValid)
            {
                var realAppResource = new AppointmentResource();
                var realAppResourceToPersist = ModelAdapter.GetConvertedModel(appointmentResource, realAppResource);
                db.Add(realAppResourceToPersist);
                db.Save();
                //todo--implement messaging after persisting
                //ClientCaseDoctorAppointmentCounts insObj = new ClientCaseDoctorAppointmentCounts();
                //TempData.Add("count", insObj);
                return RedirectToAction("Index");
            }

            ViewBag.AppointmentResourceBookingTypeID = new SelectList(ForeignKeysModelProxy.GetAppointmentResourceForeignKeysInstance().GetAppointmentResourceBookingTypes(), "AppointmentResourceBookingTypeID", "Description", appointmentResource.AppointmentResourceBookingTypeID);
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description", appointmentResource.CountryID);
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description", appointmentResource.ProvinceOrStateID);
            return View(appointmentResource);
        }

        // GET: AppointmentResources/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var test = db.GetByKey(id);

            var appointmentResourcesModels = new AppointmentResourceModels();
            appointmentResourcesModels = ModelAdapter.GetConvertedModel(test, appointmentResourcesModels);


            if (appointmentResourcesModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppointmentResourceBookingTypeID = new SelectList(ForeignKeysModelProxy.GetAppointmentResourceForeignKeysInstance().GetAppointmentResourceBookingTypes(), "AppointmentResourceBookingTypeID", "Description", appointmentResourcesModels.AppointmentResourceBookingTypeID);
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description", appointmentResourcesModels.CountryID);
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description", appointmentResourcesModels.ProvinceOrStateID);
            return View(appointmentResourcesModels);
        }

        // POST: AppointmentResources/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AppointmentResourceID,AppointmentResourceBookingTypeID,CompanyBranchID,FirstName,LastName,Description,HCAIProviderRegistryID,CollegeRegistrationNumber,WebAccessCode,DoubleBookingAllowed,Address1,Address2,Address3,City,ProvinceOrStateID,PostalCodeOrZipCode,CountryID,CellPhone,WorkPhone,WorkPhoneExtension,WorkFax,OtherPhone,WorkEmail,AdditionalEmail,Credentials,Comments,ResumeName,By,CreatedOrUpdated,Version,Active")] AppointmentResourceModels appointmentResource)
        {
            var test = new AppointmentResource();  //Mapper.Map<ClientModels, Client>(clientModels);
            test = ModelAdapter.GetConvertedModel(appointmentResource, test);

            if (ModelState.IsValid)
            {
                db.Update(test);
                return RedirectToAction("Index");
            }
            ViewBag.AppointmentResourceBookingTypeID = new SelectList(ForeignKeysModelProxy.GetAppointmentResourceForeignKeysInstance().GetAppointmentResourceBookingTypes(), "AppointmentResourceBookingTypeID", "Description", appointmentResource.AppointmentResourceBookingTypeID);
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description", appointmentResource.CountryID);
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description", appointmentResource.ProvinceOrStateID);
            return View(appointmentResource);
        }

        // GET: AppointmentResources/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var realModel = db.GetByKey(id);
            AppointmentResourceModels appointmentResource = ModelAdapter.GetConvertedModel(realModel,
                new AppointmentResourceModels());
            if (appointmentResource == null)
            {
                return HttpNotFound();
            }
            return View(appointmentResource);
        }

        // POST: AppointmentResources/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            var appointmentResource = db.GetByKey(id);
            db.Delete(appointmentResource);
            db.Save();
            return RedirectToAction("Index");
        }
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search(String description)
        {
            if (description == null || description.Equals(""))
            {
                return View();
            }
            var list = db.GetDoctorSearched(description);
            var objList = new List<AppointmentResourceModels>();

            objList = ModelAdapter.GetConvertedModelList(list, objList);
            return View(objList);
        }


        public PartialViewResult SearchPeople(string keyword)
        {
            var result = new List<AppointmentResourceModels>();
            if (keyword == null || keyword.Equals(""))
            {
                return PartialView(result);
            }

            var data = db.GetDoctorSearched(keyword);
            result = ModelAdapter.GetConvertedModelList(data, result);

            return PartialView(result);
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
