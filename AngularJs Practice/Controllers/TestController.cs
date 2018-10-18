using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using AngularJs_Practice.Models;

namespace AngularJs_Practice.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetUserInfo()
        {
            List<Table>tables=new  List<Table>();
            using (MyDatabaseEntities db=new MyDatabaseEntities())
            {
                tables = db.Tables.ToList();
            }

            return Json(tables, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddNewUser(EmployeeVm model)
        {
            if (!ModelState.IsValid) return Json(model, JsonRequestBehavior.AllowGet);
            Table emp = new Table();

            using (MyDatabaseEntities db=new MyDatabaseEntities())
            {
                emp.FirstName = model.FirstName;
                emp.LastName = model.LastName;
                emp.ContactNo1 = model.ContactNo1;
                emp.ContactNo2 = model.ContactNo2;
                emp.Address = model.Address;
                emp.Email = model.Email;

                db.Tables.Add(emp);
                db.SaveChanges();
            }

            return Json(model, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult EditUserInfo(EmployeeVm model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            using (MyDatabaseEntities db=new MyDatabaseEntities())
            {
                Table emp = db.Tables.SingleOrDefault(x => x.Id == model.Id);

                emp.FirstName = model.FirstName;
                emp.LastName = model.LastName;
                emp.ContactNo1 = model.ContactNo1;
                emp.ContactNo2 = model.ContactNo2;
                emp.Address = model.Address;
                emp.Email = model.Email;
                db.SaveChanges();
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteUserInfo(EmployeeVm model)
        {
            if (!ModelState.IsValid) return Json(model, JsonRequestBehavior.AllowGet);
            using (MyDatabaseEntities db=new MyDatabaseEntities())
            {
                Table emp = db.Tables.SingleOrDefault(x=>x.Id==model.Id);
                if (emp != null) db.Tables.Remove(emp);
                db.SaveChanges();
                return Json(model, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult About()
        {
            return View();
        }

    }
}