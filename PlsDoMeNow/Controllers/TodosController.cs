using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using PlsDoMeNow.Models;

using Newtonsoft.Json;

namespace PlsDoMeNow.Controllers
{
    public class TodosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Todos
        public ActionResult Index()
        {
            return View(db.Todos.ToList());
        }

        // GET: Todos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // GET: Todos/Create
        public ActionResult Create()
		{
			ViewBag.TodoLists = TodoList.GetCurrentUserLists();
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,DueDate,Importance,List")] Todo todo)
		{
			string userID = ApplicationUser.GetCurrentUserID();
			TodoList list = db.TodoLists.Find(todo.List.ID);
			if (list == null || list.Category.Owner.Id != userID)
			{
				// TODO: Error message for invalid list
				ViewBag.TodoLists = TodoList.GetCurrentUserLists();
				return View(todo);
			}
			todo.List = list;
			ModelState.Clear();
			TryValidateModel(todo);

            if (ModelState.IsValid)
            {
                db.Todos.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

			// TODO: Error message for failed validation
			ViewBag.TodoLists = TodoList.GetCurrentUserLists();
            return View(todo);
        }

        // GET: Todos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,DueDate,Importance")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(todo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        // GET: Todos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Todo todo = db.Todos.Find(id);
            db.Todos.Remove(todo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: TodoLists/NewList
        public string NewTodo(int listID, string name, string description, DateTime? dueDate, double? importance)
        {
            string userID = ApplicationUser.GetCurrentUserID();
            TodoList list = db.TodoLists.Find(listID);
            if (list == null || list.Category.Owner.Id != userID)
            {
                return null;    // or throw exception
            }

            Todo todo = new Todo()
            {
                List = list,
                Name = name,
                Description = description,
                DueDate = dueDate,
                Importance = importance
            };
            
            ModelState.Clear();
            TryValidateModel(todo);

            if (ModelState.IsValid)
            {
                db.Todos.Add(todo);
                db.SaveChanges();
                return JsonConvert.SerializeObject(todo);
            }

            return null;    // or throw exception
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
