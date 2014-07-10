using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyMVCHomeWork.Models;

namespace MyMVCHomeWork.Controllers
{
    public class CusBankContactQtyController : Controller
    {
        private 客戶資料Entities db = new 客戶資料Entities();

        // GET: CusBankContactQty
        public ActionResult Index()
        {
            return View(db.vw_CusBankContactQty.ToList());
        }

        // GET: CusBankContactQty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_CusBankContactQty vw_CusBankContactQty = db.vw_CusBankContactQty.Find(id);
            if (vw_CusBankContactQty == null)
            {
                return HttpNotFound();
            }
            return View(vw_CusBankContactQty);
        }

        // GET: CusBankContactQty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CusBankContactQty/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,客戶名稱,聯絡人數量,銀行帳戶數量")] vw_CusBankContactQty vw_CusBankContactQty)
        {
            if (ModelState.IsValid)
            {
                db.vw_CusBankContactQty.Add(vw_CusBankContactQty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vw_CusBankContactQty);
        }

        // GET: CusBankContactQty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_CusBankContactQty vw_CusBankContactQty = db.vw_CusBankContactQty.Find(id);
            if (vw_CusBankContactQty == null)
            {
                return HttpNotFound();
            }
            return View(vw_CusBankContactQty);
        }

        // POST: CusBankContactQty/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,客戶名稱,聯絡人數量,銀行帳戶數量")] vw_CusBankContactQty vw_CusBankContactQty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vw_CusBankContactQty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vw_CusBankContactQty);
        }

        // GET: CusBankContactQty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vw_CusBankContactQty vw_CusBankContactQty = db.vw_CusBankContactQty.Find(id);
            if (vw_CusBankContactQty == null)
            {
                return HttpNotFound();
            }
            return View(vw_CusBankContactQty);
        }

        // POST: CusBankContactQty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vw_CusBankContactQty vw_CusBankContactQty = db.vw_CusBankContactQty.Find(id);
            db.vw_CusBankContactQty.Remove(vw_CusBankContactQty);
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
