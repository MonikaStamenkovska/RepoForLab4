using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab3.Models;

namespace Lab3.Controllers
{
    public class FriendModelsController : Controller
    {
        private FriendsContext db = new FriendsContext();

        // GET: FriendModels
        public ActionResult Index()
        {
            return View(db.Friends.ToList());
        }

        // GET: FriendModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendModel friendModel = db.Friends.Find(id);
            if (friendModel == null)
            {
                return HttpNotFound();
            }
            return View(friendModel);
        }

        // GET: FriendModels/Create
        public ActionResult Create()
        {
            var model = new FriendModel();
            return View(model);
        }

        // POST: FriendModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Ime,MestoZiveenje")] FriendModel friendModel)
        {
            if (ModelState.IsValid)
            {
                var fm = db.Friends.FirstOrDefault(f => f.Id == friendModel.Id);
                if (fm == null)
                {
                    db.Friends.Add(friendModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(friendModel);
            }
            return View(friendModel);
        }

        // GET: FriendModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FriendModel friendModel = db.Friends.Find(id);
            if (friendModel == null)
            {
                return HttpNotFound();
            }
            return View(friendModel);
        }

        // POST: FriendModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Ime,MestoZiveenje")] FriendModel friendModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friendModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friendModel);
        }

     
        public ActionResult Delete(int id)
        {
            FriendModel friendModel = db.Friends.Find(id);
            db.Friends.Remove(friendModel);
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
