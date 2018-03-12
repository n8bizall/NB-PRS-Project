using NB_PRS_Project.Models;
using NB_PRS_Project.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace NB_PRS_Project.Controllers
{
    public class PurchaseRequestsController : Controller
    {
        // GET: PurchaseRequests
        public ActionResult Index()
        {
            return View();
        }

        public AppDbContext db = new AppDbContext();
       



        // var sumLT = DbContext.PurchaseRequestLineItem.Where(e => e.Id == 2015).Sum(ep => ep.NoOfPeople * ep.Hours);

        // group new { purchaseRequestLineItems, invoice, product
        // }
        //  by new
        //{
        //  invoice.InvoiceId,
        //  company.CompanyId
        //   }
        //  into g
        //select new 
        //{
        //     Sum = g.Sum(o => o.invoice.Quantity* o.product.Rate)
        // }

        //PurchaseRequests/List
        public ActionResult List()
        {
            return Json(db.PurchaseRequests.ToList(), JsonRequestBehavior.AllowGet);
        }

        //PurchaseRequests/Get/2
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(purchaseRequest, JsonRequestBehavior.AllowGet);
        }

        //PurchaseRequests/Create
        public ActionResult Create([FromBody]PurchaseRequest purchaseRequest)
        { 


            purchaseRequest.DateCreated = DateTime.Now;

            

            //public List<PurchaseRequestLineItem> prliList;







            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.PurchaseRequests.Add(purchaseRequest);
           
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.InnerException.Message), JsonRequestBehavior.AllowGet);
            }

            return Json(new JsonMessage("Success", "PurchaseRequest was created the new id is:" + purchaseRequest.Id), JsonRequestBehavior.AllowGet); //This  will add product id to this string
        }

     
        //PurchaseRequests/Remove
        public ActionResult Remove([FromBody] PurchaseRequest purchaseRequest)
        {
            PurchaseRequest purchaseRequest2 = db.PurchaseRequests.Find(purchaseRequest.Id);
            db.PurchaseRequests.Remove(purchaseRequest2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PurchaseRequest : " + purchaseRequest2.Id + " was deleted successfully"), JsonRequestBehavior.AllowGet);
        }

        //PurchaseRequests/Change
        public ActionResult Change([FromBody] PurchaseRequest purchaseRequest)
        {
            purchaseRequest.DateCreated = DateTime.Now;

            if (purchaseRequest== null)
            {
                return Json(new JsonMessage("Failure", "The record has already been deleted,not found"), JsonRequestBehavior.AllowGet);
            }
            PurchaseRequest purchaseRequest2 = db.PurchaseRequests.Find(purchaseRequest.Id);
            purchaseRequest2.Id = purchaseRequest.Id;
            purchaseRequest2.UserId = purchaseRequest.UserId;
            purchaseRequest2.Description = purchaseRequest.Description;
            purchaseRequest2.Justification = purchaseRequest.Justification;
            purchaseRequest2.DeliveryMode = purchaseRequest.DeliveryMode;
            purchaseRequest2.Status = purchaseRequest.Status;
            purchaseRequest2.Total = purchaseRequest.Total;
            purchaseRequest2.Active = purchaseRequest.Active;
            purchaseRequest2.ReasonForRejection = purchaseRequest.ReasonForRejection;
            purchaseRequest2.UpdatedByUser = purchaseRequest.UpdatedByUser;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PurchaseRequest: " + purchaseRequest.Id + " was changed"), JsonRequestBehavior.AllowGet);



        }

    }
}
