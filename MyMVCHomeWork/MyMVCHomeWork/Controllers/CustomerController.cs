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
    public class CustomerController : Controller
    {

        //1030709:原始方法
        //private 客戶資料Entities db = new 客戶資料Entities();

        private 客戶資料Repository CusRepo = RepositoryHelper.Get客戶資料Repository();
        

        // GET: /Customer/
        public ActionResult Index()
        {
            //1030709:原始方法
            //return View(db.客戶資料.ToList());
            return View(CusRepo.All().ToList());
        }

        // GET: /Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //1030709:原始方法
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //if (客戶資料 == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(客戶資料);


            //1030709:方法一
            //var cusData = CusRepo.All().Where(p => p.Id == id);
             //return View(cusData);

            //1030709:方法二
            客戶資料 客戶資料 = CusRepo.GetCusDataByID(id);
            return View(客戶資料);

        }

        // GET: /Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Customer/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,客戶名稱,統一編號,電話,傳真,地址,Email,IsDelete")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {
                //1030709:原始方法
                //db.客戶資料.Add(客戶資料);
                //db.SaveChanges();

                CusRepo.Add(客戶資料);
                CusRepo.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            return View(客戶資料);
        }

        // GET: /Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //1030709:原始方法
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //if (客戶資料 == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(客戶資料);

            //var cusData = CusRepo.All().Where(p => p.Id == id);

            //if (cusData == null)
            //{
            //    return HttpNotFound();
            //}

            //return View(cusData);



            客戶資料 客戶資料 = CusRepo.GetCusDataByID(id);
            if (客戶資料 == null)
            {
                return HttpNotFound();
            }

            return View(客戶資料);
        }

        // POST: /Customer/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,客戶名稱,統一編號,電話,傳真,地址,Email,IsDelete")] 客戶資料 客戶資料)
        {
            if (ModelState.IsValid)
            {

                //db.Entry(客戶資料).State = EntityState.Modified;
                //db.SaveChanges();

                CusRepo.UnitOfWork.Context.Entry(客戶資料).State = EntityState.Modified;
                CusRepo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }
            return View(客戶資料);
        }

        // GET: /Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //if (客戶資料 == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(客戶資料);

            //var cusData = CusRepo.All().Where(p => p.Id == id);

            //if (cusData == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(cusData);

           客戶資料 客戶資料 = CusRepo.GetCusDataByID(id);

           if (客戶資料 == null)
            {
                return HttpNotFound();
            }
           return View(客戶資料);



        }

        // POST: /Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //客戶資料 客戶資料 = db.客戶資料.Find(id);
            //db.客戶資料.Remove(客戶資料);
            //db.SaveChanges();

                客戶銀行資訊Repository BankRepo = RepositoryHelper.Get客戶銀行資訊Repository();
          客戶聯絡人Repository ContRepo = RepositoryHelper.Get客戶聯絡人Repository();
    
            //處理聯絡人資料
          var ContactData = ContRepo.GetCusContactByCusID(id);

          foreach (var item in ContactData)
          {
              item.IsDelete = true;
              
          }


            //處理銀行資料
          var BankData = BankRepo.GetBankDataByCusID(id);
          foreach (var item in BankData)
          {
              item.IsDelete = true;
          }




            //處理客戶主檔資料
            客戶資料 客戶資料 = CusRepo.GetCusDataByID(id);
            客戶資料.IsDelete = true;
            //CusRepo.Delete(客戶資料);

            ContRepo.UnitOfWork.Commit();
            BankRepo.UnitOfWork.Commit();
            CusRepo.UnitOfWork.Commit();

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //if (disposing)
            //{
               
            //}
            base.Dispose(disposing);
        }
    }
}
