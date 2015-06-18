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
using PagedList.Mvc;
using ICM.Web.DashboardBasics;


namespace ICM.Web.Controllers
{
    public class GoodAndServiceController : Controller
    {
        private GoodAndServiceBO db = new GoodAndServiceBO();

        // GET: /GoodAndService/
        public ActionResult Index(int? page)
        {
            var goodAndServiceList = new List<GoodAndService>();
            var realGoodAndService = db.GetAll().ToList();
            var model = ModelAdapter.GetConvertedModelList(realGoodAndService, goodAndServiceList);

            const int pageSize = 10;//number of patients per page
            int pageNumber = (page ?? 1);//can be nullable

            return View(model.ToPagedList(pageNumber, pageSize));
        }

        // GET: /GoodAndService/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var goodAndService = ModelAdapter.GetConvertedModel(db.GetByKey(id), new GoodAndService());
            if (goodAndService == null)
            {
                return HttpNotFound();
            }
            return View(goodAndService);
        }

        // GET: /GoodAndService/Create
        public ActionResult Create()
        {
            ViewBag.GoodAndServiceTypeID = new SelectList(new ForeignKeysForGoodAndServiceModel().GetGoodAndServiceType(), "GoodAndServiceTypeID", "Description");
            return View();
        }

        // POST: /GoodAndService/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GoodAndServiceID,GoodAndServiceTypeID,Description,Code,Fixed,GSTHSTVAT,PSTOther,Fee,MeasureID,By,CreatedOrUpdated,Version,Active")] GoodAndService goodandservice)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(goodandservice, new Data.GoodAndService());
                db.Add(realModel);
                db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GoodAndServiceTypeID = new SelectList(new ForeignKeysForGoodAndServiceModel().GetGoodAndServiceType(), "GoodAndServiceTypeID", "Description");
            return View(goodandservice);
        }

        // GET: /GoodAndService/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var goodAndService = ModelAdapter.GetConvertedModel(db.GetByKey(id), new GoodAndService());
            if (goodAndService == null)
            {
                return HttpNotFound();
            }
            ViewBag.GoodAndServiceTypeID = new SelectList(new ForeignKeysForGoodAndServiceModel().GetGoodAndServiceType(), "GoodAndServiceTypeID", "Description");
            return View(goodAndService);
        }

        // POST: /GoodAndService/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GoodAndServiceID,GoodAndServiceTypeID,Description,Code,Fixed,GSTHSTVAT,PSTOther,Fee,MeasureID,By,CreatedOrUpdated,Version,Active")] GoodAndService goodandservice)
        {
            if (ModelState.IsValid)
            {
                var realModel = ModelAdapter.GetConvertedModel(goodandservice, new Data.GoodAndService());
                db.Update(realModel);
                return RedirectToAction("Index");
            }
            ViewBag.GoodAndServiceTypeID = new SelectList(new ForeignKeysForGoodAndServiceModel().GetGoodAndServiceType(), "GoodAndServiceTypeID", "Description");
            return View(goodandservice);
        }

        // GET: /GoodAndService/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var goodAndService = ModelAdapter.GetConvertedModel(db.GetByKey(id), new GoodAndService());
            if (goodAndService == null)
            {
                return HttpNotFound();
            }
            return View(goodAndService);
        }

        // POST: /GoodAndService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var goodAndService = db.GetByKey(id);
            db.Delete(goodAndService);
            db.Save();
            return RedirectToAction("Index");
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
