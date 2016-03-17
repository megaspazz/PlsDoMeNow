using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlsDoMeNow.Models;

namespace PlsDoMeNow.Controllers
{
    public class TodoListCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TodoListCategories
        public ActionResult Index()
        {
            return View(db.TodoListCategories.ToList());
        }

        // GET: TodoListCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoListCategory todoListCategory = db.TodoListCategories.Find(id);
            if (todoListCategory == null)
            {
                return HttpNotFound();
            }
            return View(todoListCategory);
        }

        // GET: TodoListCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TodoListCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TodoListCategory todoListCategory)
        {
            if (ModelState.IsValid)
            {
                db.TodoListCategories.Add(todoListCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todoListCategory);
        }

        // GET: TodoListCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoListCategory todoListCategory = db.TodoListCategories.Find(id);
            if (todoListCategory == null)
            {
                return HttpNotFound();
            }
            return View(todoListCategory);
        }

        // POST: TodoListCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TodoListCategory todoListCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todoListCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todoListCategory);
        }

        // GET: TodoListCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TodoListCategory todoListCategory = db.TodoListCategories.Find(id);
            if (todoListCategory == null)
            {
                return HttpNotFound();
            }
            return View(todoListCategory);
        }

        // POST: TodoListCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TodoListCategory todoListCategory = db.TodoListCategories.Find(id);
            db.TodoListCategories.Remove(todoListCategory);
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
