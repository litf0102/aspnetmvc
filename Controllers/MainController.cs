using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using aspnetmvc2.Filters;
using aspnetmvc2.Helper;
using aspnetmvc2.Models;

namespace aspnetmvc2.Controllers
{
    [Localization]
    [ActionAuthorize]
    public class MainController : Controller
    {
        private DbTESTEntities db = new DbTESTEntities();

        // GET: Main
        public ActionResult Index()
        {
            return View(db.MOVIES.ToList());
        }

        // GET: Main/Reload
        public JsonResult Reload()
        {
            try
            {
                string sql = "SELECT Id,Title,Director FROM MOVIES;";
                var result = db.Database.SqlQuery<MOVIES>(sql);
                foreach (MOVIES item in result)
                {
                    Console.WriteLine(item.Id + ":" + item.Title);
                }

                return Json(result.ToList(), JsonRequestBehavior.AllowGet);
            } catch (Exception ex)
            {
                LogHelper.Default.WriteError("Reload failed.", ex);
                throw ex;
            }
        }

        // GET: Main/Reload
        public JsonResult Reload2()
        {
            try
            {
                string sql = "SELECT a.ID,a.NAME,a.SEX,b.DEPT_NAME FROM EMP a INNER JOIN DEPT b ON a.DEPT_CD = b.DEPT_CD;";
                var result = db.Database.SqlQuery<EmpDetail>(sql);

                return Json(result.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                LogHelper.Default.WriteError("Reload failed.", ex);
                throw ex;
            }
        }

        // GET: Main/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIES mOVIES = db.MOVIES.Find(id);
            if (mOVIES == null)
            {
                return HttpNotFound();
            }
            return View(mOVIES);
        }

        // GET: Main/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Main/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Director")] MOVIES mOVIES)
        {
            if (ModelState.IsValid)
            {
                db.MOVIES.Add(mOVIES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mOVIES);
        }

        // GET: Main/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIES mOVIES = db.MOVIES.Find(id);
            if (mOVIES == null)
            {
                return HttpNotFound();
            }
            return View(mOVIES);
        }

        // POST: Main/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Director")] MOVIES mOVIES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mOVIES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mOVIES);
        }

        // GET: Main/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MOVIES mOVIES = db.MOVIES.Find(id);
            if (mOVIES == null)
            {
                return HttpNotFound();
            }
            return View(mOVIES);
        }

        // POST: Main/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MOVIES mOVIES = db.MOVIES.Find(id);
            db.MOVIES.Remove(mOVIES);
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
