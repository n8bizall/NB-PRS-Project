using NB_PRS_Project.Models;
using NB_PRS_Project.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Utility;

namespace NB_PRS_Project.Controllers
{
    public class PurchaseRequestsController : Controller
    {
        // GET: PurchaseRequests
        public ActionResult Index()
        {
            return View();
        }

        private AppDbContext db = new AppDbContext();
       

        //PurchaseRequests/List
        public ActionResult List()
        {
            //return Json(db.PurchaseRequests.ToList(), JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = db.PurchaseRequests.ToList() };
        }
        public ActionResult ReviewList()
        {
            return new JsonNetResult { Data = db.PurchaseRequests.ToList().Where(P => P.Status == "REVIEW") };
        }
            //PurchaseRequests/Get/2
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is null") };
            }
            PurchaseRequest purchaseRequest = db.PurchaseRequests.Find(id);
            if (purchaseRequest == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is not found") };
            }
           
            return new JsonNetResult { Data = purchaseRequest};
        }

        //PurchaseRequests/Create
        public ActionResult Create([FromBody]PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest.Description == null) return new EmptyResult();
            purchaseRequest.DateCreated = DateTime.Now;

            if (!ModelState.IsValid)
            {
                var errorMessages = ModelStateErrors.GetModelStateErrors(ModelState);
                return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "ModelState invalid.", Data = errorMessages } };
            }

      
            db.PurchaseRequests.Add(purchaseRequest);
           
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new Msg { Result = "Success", Message = "Purchase Request was created the new id is:" + purchaseRequest.Id, Data = purchaseRequest } }; //This  will add user id to this string
        }


        //PurchaseRequests/Remove
        public ActionResult Remove([FromBody] PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest.Description == null) return new EmptyResult();
            PurchaseRequest purchaseRequest2 = db.PurchaseRequests.Find(purchaseRequest.Id);
            db.PurchaseRequests.Remove(purchaseRequest2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new JsonMessage("Success", "Purchase Request " + purchaseRequest2.Id  + " was deleted successfully") };
        }

        //PurchaseRequests/Change
        public ActionResult Change([FromBody] PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest.Description == null) return new EmptyResult();
            purchaseRequest.DateCreated = DateTime.Now;

            if (purchaseRequest== null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "The record has already been deleted,not found") };
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
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new JsonMessage("Success", "Purchase Request " + purchaseRequest.Id + " was changed") };
        }

    }
}
