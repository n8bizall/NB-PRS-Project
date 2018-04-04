using NB_PRS_Project.Models;
using NB_PRS_Project.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using Utility;

namespace NB_PRS_Project.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        private AppDbContext db = new AppDbContext();

        //Users/List
        public ActionResult List()
        {
            return new JsonNetResult { Data = db.Users.ToList() };
        }

        //Users/Get/2
        public ActionResult Get(int? id)
        {
            if (id == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is null") };
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "Id is not found") };
            }
            return new JsonNetResult { Data = user };
        }

        //Users/Create
        public ActionResult Create([FromBody]User user)
        {
            if (user.UserName == null) return new EmptyResult();
            user.DateCreated = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "ModelState is not valid") };
            }

            db.Users.Add(user);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new JsonMessage("Success", "User was created the new id is:" + user.Id) }; //This  will add user id to this string
        }

        //Users/Remove
        public ActionResult Remove([FromBody] User user)
        {
            if (user.UserName == null) return new EmptyResult();
            User user2 = db.Users.Find(user.Id);
            db.Users.Remove(user2);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new JsonMessage("Success", "User " + user2.Id + " " + (user2.FirstName + " " + user2.LastName) + " was deleted successfully") };
        }

        //Users/Change
        public ActionResult Change([FromBody] User user)
        {
            if (user.UserName == null) return new EmptyResult();
            user.DateUpdated = DateTime.Now;
            if (user == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", "The record has already been deleted,not found") };
            }
            User user2 = db.Users.Find(user.Id);
            user2.Id = user.Id;
            user2.UserName = user.UserName;
            user2.Password = user.Password;
            user2.FirstName = user.FirstName;
            user2.LastName = user.LastName;
            user2.Phone = user.Phone;
            user2.Email = user.Email;
            user2.IsReviewer = user.IsReviewer;
            user2.IsAdmin = user.IsAdmin;
            user2.Active = user.Active;


            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return new JsonNetResult { Data = new JsonMessage("Failure", ex.Message) };
            }
            return new JsonNetResult { Data = new JsonMessage("Success", "User " + user.Id + " " + (user.FirstName + " " + user.LastName) + " was changed") };
        }

        //Users/Login
        public ActionResult Login(string userName, string password)
        {   
           

            if (userName == null || password == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failed", "Message = Invalid UserName or Password") };
            }
            var user = db.Users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
            if (user == null)
            {
                return new JsonNetResult { Data = new JsonMessage("Failed", "Message = No user found.") };
            }
            else
            {
                return new JsonNetResult { Data =user};
            }
        }

        //Login (string username, string password)
        //* read for the user with given user name
        //to test Users/Login/ ?username= <u>& password= <p>


        //[OperationContractAttribute]
        //public bool Login(
        //string username,
        //string password,
        //string salt,c:\users\max-student\source\repos\NB-PRS-Project\NB-PRS-Project\Models\
        //string passwordHash,
        //bool isPersistent)



        //routes.MapRoute(name:"Login", url:"{controller}/{action}/{username}/{password}", defaults: new {controller = "Users"});









    }
}