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
    public class ClientModelTest1Controller : Controller
    {
       // private ICMWebContext db = new ICMWebContext();
        private ClientBO bo = new ClientBO();

        // GET: ClientModelTest1
        public ActionResult Index(int? page) 
        {
            var projectedClientList = new List<ClientModels>();
            var realClientList = bo.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realClientList, projectedClientList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable
            
            return View(model.ToPagedList(pageNumber, pageSize));


        }

        // GET: ClientModelTest1/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            var test = bo.GetByKey(id);
            var clientModels = new ClientModels(); 
            var projectedClient = ModelAdapter.GetConvertedModel(test, clientModels);

            if (projectedClient == null)
            {
                return HttpNotFound();
            }
            return View(projectedClient);
        }

       
        // GET: ClientModelTest1/Create
        public ActionResult Create()
        {
            //new SelectList()
            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description");
            ViewBag.GenderID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().Gengers(), "GenderID", "Description");
            ViewBag.MaritalStatusID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetMaritals(), "MaritalStatusID", "Description");
            ViewBag.PrefixID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetPrexises(), "PrefixID", "Description");
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description");
            return View();
        }
                
        // POST: ClientModelTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientID,PrefixID,FirstName,MiddleName,LastName,Suffix,GenderID,DateofBirth,Address1,Address2,City,ProvinceOrStateID,PostalCodeOrZipCode,CountryID,HomePhone,CellPhone,PersanalFax,PersonalEmail,MaritalStatusID,SocialInsuranceNumber,HealthCardNumber,DriversLicenseNumber,Weight,Height,Occupation,WorkPhone,WorkPhoneExtension,WorkFax,WorkEmail,Picture,By,CreatedOrUpdated,Version,Active")] ClientModels clientModels)
        {
            if (ModelState.IsValid)
            {
                var realClient = new Client();
                var realClientToPersist = ModelAdapter.GetConvertedModel(clientModels,realClient);
                bo.Add(realClientToPersist);
                bo.Save();
                //todo--implement messaging after persisting
                //ClientCaseDoctorAppointmentCounts insObj = new ClientCaseDoctorAppointmentCounts();
                //TempData.Add("count", insObj);
                return RedirectToAction("Index");
            }




            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description", clientModels.CountryID);
            ViewBag.GenderID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().Gengers(), "GenderID", "Description", clientModels.GenderID);
            ViewBag.MaritalStatusID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetMaritals(), "MaritalStatusID", "Description", clientModels.MaritalStatusID);
            ViewBag.PrefixID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetPrexises(), "PrefixID", "Description", clientModels.PrefixID);
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description", clientModels.ProvinceOrStateID);
            return View(clientModels);
        }


        public ActionResult CaseCreate(long? id)
        {
            var test = bo.GetByKey(id);
            test.By = "";
            test.CreatedOrUpdated = DateTime.Now;
            test.Version = 0;
            test.Active = false;

            var clientModels = new ClientCaseModels();
            clientModels = ModelAdapter.GetConvertedModel(test, clientModels);
         //   ViewBag.ClientID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetClientTypes(), "ClientID", "FirstName");
            ViewBag.CaseTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetCaseTypes(), "CaseTypeID", "Description");
            ViewBag.CoordinatorUserID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetUsers(), "UserID", "UserFullName");
            return View(clientModels);
        }

        // POST: AppointmentResources/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CaseCreate([Bind(Include = "CaseID,ClientID,CaseTypeID,Description,RefferalDate,CoordinatorUserID,ClosedDate,By,CreatedOrUpdated,Version,Active")] ClientCaseModels clientcase)
        {
            if (ModelState.IsValid)
            {
                ClientCaseBO bo = new ClientCaseBO();
                var realCase = new ClientCase();
                var realCaseToPersist = ModelAdapter.GetConvertedModel(clientcase, realCase);
                bo.Add(realCaseToPersist);
                bo.Save();
                //todo--implement messaging after persisting
                //ClientCaseDoctorAppointmentCounts insObj = new ClientCaseDoctorAppointmentCounts();
                //TempData.Add("count", insObj);
                return RedirectToAction("Index");
            }
            //ViewBag.ClientID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetClientTypes(), "ClientID", "FirstName", clientcase.ClientID);
            ViewBag.CaseTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetCaseTypes(), "CaseTypeID", "Description", clientcase.CaseTypeID);
            ViewBag.CoordinatorUserID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetUsers(), "UserID", "UserFullName", clientcase.CoordinatorUserID);
            return View(clientcase);
        }

        // GET: ClientModelTest1/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
            var test = bo.GetByKey(id);

            var clientModels = new ClientModels();
            clientModels = ModelAdapter.GetConvertedModel(test, clientModels);


            if (clientModels == null)
            {
                return HttpNotFound();
            }

            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description", clientModels.CountryID);
            ViewBag.GenderID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().Gengers(), "GenderID", "Description", clientModels.GenderID);
            ViewBag.MaritalStatusID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetMaritals(), "MaritalStatusID", "Description", clientModels.MaritalStatusID);
            ViewBag.PrefixID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetPrexises(), "PrefixID", "Description", clientModels.PrefixID);
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description", clientModels.ProvinceOrStateID);
            return View(clientModels);
        }

        // POST: ClientModelTest1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientID,PrefixID,FirstName,MiddleName,LastName,Suffix,GenderID,DateofBirth,Address1,Address2,City,ProvinceOrStateID,PostalCodeOrZipCode,CountryID,HomePhone,CellPhone,PersanalFax,PersonalEmail,MaritalStatusID,SocialInsuranceNumber,HealthCardNumber,DriversLicenseNumber,Weight,Height,Occupation,WorkPhone,WorkPhoneExtension,WorkFax,WorkEmail,Picture,By,CreatedOrUpdated,Version,Active")] ClientModels clientModels)
        {
           
            var test = new Client();  //Mapper.Map<ClientModels, Client>(clientModels);
            test = ModelAdapter.GetConvertedModel(clientModels, test);

            if (ModelState.IsValid)
            {
                bo.Update(test);
                return RedirectToAction("Index");
            }

            ViewBag.CountryID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetCountries(), "CountryID", "Description", clientModels.CountryID);
            ViewBag.GenderID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().Gengers(), "GenderID", "Description", clientModels.GenderID);
            ViewBag.MaritalStatusID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetMaritals(), "MaritalStatusID", "Description", clientModels.MaritalStatusID);
            ViewBag.PrefixID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetPrexises(), "PrefixID", "Description", clientModels.PrefixID);
            ViewBag.ProvinceOrStateID = new SelectList(ForeignKeysModelProxy.GetForeignKeysModelInstance().GetProvincesList(), "ProvinceOrStateID", "Description", clientModels.ProvinceOrStateID);
            return View(clientModels);
        }

        // GET: ClientModelTest1/Delete/5
        public ActionResult Delete(long? id)
        {
            //Mapper.CreateMap<Client, ClientModels>();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var test = bo.GetByKey(id);
            var clientModels = new ClientModels();

            clientModels = ModelAdapter.GetConvertedModel(test, clientModels);

            if (clientModels == null)
            {
                return HttpNotFound();
            }
            return View(clientModels);
        }

        // POST: ClientModelTest1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {

            var clientModels = bo.GetByKey(id);
            bo.Delete(clientModels);
            bo.Save();
            //ClientCaseDoctorAppointmentCounts insObj = new ClientCaseDoctorAppointmentCounts();
            //TempData.Add("count", insObj);
            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Search(String description)
        //{
        //    if (description == null || description.Equals(""))
        //    {
        //        return View();
        //    }
        //    var list = bo.GetClientsSearched(description);
        //    var objList = new List<ClientModels>();

        //    objList = ModelAdapter.GetConvertedModelList(list, objList);
        //    return View(objList);
        //}

        public PartialViewResult SearchPeople(string keyword, int? page)
        {
            List<Client> data = null;
            var result = new List<ClientModels>();
            if (keyword == null || keyword.Equals(""))
            {
                //return PartialView(result);
                data = bo.GetAll().ToList<Client>();
            }
            else {
                data = bo.GetClientsSearched(keyword);
            }
                
            result = ModelAdapter.GetConvertedModelList(data, result);
            
            //return PartialView(result);
            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return PartialView(result.ToPagedList(pageNumber, pageSize));
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
