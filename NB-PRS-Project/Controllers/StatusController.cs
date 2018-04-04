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
    public class StatussController : Controller
    {
        // GET: Status
        public ActionResult Index()
        {
            return View();
        }
        
            private AppDbContext db = new AppDbContext();

            //Status/List
            public ActionResult List()
            {
                return new JsonNetResult { Data = db.Statuss.ToList() };
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
                Status status = db.Statuss.Find(id);
                if (status == null)
                {
                    return new JsonNetResult { Data = new JsonMessage("Failure", "Id is not found") };
                }
                return Json(status, JsonRequestBehavior.AllowGet);
            }

            //Products/Create
            public ActionResult Create([FromBody]Status status)
            {
                if (status.Id == null) return new EmptyResult();
            
                if (!ModelState.IsValid)
                {
                    var errorMessages = ModelStateErrors.GetModelStateErrors(ModelState);
                    return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "ModelState invalid.", Data = errorMessages } };
                }

                db.Statuss.Add(status);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
                }

                return new JsonNetResult { Data = new JsonMessage("Success", "Status was created the new id is:" + status.Id) };
            }

            //Products/Remove
            public ActionResult Remove([FromBody] Status status)
            {
                if (status.Id == null) return new EmptyResult();
                Status status2 = db.Statuss.Find(status.Id);
                db.Statuss.Remove(status2);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
                }
                return new JsonNetResult { Data = new JsonMessage("Success", "Status " + status2.Id +  " was deleted successfully") };
            }

            //Products/Change
            public ActionResult Change([FromBody] Status status)
            {
                if (status.Id == null) return new EmptyResult();
            
                if (!ModelState.IsValid)
                {
                    var errorMessages = ModelStateErrors.GetModelStateErrors(ModelState);
                    return new JsonNetResult { Data = new Msg { Result = "Failed", Message = "ModelState invalid.", Data = errorMessages } };
                }

                if (status == null)
                {
                    return new JsonNetResult { Data = new JsonMessage("Failure", "The record has already been deleted,not found") };
                }
                Status status2 = db.Statuss.Find(status.Id);
            status2.Id = status.Id;
            status2.MyStatus = status.MyStatus;
              


                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
                }
                return new JsonNetResult { Data = new JsonMessage("Success", "Status " + status.Id + " was changed") };


            }
        }
    }
