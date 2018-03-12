using NB_PRS_Project.Models;
using NB_PRS_Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using static NB_PRS_Project.Models.PurchaseRequest;
using static NB_PRS_Project.Models.PurchaseRequestLineItem;

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

        //var id = 1;
        //var query = PurchaseRequest.Total    // your starting point - table in the "from" statement
        //   .Join(PurchaseRequest.Post_Metas, // the source table of the inner join
        //      post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
        //      meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
        //      (post, meta) => new { Post = post, Meta = meta }) // selection
        //   .Where(postAndMeta => postAndMeta.Post.ID == id);    // where statement



        //PurchaseRequestLineItem PurchaseRequestLineItem = new PurchaseRequestLineItem();
        //PurchaseRequest PurchaseRequest = new PurchaseRequest();
        //List<PurchaseRequestLineItem> list = new List<PurchaseRequestLineItem>();

        //using(PurchaseRequestLineItem db = new PurchaseRequestLineItem()){
        //  foreach(var PurchaseRequestLineItem in PurchaseRequestLineItems)
  





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
            purchaseRequestLineItem.DateCreated = DateTime.Now;

            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            
            //foreach (PurchaseRequestLineItem prli in purchaseRequestLineItem)
            //{
            //    foreach(Product p in products)
            //}


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

            purchaseRequestLineItem.DateUpdated = DateTime.Now;

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
            purchaseRequestLineItem2.Active = purchaseRequestLineItem.Active;
            purchaseRequestLineItem2.UpdatedByUser = purchaseRequestLineItem.UpdatedByUser;
        

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