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
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }
 

        private AppDbContext db = new AppDbContext();

        //Products/List
        public ActionResult List()
        {
            return Json(db.Products.ToList(), JsonRequestBehavior.AllowGet);
        }

        //Products/Get/2
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return Json(new JsonMessage("Failure", "Id is null"), JsonRequestBehavior.AllowGet);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return Json(new JsonMessage("Failure", "Id is not found"), JsonRequestBehavior.AllowGet);
            }
            return Json(product, JsonRequestBehavior.AllowGet);
        }

        //Products/Create
        public ActionResult Create([FromBody]Product product)
        {
            product.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return Json(new JsonMessage("Failure", "ModelState is not valid"), JsonRequestBehavior.AllowGet);
            }
            
            db.Products.Add(product);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }

            return Json(new JsonMessage("Success", "Product was created the new id is:" + product.Id), JsonRequestBehavior.AllowGet); //This  will add product id to this string
        }

        //Products/Remove
        public ActionResult Remove([FromBody] Product product)
        {
            Product product2 = db.Products.Find(product.Id);
            db.Products.Remove(product2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Product : " + product2.Id + product2.Name + " was deleted successfully"), JsonRequestBehavior.AllowGet);
        }

        //Products/Change
        public ActionResult Change([FromBody] Product product)
        {
            product.DateUpdated = DateTime.Now;
            if (product == null)
            {
                return Json(new JsonMessage("Failure", "The record has already been deleted,not found"), JsonRequestBehavior.AllowGet);
            }
            Product product2 = db.Products.Find(product.Id);
            product2.Id = product.Id;
            product2.VendorId = product.VendorId;
            product2.PartNumber = product.PartNumber;
            product2.Name = product.Name;
            product2.Price = product.Price;
            product2.Unit = product.Unit;
            product2.PhotoPath = product.PhotoPath;
            product2.Active = product.Active;
           

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return Json(new JsonMessage("Failure", ex.Message), JsonRequestBehavior.AllowGet);
            }
            return Json(new JsonMessage("Success", "Product " + product.Id + " " + product.Name + " was changed"), JsonRequestBehavior.AllowGet);



        }
    }
}