using BloodBankMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBankMgmt.Controllers
{
    public class QueryController : Controller
    {
        // GET: Query
        BloodBankEntities instance = new BloodBankEntities();

        public ActionResult AllQuery()
        {
            return View(instance.Contacts.ToList());
        }

        // GET: Query/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Query/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Query/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Query/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Query/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Query/Delete/5
        public ActionResult Delete(Contact IdToDel)
        {
            var d = instance.Contacts.Where(x => x.id == IdToDel.id).FirstOrDefault();
            instance.Contacts.Remove(d);
            instance.SaveChanges();
            return RedirectToAction("AllQuery");
        }

        // POST: Query/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            return View("AllQuery");
        }
    }
}
