using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MobAlytaloMVC.Models;

namespace MobAlytaloMVC.Controllers
{
    public class TermostaattiController : Controller
    {
        private MobAlytaloDataEntities db = new MobAlytaloDataEntities();

        // GET: Termostaatti
        public ActionResult Index()
        {
            return View(db.Termostaatti.ToList());
        }

        // GET: Termostaatti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termostaatti termostaatti = db.Termostaatti.Find(id);
            if (termostaatti == null)
            {
                return HttpNotFound();
            }
            return View(termostaatti);
        }

        // GET: Termostaatti/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Termostaatti/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TermostaattiID,TermostaattiNimi,TermostaattiTila,TermostaattiNykyLampo")] Termostaatti termostaatti)
        {
            if (ModelState.IsValid)
            {
                db.Termostaatti.Add(termostaatti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(termostaatti);
        }

        // GET: Termostaatti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termostaatti termostaatti = db.Termostaatti.Find(id);
            if (termostaatti == null)
            {
                return HttpNotFound();
            }
            return View(termostaatti);
        }

        // POST: Termostaatti/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TermostaattiID,TermostaattiNimi,TermostaattiTila,TermostaattiNykyLampo")] Termostaatti termostaatti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(termostaatti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(termostaatti);
        }

        // GET: Termostaatti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Termostaatti termostaatti = db.Termostaatti.Find(id);
            if (termostaatti == null)
            {
                return HttpNotFound();
            }
            return View(termostaatti);
        }

        // POST: Termostaatti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Termostaatti termostaatti = db.Termostaatti.Find(id);
            db.Termostaatti.Remove(termostaatti);
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
