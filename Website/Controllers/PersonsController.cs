using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website.Models;

namespace Website.Controllers
{
    public class PersonsController : Controller
    {
        private List<Person> _personList;

        public PersonsController()
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

            _personList.Add(new Person("James"));
            _personList.Add(new Person("Tom"));
            _personList.Add(new Person("Margarita"));
            _personList.Add(new Person("Pilar"));
        }

        public ActionResult Persons()
        {
            return View("Person",_personList);
        }
    }
}