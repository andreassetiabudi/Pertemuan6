using AJAXv1.Context;
using AJAXv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAXv1.Controllers
{
    public class SuppliersController : Controller
    {
        MyContext myContext = new MyContext();

        // GET: Suppliers
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>();
            suppliers = myContext.Suppliers.ToList();
            return Json(suppliers, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSupplier(int id)
        {
            var supplier = new Supplier();
            supplier = myContext.Suppliers.Find(id);
            return Json(supplier, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Post(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                if (supplier.Id > 0)
                {
                    myContext.Entry(supplier).State = System.Data.Entity.EntityState.Modified;
                }
                else { 
                    myContext.Suppliers.Add(supplier);
            }
            myContext.SaveChanges();
            return Json(200, JsonRequestBehavior.AllowGet);
        }
            return Json(400, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(Supplier supplier)
        {
            var get = myContext.Suppliers.Find(supplier.Id);
            if (get != null)
            {
                if (TryUpdateModel(get, "", new string[] { "Name" }))
                {
                    myContext.SaveChanges();
                    return Json(200, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(400, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(400, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(int id)
        {
            var get = myContext.Suppliers.Find(id);
            if(get != null)
            {
                myContext.Suppliers.Remove(get);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return Json(200, JsonRequestBehavior.AllowGet);
            } 
            else
            {
                return Json(404, JsonRequestBehavior.AllowGet);
            }
            return Json(400, JsonRequestBehavior.AllowGet);
        }
    }
}