using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ICM.Web.Models;
using ICM.Data;
using ICM.Data.Business.BusinessObject;
namespace ICM.Web.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserLog u)
        {
            SFSUsersBO user = new SFSUsersBO();
            if (ModelState.IsValid)
            {
                var v = user.GetAll().Where(a => a.us_Username.Equals(u.Username) && a.us_Username.Equals(u.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["LogedUserID"] = v.us_pk.ToString();
                        Session["LogedUserFullname"] = v.us_Username.ToString();
                        return RedirectToAction("AfterLogin");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid Username or password";
                    }
            }
            return View(u);
        }


        public ActionResult AfterLogin()
        {
            if (Session["LogedUserID"] != null)
            {

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Logout()
        {
            if (Session["LogedUserID"] != null)
            {
                Session.Clear();
            }
            return RedirectToAction("Index");
        }



        public ActionResult Detail()
        {

            if (Session["LogedUserID"] != null)
            {
                SFSUsersBO users = new SFSUsersBO();
                SFSUser user = new SFSUser();
                user = users.GetByKey(Convert.ToInt64(Session["LogedUserID"]));
                ViewBag.Username = user.us_Username.ToString();
                ViewBag.Firstname = user.us_FirstName.ToString();
                ViewBag.Lastname = user.us_LastName.ToString();
                //ViewBag.Email = user.Email.ToString();
            }
            return View();
        }




        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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
