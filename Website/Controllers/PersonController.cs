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
        private List<Person> _personList;

        private SQLiteConnection _sql;
        private QueriesToDB _queryDB;

        public PersonController()
        {
            string path = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;
            _sql = new SQLiteConnection(path);
            _personList = new List<Person>();

            _queryDB = new QueriesToDB();
        }
        
        public ActionResult PersonList()
        {
            return View("PersonList", _queryDB.selectQuery());
        }
        
        public ActionResult addPerson()
        {
            return View("addPerson");
        }

        [HttpPost]
        public ActionResult addPerson(Person person)
        {
            var result = _queryDB.insertQuery(person);

            if (result >= 1)
            {
                ViewBag.msg = "Person added";
                return View("addPerson");
            }else
            {
                ViewBag.msg = "Person not added";
                return View("addPerson");
            }
        }
        
        public ActionResult deletePerson(Person person)
        {
            _sql.Open();
            SQLiteCommand sqlCommand;
            string deleteQuery = $"DELETE FROM Person WHERE id='{person._id}'";
            sqlCommand = new SQLiteCommand(deleteQuery, _sql);

            var result = sqlCommand.ExecuteNonQuery();
            _sql.Close();

            if (result >= 1)
            {
                return RedirectToAction("PersonList");
            }
            else
            {
                ViewBag.msg = "Person not deleted";
                return View("PersonList");
            }
        }
    }
}