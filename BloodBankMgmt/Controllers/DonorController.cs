using BloodBankMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBankMgmt.Controllers
{
    public class DonorController : Controller
    {
        // GET: Donor
        BloodBankEntities instance = new BloodBankEntities();

        public ActionResult AllDonor()
        {
            return View(instance.Donors.ToList());
        }

        // GET: Donor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Donor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Donor/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] Donor donorDetails)
        {

            if (!ModelState.IsValid)
                return View();
            instance.Donors.Add(donorDetails);
            instance.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("AllDonor");
        }

        // GET: Donor/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance.Donors where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Donor/Edit/5
        [HttpPost]
        public ActionResult Edit(Donor IdToEdit)
        {
            var orignalRecord = (from m in instance.Donors where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance.SaveChanges();
            return RedirectToAction("AllDonor");

        }

        // GET: Donor/Delete/5
        public ActionResult Delete(Donor IdToDel)
        {
            var d = instance.Donors.Where(x => x.id == IdToDel.id).FirstOrDefault();
            instance.Donors.Remove(d);
            instance.SaveChanges();
            return View("AllDonor");
        }

        // POST: Donor/Delete/5
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
