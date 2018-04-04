using NB_PRS_Project.Models;
using NB_PRS_Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Utility;

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
            return new JsonNetResult { Data = db.Products.ToList() };
        }

        //Products/Get/2
        public ActionResult Get(int? id)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelStateErrors.GetModelStateErrors(ModelState);
                return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "ModelState invalid.", Data = errorMessages } };
            }
            if (id == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is null") };
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is not found") };
            }
            return new JsonNetResult { Data = product };
        }

        //Products/Create
        public ActionResult Create([FromBody]Product product)
        {
            if (product.Name == null) return new EmptyResult();
            product.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelStateErrors.GetModelStateErrors(ModelState);
                return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "ModelState invalid.", Data = errorMessages } };
            }

            db.Products.Add(product);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }

            return new JsonNetResult { Data = new JsonMessage("Success", "Product was created the new id is:" + product.Id) };
        }

        //Products/Remove
        public ActionResult Remove([FromBody] Product product)
        {
            if (product.Name == null) return new EmptyResult();
            Product product2 = db.Products.Find(product.Id);
            db.Products.Remove(product2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
                       return new JsonNetResult { Data = new JsonMessage("Success", "User " + product2.Id + " " + (product2.Name) + " was deleted successfully") };
        }

        //Products/Change
        public ActionResult Change([FromBody] Product product)
        {
            if (product.Name == null) return new EmptyResult();
            product.DateUpdated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelStateErrors.GetModelStateErrors(ModelState);
                return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "ModelState invalid.", Data = errorMessages } };
            }

            if (product == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "The record has already been deleted,not found") };
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
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
                return new JsonNetResult { Data = new JsonMessage("Success", "User " + product.Id + " " + product.Name + ' ' + " was changed") };


        }
    }
}