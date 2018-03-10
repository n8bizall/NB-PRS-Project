using NB_PRS_Project.Models;
using NB_PRS_Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace NB_PRS_Project.Controllers
{
    public class VendorsController : Controller
    {
        // GET: Vendors
        public ActionResult Index()
        {
            return View();
        }
        

        public AppDbContext db = new AppDbContext();

        //Vendors/List
        public ActionResult List()
        {
            return Json(db.Vendors.ToList(), JsonRequestBehavior.AllowGet);
        }

        //Vendors/Get/2
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(vendor, JsonRequestBehavior.AllowGet);
        }

        //Vendors/Create
        public ActionResult Create([FromBody]Vendor vendor)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.Vendors.Add(vendor);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }

            return Json(new JsonMessage("Success", "Vendor was created the new id is:" + vendor.Id), JsonRequestBehavior.AllowGet); //This  will add vendor id to this string
        }

        //Vendors/Remove
        public ActionResult Remove([FromBody] Vendor vendor)
        {
            Vendor vendor2 = db.Vendors.Find(vendor.Id);
            db.Vendors .Remove(vendor2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Vendor : " + vendor2.Id + " " + vendor2.Name + " was deleted successfully"), JsonRequestBehavior.AllowGet);
        }

        //Vendors/Change
        public ActionResult Change([FromBody] Vendor vendor)
        {
            if (vendor == null)
            {
                return Json(new JsonMessage("Failure", "The record has already been deleted,not found"), JsonRequestBehavior.AllowGet);
            }
            Vendor vendor2 = db.Vendors.Find(vendor.Id);
            vendor2.Id = vendor.Id;
            vendor2.Code = vendor.Code;
            vendor2.Name = vendor.Name;
            vendor2.Address = vendor.Address;
            vendor2.City = vendor.City;
            vendor2.State = vendor.State;
            vendor2.Zip = vendor.Zip;
            vendor2.Email = vendor.Email;
            vendor2.IsPreApproved= vendor.IsPreApproved;
            vendor2.IsActive = vendor.IsActive;
            vendor2.DateCreated = vendor.DateCreated;
            vendor2.DateUpdated = vendor.DateUpdated;
            vendor2.UpdatedByUser = vendor.UpdatedByUser;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Vendor " + vendor.Id + " " + vendor.Name + " was changed"), JsonRequestBehavior.AllowGet);



        }
    }
}