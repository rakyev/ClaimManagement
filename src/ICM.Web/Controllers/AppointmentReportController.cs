using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Microsoft.Reporting.WebForms;
using ICM.Data;
using ICM.Data.Business.BusinessObject;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ICM.Data.Business.Projection;
namespace ICM.Web.Controllers
{
    public class AppointmentReportController : Controller
    {     
        // GET: AppointmentReport
        public ActionResult Index(String FirstName, String LastName, String HealthCardNumber)
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            AppointmentResourceBO activityBookingtype = new AppointmentResourceBO();
            if (!(string.IsNullOrWhiteSpace(FirstName)) || !(string.IsNullOrWhiteSpace(LastName)) || !(string.IsNullOrWhiteSpace(HealthCardNumber)))
            {
                Boolean unique = activityBookingtype.GetUniqueClient(FirstName, LastName, HealthCardNumber);
                if (unique == true)
                {
                    IQueryable<AppointmentsResourcePC> activityBookingTypes = activityBookingtype.GetAppointmentByClient(FirstName, LastName, HealthCardNumber);
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\AppointmentsReport.rdlc";
                    reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", activityBookingTypes));
                    reportViewer.LocalReport.Refresh();
                    ViewBag.ReportViewer = reportViewer;
                }
                else
                {
                    ViewBag.PassedString = "No Unique Client.Please Try More Filters";
                }
            }
            else
            {
                ViewBag.PassedString = "Search For Your Particular Client";
            }


            return View();
        }

        // GET: AppointmentReport/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppointmentReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentReport/Create
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

        // GET: AppointmentReport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppointmentReport/Edit/5
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

        // GET: AppointmentReport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppointmentReport/Delete/5
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

