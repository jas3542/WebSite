using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Person
    {
        [DisplayName("Name")]
        public string _name { get; set; }
        [DisplayName("Surname")]
        public string _surname { get; set; }
        [DisplayName("Age")]
        public int _age { get; set; } = 0;
        [DisplayName("Still alive")]
        public bool _isAlive { get; set; } = true;


        public Person()
        {

        }
        public Person(string namee, string surnamee, int agee)
        {
            _name = namee;
            _surname = surnamee;
            _age = agee;
        }
    }
}