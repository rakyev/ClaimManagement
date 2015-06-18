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
    public class NotesController : Controller
    {
        CaseNoteBO bo = new CaseNoteBO();
        // GET: Notes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {

            long clientid = Convert.ToInt64(TempData["clientId"]);
            ViewBag.NoteClientID = clientid;

            long caseid = Convert.ToInt64(TempData["caseid"]);
            ViewBag.NoteCaseID = caseid;

            return View();
        }

        // POST: ClientModelTest1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseNoteID,CaseID,ClientID,Subject,Note,Active,CreatedorUpdated,Version,By,CompletedBy,RemiderDate,Private,RemindUserID")] ICM.Web.Models.CaseNote notes)
        {

            long caseid = Convert.ToInt64(TempData["caseID"]);
            notes.CaseID = caseid;

            if (ModelState.IsValid)
            {
                var casenotes = ModelAdapter.GetConvertedModel(notes, new ICM.Data.CaseNote());
                bo.Add(casenotes);
                bo.Save();
                return RedirectToAction("Edit", "ClientCase", new { id = notes.CaseID });
            }

            return View(notes);
        }
        public ActionResult ModifyCaseNote(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseNoteBO bo = new CaseNoteBO();
            var ac = bo.GetByKey(id);
            var activityModels = ModelAdapter.GetConvertedModel(ac, new ICM.Web.Models.CaseNote());
            return View(activityModels);
        }

        [HttpPost]
        public ActionResult ModifyCaseNote([Bind(Include = "CaseNoteID,CaseID,ClientID,Subject,Note,Active,CreatedOrUpdated,Version,By,CompletedBy,RemiderDate,Private,RemindUserID")] ICM.Web.Models.ClientCaseClientModels clientCaseClientModels)
        {

            if (ModelState.IsValid)
            {
                CaseNoteBO no = new CaseNoteBO();
                var test = ModelAdapter.GetConvertedModel(clientCaseClientModels, new ICM.Data.CaseNote());
                no.Update(test);
                return RedirectToAction("Edit", "ClientCase", new { id = clientCaseClientModels.CaseID });
            }
            return View(clientCaseClientModels);
        }

        public ActionResult NoteDetails(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaseNoteBO bo = new CaseNoteBO();
            var test = bo.GetByKey(id);
            var caseModels = ModelAdapter.GetConvertedModel(test, new ICM.Web.Models.CaseNote());
            return View(caseModels);
        }
    }
}