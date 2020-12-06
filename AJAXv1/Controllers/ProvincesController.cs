using AJAXv1.Context;
using AJAXv1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AJAXv1.Controllers
{
    public class ProvincesController : Controller
    {
        MyContext myContext = new MyContext();

        // GET: Provinces
        public ActionResult Index()
        {
            return View(myContext.Provinces.ToList());
        }

        public JsonResult GetProvinces()
        {
            var result = myContext.Provinces.ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProvince(int id)
        {
            var result = myContext.Provinces.Find(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Post(Province province)
        {
            if (ModelState.IsValid)
            {
                if (province.Id > 0)
                {
                    myContext.Entry(province).State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    myContext.Provinces.Add(province);
                }
                myContext.SaveChanges();
                return Json(200, JsonRequestBehavior.AllowGet);
            }
            return Json(400, JsonRequestBehavior.AllowGet);
        }

                public JsonResult Edit(Province province)
        {
            var get = myContext.Provinces.Find(province.Id);
            if (get != null)
            {
                if(TryUpdateModel(get, "", new string[] { "Name" })){
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
            var get = myContext.Provinces.Find(id);
            if(get != null)
            {
                myContext.Provinces.Remove(get);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return Json(200, JsonRequestBehavior.AllowGet);
                return Json(400, JsonRequestBehavior.AllowGet);
            }
            return Json(404, JsonRequestBehavior.AllowGet);
        }
    }
}