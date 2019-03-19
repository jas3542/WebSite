using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website.Models
{
    public class Person
    {
        public int _id { get; set; }

        [DisplayName("Name")]
        public string _name { get; set; }

        [DisplayName("Surname")]
        public string _surname { get; set; }

        [DisplayName("Age")]
        [Required(ErrorMessage = "Age must be between 0-100")]
        [Range(0, 100)]
        public int _age { get; set; } = 0;

        [DisplayName("Still alive")]
        public bool _isAlive { get; set; } = true;
        
        public Person()
        {

        }

        public Person(string namee, string surnamee, int agee, bool isAlivee = true)
        {
            _name = namee;
            _surname = surnamee;
            _age = agee;
            _isAlive = isAlivee;
        }
    }
}