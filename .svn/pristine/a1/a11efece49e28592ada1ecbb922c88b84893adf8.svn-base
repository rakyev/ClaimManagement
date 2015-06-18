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
    public class CaseController : Controller
    {
        // GET: Case
        public ActionResult Index(String FirstName, String LastName, String PhoneNumber)
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            ClientCaseBO activityBookingtype = new ClientCaseBO();
            if (!(string.IsNullOrWhiteSpace(FirstName)) || !(string.IsNullOrWhiteSpace(LastName)) || !(string.IsNullOrWhiteSpace(PhoneNumber)))
            {
                Boolean unique = activityBookingtype.GetUniqueClient(FirstName, LastName, PhoneNumber);
                if (unique == true)
                {
                    IQueryable<ClientCasePC> activityBookingTypes = activityBookingtype.GetAppointmentByClient(FirstName, LastName, PhoneNumber);
                    reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\CaseReport.rdlc";
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


        // GET: Case/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Case/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Case/Create
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

        // GET: Case/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Case/Edit/5
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

        // GET: Case/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Case/Delete/5
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
