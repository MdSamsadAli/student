using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using collegeManagement.Models;
using System.Data.Entity;

namespace collegeManagement.Controllers
{
    public class StudentController : Controller
    {
        MainEntities db = new MainEntities();
        // GET: student
        public ActionResult Index()
        {
            var list = db.tbl_Student.ToList();
            return View(list);
        }

        public ActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNew(tbl_Student tbl_Student)
        {
            ViewBag.Message = "Add Successful";
            db.tbl_Student.Add(tbl_Student);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 

        public ActionResult Edit(int? id)
        {
            tbl_Student student = db.tbl_Student.Find(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(tbl_Student tbl_Student)
        {
            db.Entry(tbl_Student).State = EntityState.Modified;
            db.SaveChanges();
            ViewBag.Message = "Update Successful";
            //return View(tbl_Student);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            tbl_Student tbl_Student = db.tbl_Student.Find(id);
            return View(tbl_Student);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int? id)
        {
            tbl_Student old_data = db.tbl_Student.Find(id);
            db.tbl_Student.Remove(old_data);
            db.SaveChanges();
            //return View();
            return RedirectToAction("Index");
        }
    }
}