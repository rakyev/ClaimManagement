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
    public class ProvinceOrStatesController : Controller
    {
        private ProvinceOrStateBO db = new ProvinceOrStateBO();

        // GET: ProvinceOrStates
        public PartialViewResult Index(int? page)
        {
            var projectedClientList = new List<ProvinceOrState>();
            List<Data.ProvinceOrState> realProStateList = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realProStateList, projectedClientList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable
           // return View(objList.ToPagedList(pageNumber, pageSize));
            return PartialView(model.ToPagedList(pageNumber, pageSize));

        
        }

        // GET: ProvinceOrStates/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var provinceOrState = db.GetByKey(id);
            var test = ModelAdapter.GetConvertedModel(provinceOrState, new ProvinceOrState());
            if (provinceOrState == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }

        // GET: ProvinceOrStates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProvinceOrStates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProvinceOrStateID,Description,Code,By,CreatedOrUpdated,Version,Active")] ProvinceOrState provinceOrState)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(provinceOrState,  new Data.ProvinceOrState());
                db.Add(realModel);
                db.Save();
               
                return RedirectToAction("Index");
            }

            return View(provinceOrState);
        }

        // GET: ProvinceOrStates/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var provinceOrState = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ProvinceOrState());
            
            if (provinceOrState == null)
            {
                return HttpNotFound();
            }
            return View(provinceOrState);
        }

        // POST: ProvinceOrStates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProvinceOrStateID,Description,Code,By,CreatedOrUpdated,Version,Active")] ProvinceOrState provinceOrState)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(provinceOrState, new Data.ProvinceOrState());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            return View(provinceOrState);
        }

        // GET: ProvinceOrStates/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var provinceOrState = ModelAdapter.GetConvertedModel(db.GetByKey(id), new ProvinceOrState());
            if (provinceOrState == null)
            {
                return HttpNotFound();
            }
            return View(provinceOrState);
        }

        // POST: ProvinceOrStates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var provinceOrState = db.GetByKey(id);
            db.Delete(provinceOrState);
            db.Save();
            return RedirectToAction("Index");
        }

        public PartialViewResult SearchProvinces(int? page, string keyword = "")
        {
            var result = new List<ProvinceOrState>();
            //if (keyword == null || keyword.Equals(""))
            //{
            //    return PartialView(result);
            //}
            const int pageSize = 50;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable
            // return View(objList.ToPagedList(pageNumber, pageSize));
           // return PartialView(model.ToPagedList(pageNumber, pageSize));

            var data = db.GetProvinces(keyword);
            result = ModelAdapter.GetConvertedModelList(data, result);
            ViewBag.keyword = keyword;
            return PartialView(result.ToPagedList(pageNumber,pageSize));
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
