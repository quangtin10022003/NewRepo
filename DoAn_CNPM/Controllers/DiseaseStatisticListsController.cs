using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CNPM.Models
{
    public class DiseaseStatisticListsController : Controller
    {
        private DoAnCNPMEntities1 db = new DoAnCNPMEntities1();

        // GET: DiseaseStatisticLists
        public ActionResult Index(string SearchString)
        {
            var diseaseStatisticLists = db.DiseaseStatisticLists.Include(d => d.DetailForm);
            if (!String.IsNullOrEmpty(SearchString))
            {
                diseaseStatisticLists = diseaseStatisticLists.Where(s => s.Dianose.ToString().Contains(SearchString));
                return View(diseaseStatisticLists.ToList());
            }
            return View(diseaseStatisticLists.ToList());
        }

        // GET: DiseaseStatisticLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseStatisticList diseaseStatisticList = db.DiseaseStatisticLists.Find(id);
            if (diseaseStatisticList == null)
            {
                return HttpNotFound();
            }
            return View(diseaseStatisticList);
        }

        // GET: DiseaseStatisticLists/Create
        public ActionResult Create()
        {
            ViewBag.IdDetailForm = new SelectList(db.DetailForms, "IdDetailForm", "IdDetailForm");
            return View();
        }

        // POST: DiseaseStatisticLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDSL,Dianose,IdDetailForm")] DiseaseStatisticList diseaseStatisticList)
        {
            if (ModelState.IsValid)
            {
                db.DiseaseStatisticLists.Add(diseaseStatisticList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdDetailForm = new SelectList(db.DetailForms, "IdDetailForm", "IdDetailForm", diseaseStatisticList.IdDetailForm);
            return View(diseaseStatisticList);
        }

        // GET: DiseaseStatisticLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseStatisticList diseaseStatisticList = db.DiseaseStatisticLists.Find(id);
            if (diseaseStatisticList == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdDetailForm = new SelectList(db.DetailForms, "IdDetailForm", "IdDetailForm", diseaseStatisticList.IdDetailForm);
            return View(diseaseStatisticList);
        }

        // POST: DiseaseStatisticLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDSL,Dianose,IdDetailForm")] DiseaseStatisticList diseaseStatisticList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diseaseStatisticList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdDetailForm = new SelectList(db.DetailForms, "IdDetailForm", "IdDetailForm", diseaseStatisticList.IdDetailForm);
            return View(diseaseStatisticList);
        }

        // GET: DiseaseStatisticLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiseaseStatisticList diseaseStatisticList = db.DiseaseStatisticLists.Find(id);
            if (diseaseStatisticList == null)
            {
                return HttpNotFound();
            }
            return View(diseaseStatisticList);
        }

        // POST: DiseaseStatisticLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiseaseStatisticList diseaseStatisticList = db.DiseaseStatisticLists.Find(id);
            db.DiseaseStatisticLists.Remove(diseaseStatisticList);
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
