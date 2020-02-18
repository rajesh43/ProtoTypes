using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConferenceMVC.Models;

namespace ConferenceMVC.Controllers
{
    public class ConferenceController : Controller
    {
        // GET: Conference
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            using (ConferenceDBModel db = new ConferenceDBModel())
            {

                List<Conference> conflst = db.Conferences.ToList<Conference>();
                return Json(new { data = conflst }, JsonRequestBehavior.AllowGet);






            }
        }
        [HttpGet]
        public ActionResult AddOrEdit(int id=0)
        {


            if (id == 0)
            {

                return View(new Conference());

            }
            else
            {
                using (ConferenceDBModel db = new ConferenceDBModel())
                {
                    return View(db.Conferences.Where(x=>x.ID==id).FirstOrDefault<Conference>());

                }
            }
           

        }

        [HttpPost]
        public ActionResult AddOrEdit(Conference conf)
        {

            if (conf.ImageUpload!=null)
            {

                string fileName = Path.GetFileNameWithoutExtension(conf.ImageUpload.FileName);
                string extension = Path.GetExtension(conf.ImageUpload.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                conf.ImageLink = "~/App_Files/Images/" + fileName;
                conf.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/App_Files/Images/"),fileName));


            }
            using (ConferenceDBModel db=new ConferenceDBModel())
            {
                if (conf.ID == 0)
                {
                    db.Conferences.Add(conf);
                    db.SaveChanges();
                    return Json(new { success = true, message = "Saved Successfully" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    db.Entry(conf).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Json(new { success = true, message = "Updated Successfully" }, JsonRequestBehavior.AllowGet);


                }

               
            }

         

        }


        [HttpPost]

        public ActionResult Delete(int id)
        {
            using (ConferenceDBModel db = new ConferenceDBModel())
            {
                Conference c = db.Conferences.Where(x => x.ID == id).FirstOrDefault<Conference>();
                db.Conferences.Remove(c);
                db.SaveChanges();

            }

            return Json(new { success = true, message = "Deleted Successfully" }, JsonRequestBehavior.AllowGet);
        }

    }
}