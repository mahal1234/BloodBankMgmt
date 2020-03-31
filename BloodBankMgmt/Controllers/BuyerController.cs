using BloodBankMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBankMgmt.Controllers
{
    public class BuyerController : Controller
    {
        // GET: Buyer
        BloodBankEntities instance = new BloodBankEntities();

        public ActionResult AllBuyer()
        {
            return View(instance.Buyers.ToList());
        }

        // GET: Buyer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Buyer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buyer/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Buyer BuyerDetails)
        {
            if (!ModelState.IsValid)
                return View();
            instance.Buyers.Add(BuyerDetails);
            instance.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("AllBuyer");

        }

        // GET: Buyer/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance.Buyers where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Buyer/Edit/5
        [HttpPost]
        public ActionResult Edit(Buyer IdToEdit)
        {
            var orignalRecord = (from m in instance.Buyers where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance.SaveChanges();
            return RedirectToAction("AllBuyer");
        }

        // GET: Buyer/Delete/5
        public ActionResult Delete(Buyer IdToDel)
        {
            var d = instance.Buyers.Where(x => x.id == IdToDel.id).FirstOrDefault();
            instance.Buyers.Remove(d);
            instance.SaveChanges();
            return View("AllBuyer");
        }

        // POST: Buyer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
