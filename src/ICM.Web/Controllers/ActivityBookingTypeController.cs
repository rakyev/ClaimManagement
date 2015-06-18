using ICM.Data;
using ICM.Data.Business.BusinessObject;
using ICM.Data.Business.Projection;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ICM.Web.Controllers
{
    //[Authorize]
    public class ActivityBookingTypeController : Controller
    {
        
        // GET: ActivityBookingType
        public ActionResult Index()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);
            
            ActivityBookingTypeBO activityBookingtype = new ActivityBookingTypeBO();
            IQueryable<ActivityBookingTypePC> activityBookingTypes = activityBookingtype.GetAppointmentResourceCountGroupedByActivityBookingType();

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\ActivityBookingTypeReport.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", activityBookingTypes));

            reportViewer.LocalReport.Refresh();

            ViewBag.ReportViewer = reportViewer;
            return View();
        }

        public ActionResult OpenPopup()
        {
            SFSUsersBO users = new SFSUsersBO();
            SFSUser user = new SFSUser();
            user = users.GetByKey(Convert.ToInt64(Session["LogedUserID"]));
            ViewBag.firstname = user.us_FirstName.ToString();
            ViewBag.lastname = user.us_LastName.ToString();
            return View();
        }

        
        // GET: ActivityBookingType/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ActivityBookingType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActivityBookingType/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ActivityBookingType/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ActivityBookingType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ActivityBookingType/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ActivityBookingType/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
