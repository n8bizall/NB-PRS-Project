using NB_PRS_Project.Models;
using NB_PRS_Project.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Utility;

namespace NB_PRS_Project.Controllers
{
    public class VendorsController : Controller
    {
        // GET: Vendors
        public ActionResult Index()
        {
            return View();
        }
        

        private AppDbContext db = new AppDbContext();

        //Vendors/List
        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Vendors.ToList() };
        }

        //Vendors/Get/2
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is null") };
            }
            Vendor vendor = db.Vendors.Find(id);
            if (vendor == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is not found") };
            }
            return new JsonNetResult { Data = vendor };
        }

        //Vendors/Create
        public ActionResult Create([FromBody]Vendor vendor)
        {
            if (vendor.Code == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "The record can not be found") };
            }

            vendor.DateCreated = DateTime.Now;
       


            if (!ModelState.IsValid)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "ModelState is not valid") };
            }
            DateTime DateCreated = DateTime.Now;
            db.Vendors.Add(vendor);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new JsonMessage("Success", "Vendor was created the new id is:" + vendor.Id) }; //This  will add user id to this string
        }

        //Vendors/Remove
        public ActionResult Remove([FromBody] Vendor vendor)
        {
            if (vendor.Code == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "The record has already been deleted,not found") };
            }

            Vendor vendor2 = db.Vendors.Find(vendor.Id);
            db.Vendors .Remove(vendor2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new JsonMessage("Success", "Vendor " + vendor2.Id + " " + (vendor2.Code + " " + vendor2.Name) + " was deleted successfully") };
        }

        //Vendors/Change
        public ActionResult Change([FromBody] Vendor vendor)
        {
            vendor.DateUpdated = DateTime.Now;
            DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            if (vendor.Code == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "The record has already been deleted,not found") };
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
           // vendor2.UpdatedByUser = vendor.UpdatedByUser;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new JsonMessage("Success", "Vendor " + vendor.Id + " " + (vendor.Code + " " + vendor.Name) + " was changed") };
        
        //TODO create a method that will print out the purchase order

    }
    }
}