using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ICM.Cloud.Storage.CloudProxy;
using ICM.Data.Business.BusinessObject;
using ICM.Web.DashboardBasics;
using ICM.Web.Infrastructure;
using ICM.Web.Models;

namespace ICM.Web.Controllers
{
    //[Authorize]
    public class ManagementController : Controller
    {
        // GET: CaseManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ModifyCaseManagement(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CaseManagementBO bo = new CaseManagementBO();
            var ac = bo.GetByKey(id);
            var activityModels = ModelAdapter.GetConvertedModel(ac, new CaseManagement());

            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "appFirstName", activityModels.AppointmentResourceID);
            ViewBag.DocumentTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetDocuments(), "DocumentTypeID", "Description", activityModels.DocumentTypeID);
            ViewBag.GoodAndServiceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetGoodAndSerVices(), "GoodAndServiceID", "Description", activityModels.GoodAndServiceID);
            ViewBag.MeasureID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetMeasures(), "MeasureID", "Description", activityModels.MeasureID);
            return View(activityModels);
        }

        [HttpPost]
        public ActionResult ModifyCaseManagement([Bind(Include = "CaseManagementID,CaseID,DocumentTypeID,FileName,NewFileName,CaseActivityID,HCAIStatus,DateOfService,GoodAndServiceID,GoodAndServiceAtt,GoodAndServiceDesc,AppointmentResourceID,Quantity,MeasureID,GSTHSTVAT,LineCost,Billed,PSTOther,PlanNumber,InvoiceNumber,PaymentAmount,BilledAmount,ApprovedAmount,Visible,WIPAmount,By,CreatedOrUpdated,Version,Active")] CaseManagement caseManagementModels, HttpPostedFileBase upload)
        {
            

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var randomFileName = Guid.NewGuid().ToString();
                    var myFileName = Path.GetFileName(upload.FileName);
                    var extension = Path.GetExtension(myFileName);
                    var fileNameForCloud = randomFileName + extension;
                    var fullPath = Path.GetFullPath(upload.FileName);
                    var fileDidSavetoCloud = CloudStorage.UploadFile(fullPath, fileNameForCloud);
                    

                    if (fileDidSavetoCloud)
                    {
                        caseManagementModels.FileName = myFileName;
                        caseManagementModels.NewFileName = fileNameForCloud;
                        CaseManagementBO bo = new CaseManagementBO();
                        var test = ModelAdapter.GetConvertedModel(caseManagementModels, new Data.CaseManagement());
                        bo.Update(test);
                        return RedirectToAction("Edit", "ClientCase", new { id = caseManagementModels.CaseID });
                    }
                }

            }
            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "appFirstName", caseManagementModels.AppointmentResourceID);
            ViewBag.DocumentTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetDocuments(), "DocumentTypeID", "Description", caseManagementModels.DocumentTypeID);
            ViewBag.GoodAndServiceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetGoodAndSerVices(), "GoodAndServiceID", "Description", caseManagementModels.GoodAndServiceID);
            ViewBag.MeasureID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetMeasures(), "MeasureID", "Description", caseManagementModels.MeasureID);
            return View(caseManagementModels);
        }

        public FileResult Download(string fileName)
        {
            string actualName = TempData["realName"].ToString();
            CloudStorage.DownloadFile(fileName);
            var newPath = Path.Combine(CloudStorage.GetFilePath(), fileName);
            return File(newPath, "application/doc",actualName);
        }


        public ActionResult ManagementDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseManagementBO bo = new CaseManagementBO();
            var test = bo.GetByKey(id);
            var caseModels = ModelAdapter.GetConvertedModel(test, new CaseManagement());
            return View(caseModels);
        }

        public ActionResult Create()
        {
            long caseid = Convert.ToInt64(TempData["caseid"]);
            ViewBag.ManageCaseID = caseid;

            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "FirstName");
            ViewBag.DocumentTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetDocuments(), "DocumentTypeID", "Description");
            ViewBag.GoodAndServiceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetGoodAndSerVices(), "GoodAndServiceID", "Description");
            ViewBag.MeasureID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetMeasures(), "MeasureID", "Description");
            return View();
        }

        // POST: ClientModelTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseManagementID,CaseID,DocumentTypeID,FileName,NewFileName,CaseActivityID,HCAIStatus,DateOfService,GoodAndServiceID,GoodAndServiceAtt,GoodAndServiceDesc,AppointmentResourceID,Quantity,MeasureID,GSTHSTVAT,LineCost,Billed,PSTOther,PlanNumber,InvoiceNumber,PaymentAmount,BilledAmount,ApprovedAmount,Visible,WIPAmount,By,CreatedOrUpdated,Version,Active")] CaseManagement caseman, HttpPostedFileBase upload)
        {
            long caseid = Convert.ToInt64(TempData["caseID"]);
            caseman.CaseID = caseid;

            if (ModelState.IsValid)
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    var randomFileName = Guid.NewGuid().ToString();
                    var myFileName = Path.GetFileName(upload.FileName);
                    var extension = Path.GetExtension(myFileName);
                    var fileNameForCloud = randomFileName + extension;
                    var fullPath = Path.GetFullPath(upload.FileName);
                    var fileDidSavetoCloud = CloudStorage.UploadFile(fullPath, fileNameForCloud);
                    if (fileDidSavetoCloud)
                    {
                        caseman.FileName = myFileName;
                        caseman.NewFileName = fileNameForCloud;
                        CaseManagementBO bo = new CaseManagementBO();
                        var man = ModelAdapter.GetConvertedModel(caseman, new Data.CaseManagement());
                        bo.Add(man);
                        bo.Save();
                        return RedirectToAction("Edit", "ClientCase", new {id = caseman.CaseID});
                    }
                }
            }

            ViewBag.AppointmentResourceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetProviders(), "AppointmentResourceID", "FirstName", caseman.AppointmentResourceID);
            ViewBag.DocumentTypeID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetDocuments(), "DocumentTypeID", "Description", caseman.DocumentTypeID);
            ViewBag.GoodAndServiceID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetGoodAndSerVices(), "GoodAndServiceID", "Description", caseman.GoodAndServiceID);
            ViewBag.MeasureID = new SelectList(ForeignKeysModelProxy.GetClientCaseForeignKeysModelInstance().GetMeasures(), "MeasureID", "Description", caseman.MeasureID);

            return View(caseman);
        }

        

    }
}