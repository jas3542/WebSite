using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Person
    {
        public string _name { get; set; }

        public Person(string namee)
        {
            _name = namee;
        }
    }
}