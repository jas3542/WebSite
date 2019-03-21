using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Helpers;
using Website.Models;

namespace Website.Controllers
{
    public class PersonController : Controller
    {
        private PersonService _queryDB;

        public PersonController()
        {
            _queryDB = new PersonService();
        }
        
        public ActionResult PersonList()
        {
            return View("PersonList", _queryDB.getPersonsList());
        }
        
        public ActionResult addPerson()
        {
            return View("addPerson");
        }

        [HttpPost]
        public ActionResult addPerson(Person person)
        {
            var result = _queryDB.insertPerson(person);

            if (result >= 1){
                ViewBag.msg = "Person added";
                return View("addPerson");
            }else{
                ViewBag.msg = "Person not added";
                return View("addPerson");
            }
        }
        
        public ActionResult deletePerson(Person person)
        {
            var result = _queryDB.deletePerson(person);
            
            if (result >= 1){
                return RedirectToAction("PersonList");
            }else{
                ViewBag.msg = "Person not deleted";
                return View("PersonList");
            }
        }
    }
}