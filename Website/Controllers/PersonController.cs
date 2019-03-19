using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class PersonController : Controller
    {
        private List<Person> _personList;

        private SQLiteConnection _sql;

        public PersonController()
        {
            string path = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;
            _sql = new SQLiteConnection(path);
            _personList = new List<Person>();
        }
        
        public ActionResult PersonList()
        {
            _sql.Open();
            SQLiteCommand sqlCommand;
            SQLiteDataReader sqlReader;

            sqlCommand = new SQLiteCommand("SELECT * from Person", _sql);
            
            sqlReader = sqlCommand.ExecuteReader();

            while(sqlReader.Read())
            {
                var id = Convert.ToInt32(sqlReader.GetValue(0));
                var name = sqlReader.GetValue(1).ToString();
                var surname = sqlReader.GetValue(2).ToString();
                var age = Convert.ToInt32( sqlReader.GetValue(3));
                var isAlive = Convert.ToInt32(sqlReader.GetValue(4)) == 1 ? true : false;

                var person = new Person()
                {
                    _id = id,
                    _name = name,
                    _surname = surname,
                    _age = age,
                    _isAlive = isAlive
                };
                _personList.Add(person);
            }
            _sql.Close();
            return View("PersonList",_personList);
        }
        
        public ActionResult addPerson()
        {
            return View("addPerson");
        }

        [HttpPost]
        public ActionResult addPerson(Person person)
        {
            _sql.Open();
            SQLiteCommand sqlCommand;
            string insertQuery = $"INSERT into Person (Name,Surname,Age,isAlive) values ('{person._name}','{person._surname}',{person._age},{person._isAlive})";
            sqlCommand = new SQLiteCommand(insertQuery, _sql);

            var result = sqlCommand.ExecuteNonQuery();
            _sql.Close();

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