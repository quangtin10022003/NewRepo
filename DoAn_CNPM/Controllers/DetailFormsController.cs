﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAn_CNPM.Models
{
    public class DetailFormsController : Controller
    {
        private DoAnCNPMEntities1 db = new DoAnCNPMEntities1();

        [HttpPost]
        public ActionResult UpdatePaymentStatus(int id)
        {
            var detailForm = db.DetailForms.Find(id);
            if (detailForm == null)
            {
                return HttpNotFound();
            }

            detailForm.IsPay = !detailForm.IsPay;
            db.Entry(detailForm).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: DetailForms
        public ActionResult Index(string SearchString, string SearchString1)
        {
            var detailForms = db.DetailForms.Include(d => d.Form).Include(d => d.PriceList);
            if (!String.IsNullOrEmpty(SearchString))
            {
                detailForms = detailForms.Where(s => s.IdDetailForm.ToString().Contains(SearchString));
            }
            if (!String.IsNullOrEmpty(SearchString1))
            {
                detailForms = detailForms.Where(s => s.PriceList.NamePriceList.ToString().Contains(SearchString1));
            }
            
            return View(detailForms.ToList());
        }

        // GET: DetailForms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailForm detailForm = db.DetailForms.Find(id);
            if (detailForm == null)
            {
                return HttpNotFound();
            }
            return View(detailForm);
        }

        // GET: DetailForms/Create
        public ActionResult Create()
        {
            ViewBag.IdForm = new SelectList(db.Forms, "IdForm", "IdForm");
            ViewBag.IdPriceList = new SelectList(db.PriceLists, "IdPriceList", "NamePriceList");
            return View();
        }

        // POST: DetailForms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdDetailForm,Quantity,UnitPrice,IdForm,IdPriceList")] DetailForm detailForm)
        {
            if (ModelState.IsValid)
            {
                db.DetailForms.Add(detailForm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdForm = new SelectList(db.Forms, "IdForm", "IdForm", detailForm.IdForm);
            ViewBag.IdPriceList = new SelectList(db.PriceLists, "IdPriceList", "NamePriceList", detailForm.IdPriceList);
            return View(detailForm);
        }

        // GET: DetailForms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailForm detailForm = db.DetailForms.Find(id);
            if (detailForm == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdForm = new SelectList(db.Forms, "IdForm", "IdForm", detailForm.IdForm);
            ViewBag.IdPriceList = new SelectList(db.PriceLists, "IdPriceList", "NamePriceList", detailForm.IdPriceList);
            return View(detailForm);
        }

        // POST: DetailForms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdDetailForm,Quantity,UnitPrice,IdForm,IdPriceList")] DetailForm detailForm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detailForm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdForm = new SelectList(db.Forms, "IdForm", "IdForm", detailForm.IdForm);
            ViewBag.IdPriceList = new SelectList(db.PriceLists, "IdPriceList", "NamePriceList", detailForm.IdPriceList);
            return View(detailForm);
        }

        // GET: DetailForms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DetailForm detailForm = db.DetailForms.Find(id);
            if (detailForm == null)
            {
                return HttpNotFound();
            }
            return View(detailForm);
        }

        // POST: DetailForms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DetailForm detailForm = db.DetailForms.Find(id);
            db.DetailForms.Remove(detailForm);
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
