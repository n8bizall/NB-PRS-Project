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
    public class PurchaseRequestLineItemsController : Controller
    {
        // GET: PurchaseRequestLineItems
        public ActionResult Index()
        {
            return View();
        }

        public AppDbContext db = new AppDbContext();

        //public decimal TotalLineValue = (PurchaseRequestLineItem.Price * PurchaseRequestLineItem.Quantity);


        //PurchaseRequestLineItems/List
        public ActionResult List()
        {
            return Json(db.PurchaseRequestLineItems.ToList(), JsonRequestBehavior.AllowGet);
        }

        //PurchaseRequestLineItems/Get/2
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            PurchaseRequestLineItem purchaseRequestLineItem = db.PurchaseRequestLineItems.Find(id);
            if (purchaseRequestLineItem == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(purchaseRequestLineItem, JsonRequestBehavior.AllowGet);
        }

        //PurchaseRequestLineItems/Create
        public ActionResult Create([FromBody]PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            db.PurchaseRequestLineItems.Add(purchaseRequestLineItem);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }

            return Json(new JsonMessage("Success", "PurchaseRequestLineItem was created the new id is:" + purchaseRequestLineItem.Id), JsonRequestBehavior.AllowGet); //This  will add product id to this string
        }

        //PurchaseRequestLineItems/Remove
        public ActionResult Remove([FromBody] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            PurchaseRequestLineItem purchaseRequestLineItem2 = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            db.PurchaseRequestLineItems.Remove(purchaseRequestLineItem2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PurchaseRequestLineItem : " + purchaseRequestLineItem2.Id +  " was deleted successfully"), JsonRequestBehavior.AllowGet);
        }

        //PurchaseRequestLineItems/Change
        public ActionResult Change([FromBody] PurchaseRequestLineItem purchaseRequestLineItem)
        {
            if (purchaseRequestLineItem == null)
            {
                return Json(new JsonMessage("Failure", "The record has already been deleted,not found"), JsonRequestBehavior.AllowGet);
            }
            PurchaseRequestLineItem purchaseRequestLineItem2 = db.PurchaseRequestLineItems.Find(purchaseRequestLineItem.Id);
            purchaseRequestLineItem2.Id = purchaseRequestLineItem.Id;
            purchaseRequestLineItem2.PurchaseRequestId = purchaseRequestLineItem.PurchaseRequestId;
            purchaseRequestLineItem2.ProductId = purchaseRequestLineItem.ProductId;
            purchaseRequestLineItem2.Quantity = purchaseRequestLineItem.Quantity;
            purchaseRequestLineItem2.Price = purchaseRequestLineItem.Price;
            purchaseRequestLineItem2.LineTotal = purchaseRequestLineItem.LineTotal;

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "PurchaseRequestLineItem" + purchaseRequestLineItem.Id + " was changed"), JsonRequestBehavior.AllowGet);



        }

    }
}