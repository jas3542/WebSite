using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class PersonController : Controller
    {
        private List<Person> _personList;

        public PersonController()
        {
            initializePersonsList(); 
        }
        
        private List<Person> getPersonsList()
        {
            return _personList;
        }

        private void initializePersonsList()
        {
            _personList = new List<Person>();

            _personList.Add(new Person("James","Smith",20));
            _personList.Add(new Person("Tom","Dip",27));
            _personList.Add(new Person("Margarita","flores",30));
        }

        public ActionResult PersonList()
        {
            return View(_personList);
        }
        
        public ActionResult addPerson()
        {
            Person p = new Person("test", "test", 30);
            _personList.Add(p);
            return View("PersonList", _personList);
        }
    }
}