using BloodBankMgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BloodBankMgmt.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        BloodBankEntities instance = new BloodBankEntities();

        public ActionResult StaffList()
        {
            return View(instance.StaffMembers.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")] StaffMember StaffDetails)
        {
            if (!ModelState.IsValid)
                return View();
            instance.StaffMembers.Add(StaffDetails);
            instance.SaveChanges();
            //Response.Redirect("StudentAdmission",true);
            return RedirectToAction("StaffList");

        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            var IdToEdit = (from m in instance.StaffMembers where m.id == id select m).First();
            return View(IdToEdit);
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(StaffMember IdToEdit)
        {
            var orignalRecord = (from m in instance.StaffMembers where m.id == IdToEdit.id select m).First();

            if (!ModelState.IsValid)
                return View(orignalRecord);
            instance.Entry(orignalRecord).CurrentValues.SetValues(IdToEdit);

            instance.SaveChanges();
            return RedirectToAction("StaffList");

        }

        // GET: Staff/Delete/5
        public ActionResult Delete(StaffMember IdToDel)
        {

            var d = instance.StaffMembers.Where(x => x.id == IdToDel.id).FirstOrDefault();
            instance.StaffMembers.Remove(d);
            instance.SaveChanges();
            return View("StaffList");
        }

        // POST: Staff/Delete/5
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
