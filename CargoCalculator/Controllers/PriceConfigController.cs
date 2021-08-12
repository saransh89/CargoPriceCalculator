using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CargoCalculator.DBContext;

namespace CargoCalculator.Controllers
{
    [Authorize(Roles = "admin")]
    public class PriceConfigController : Controller
    {
        private SMS_DotnetCoreEntities db = new SMS_DotnetCoreEntities();

        // GET: PriceConfig
        public ActionResult Index()
        {
            var priceConfigs = db.PriceConfigs.Include(p => p.tblMstPartner).Include(p => p.tblMstPriceType);
            return View(priceConfigs.ToList());
        }

        // GET: PriceConfig/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceConfig priceConfig = db.PriceConfigs.Find(id);
            if (priceConfig == null)
            {
                return HttpNotFound();
            }
            return View(priceConfig);
        }

        // GET: PriceConfig/Create
        public ActionResult Create()
        {
            ViewBag.PartnerId = new SelectList(db.Partners, "Partnerid", "PartnerName");
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "PriceTypeid", "PriceTypeName");
            return View();
        }

        // POST: PriceConfig/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PriceConfigid,PartnerId,PriceTypeId,StartRange,EndRange,Price,IsActive")] PriceConfig priceConfig)
        {
            if (ModelState.IsValid)
            {
                db.PriceConfigs.Add(priceConfig);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PartnerId = new SelectList(db.Partners, "Partnerid", "PartnerName", priceConfig.PartnerId);
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "PriceTypeid", "PriceTypeName", priceConfig.PriceTypeId);
            return View(priceConfig);
        }

        // GET: PriceConfig/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceConfig priceConfig = db.PriceConfigs.Find(id);
            if (priceConfig == null)
            {
                return HttpNotFound();
            }
            ViewBag.PartnerId = new SelectList(db.Partners, "Partnerid", "PartnerName", priceConfig.PartnerId);
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "PriceTypeid", "PriceTypeName", priceConfig.PriceTypeId);
            return View(priceConfig);
        }

        // POST: PriceConfig/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PriceConfigid,PartnerId,PriceTypeId,StartRange,EndRange,Price,IsActive,ExtraWeightThreshold,ExtraPerWeightPrice")] PriceConfig priceConfig)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceConfig).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PartnerId = new SelectList(db.Partners, "Partnerid", "PartnerName", priceConfig.PartnerId);
            ViewBag.PriceTypeId = new SelectList(db.PriceTypes, "PriceTypeid", "PriceTypeName", priceConfig.PriceTypeId);
            return View(priceConfig);
        }

        // GET: PriceConfig/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceConfig priceConfig = db.PriceConfigs.Find(id);
            if (priceConfig == null)
            {
                return HttpNotFound();
            }
            return View(priceConfig);
        }

        // POST: PriceConfig/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PriceConfig priceConfig = db.PriceConfigs.Find(id);
            db.PriceConfigs.Remove(priceConfig);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
