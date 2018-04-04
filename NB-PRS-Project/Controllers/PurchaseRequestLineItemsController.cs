using NB_PRS_Project.Models;
using NB_PRS_Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Utility;
using static NB_PRS_Project.Models.PurchaseRequest;
using static NB_PRS_Project.Models.PurchaseRequestLineItem;

namespace NB_PRS_Project.Controllers
{
    public class PurchaseRequestLineItemsController : Controller
    {
      

        private AppDbContext db = new AppDbContext();

        private void UpdateTotal(int id)
        {
            db = new AppDbContext();
           var purchaseRequest = db.PurchaseRequests.Find(id);
            purchaseRequest.Total = db.PurchaseRequestLineItems.Where(pl => pl.PurchaseRequestId == purchaseRequest.Id).Sum(p => p.Product.Price * p.Quantity);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        //PurchaseRequestLineItems/List
        public ActionResult List()
        {
            //return Json(db.PurchaseRequestLineItems.ToList(), JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = db.PurchaseRequestLineItems.ToList() };
        }

        //PurchaseRequestLineItems/Get/2
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is null") };
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is not found") };
            }
            UpdateTotal(purchaseRequestLineItem.PurchaseRequestId);



            //return Json(purchaseRequestLineItem, JsonRequestBehavior.AllowGet);
            return new JsonNetResult { Data = purchaseRequestLineItem };
        } 

        //PurchaseRequestLineItems/Create
        public ActionResult Create([FromBody]PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (purchaseRequestLineItem.ProductId == 0) return new EmptyResult();

            purchaseRequestLineItem.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelStateErrors.GetModelStateErrors(ModelState);
                return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "ModelState invalid.", Data = errorMessages } };
            }

          
            
                db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            UpdateTotal(purchaseRequestLineItem.PurchaseRequestId);

            return new JsonNetResult { Data = new JsonMessage("Success", "Purchase Request line item was created the new id is:" + purchaseRequestLineItem.Id) }; //This  will add user id to this string
        }

        //PurchaseRequestLineItems/Remove
        public ActionResult Remove([FromBody] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (purchaseRequestLineItem.Product == null) return new EmptyResult();
            PurchaseRequestLineItem purchaseRequestLineItem2 = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            db.PurchaseRequestLineItems.Remove(purchaseRequestLineItem2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            UpdateTotal(purchaseRequestLineItem.PurchaseRequestId);

            return new JsonNetResult { Data = new JsonMessage("Success", "Purchase Request line item " + purchaseRequestLineItem2.Id + " was deleted successfully") };

            ;
        }

        //PurchaseRequestLineItems/Change
        public ActionResult Change([FromBody] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (purchaseRequestLineItem.Product == null) return new EmptyResult();
            purchaseRequestLineItem.DateUpdated = DateTime.Now;
            purchaseRequestLineItem.Product = null;

            if (!ModelState.IsValid)
            {
                var errorMessages = ModelStateErrors.GetModelStateErrors(ModelState);
                return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "ModelState invalid.", Data = errorMessages } };
            }

            if (purchaseRequestLineItem == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "The record has already been deleted,not found") };
            }
            PurchaseRequestLineItem purchaseRequestLineItem2 = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            purchaseRequestLineItem2.Id = purchaseRequestLineItem.Id;
            purchaseRequestLineItem2.PurchaseRequestId = purchaseRequestLineItem.PurchaseRequestId;
            purchaseRequestLineItem2.ProductId = purchaseRequestLineItem.ProductId;
            purchaseRequestLineItem2.Quantity = purchaseRequestLineItem.Quantity;
            purchaseRequestLineItem2.Active = purchaseRequestLineItem.Active;
            purchaseRequestLineItem2.UpdatedByUser = purchaseRequestLineItem.UpdatedByUser;
            purchaseRequestLineItem2.Product = purchaseRequestLineItem.Product;
        

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            UpdateTotal(purchaseRequestLineItem.PurchaseRequestId);
            return new JsonNetResult
            {
                Data = new JsonMessage("Success", "Purchase Request line item " + purchaseRequestLineItem.Id + " was changed")
            };




            }
        
    }
    
}