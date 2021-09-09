using ADMPublishers.DataAccess;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADMPublishers.Controllers
{
    public class PublishersController : Controller
    {
        PublisherContext Db { get; set; }
        public PublishersController(PublisherContext db)
        {
            Db = db;
        }
        [HttpGet]
        public ActionResult CaptureAuthor()
        {
            Authors author = new Authors();
            return View(author);
        }
        [HttpPost]
        public ActionResult CaptureAuthor(Authors model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                
                Db.Authors.Add(model);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();

            }
        }
        [HttpGet]
        public ActionResult Edit(string AuthorId)
        {
            var author = Db.Authors.Find(AuthorId);
            return View(author);
        }
        [HttpPost]
        public ActionResult Edit(Authors model)
        {
            if (!ModelState.IsValid) return View(model);
            try
            {
                Db.Authors.Update(model);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception )
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(string AuthorId)
        {
            var author = Db.Authors.Find(AuthorId);
            return View(author);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmation(string AuthorId, Authors author)
        {
            var target = Db.Authors.Find(AuthorId);
            Db.Remove(target);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Index()
        {
            var authors = Db.Authors.ToList();
            return View(authors);
        }

        // GET: PublishersController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PublishersController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublishersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PublishersController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PublishersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PublishersController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PublishersController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
