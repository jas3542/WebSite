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
        
        private void initializePersonsList()
        {
            _personList = new List<Person>();

            _personList.Add(new Person("James","Smith",20));
            _personList.Add(new Person("Tom","Dip",27));
            _personList.Add(new Person("Margarita","flores",30));
        }

        public ActionResult PersonList()
        {
            return View("PersonList",_personList);
        }
        
        public ActionResult addPerson()
        {
            return View("addPerson");

        }
        [HttpPost]
        public ActionResult addPerson(Person person)
        {
            _personList.Add(person);
            return View("addPerson");
        }
    }
}