using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnTap_LTDN.Models;

namespace OnTap_LTDN.Controllers
{
    public class DiemController : Controller
    {
        private QLSVDataContext db = new QLSVDataContext();

        // GET: Diem
        public ActionResult Index(string searchString)
        {
            var diems = db.Diems.Include(d => d.SinhVien);
            if(!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.Trim().ToLower();
                diems = diems.Where(d=> d.SinhVien.hoten.Trim().ToLower().Contains(searchString));
            }
            return View(diems.ToList());
        }

        // GET: Diem/Details/5
        public ActionResult Details(int? id, string tenmh)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id, tenmh);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // GET: Diem/Create
        public ActionResult Create()
        {
            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten");
            return View();
        }

        // POST: Diem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "masv,tenmh,diem1")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Diems.Add(diem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten", diem.masv);
            return View(diem);
        }

        // GET: Diem/Edit/5
        public ActionResult Edit(int? id, string tenmh)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id, tenmh);
            if (diem == null)
            {
                return HttpNotFound();
            }
            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten", diem.masv);
            return View(diem);
        }

        // POST: Diem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "masv,tenmh,diem1")] Diem diem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.masv = new SelectList(db.SinhViens, "masv", "hoten", diem.masv);
            return View(diem);
        }

        // GET: Diem/Delete/5
        public ActionResult Delete(int? id, string tenmh)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diem diem = db.Diems.Find(id, tenmh);
            if (diem == null)
            {
                return HttpNotFound();
            }
            return View(diem);
        }

        // POST: Diem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, string tenmh)
        {
            Diem diem = db.Diems.Find(id, tenmh);
            db.Diems.Remove(diem);
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
