using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using Website.Models;

namespace Website.Helpers
{
    public sealed class QueriesToDB
    {
        private SQLiteConnection _sql;
        private SQLiteCommand _sqlCommand;
        private SQLiteDataReader _sqlReader;
        private string _path;
        
        public QueriesToDB()
        {
            _path = ConfigurationManager.ConnectionStrings["DefaultDB"].ConnectionString;
            _sql = new SQLiteConnection(_path);
            _sqlCommand = new SQLiteCommand();
        }

        public List<Person> selectQuery()
        {
            List<Person> personList = new List<Person>();

            _sql.Open();
            _sqlCommand = new SQLiteCommand("SELECT * from Person", _sql);
            _sqlReader = _sqlCommand.ExecuteReader();

            while (_sqlReader.Read())
            {
                var id = Convert.ToInt32(_sqlReader.GetValue(0));
                var name = _sqlReader.GetValue(1).ToString();
                var surname = _sqlReader.GetValue(2).ToString();
                var age = Convert.ToInt32(_sqlReader.GetValue(3));
                var isAlive = Convert.ToInt32(_sqlReader.GetValue(4)) == 1 ? true : false;

                var person = new Person()
                {
                    _id = id,
                    _name = name,
                    _surname = surname,
                    _age = age,
                    _isAlive = isAlive
                };
                personList.Add(person);
            }
            _sql.Close();

            return personList;
        }

        public int insertQuery(Person person)
        {
            _sql.Open();
            string insertQuery = $"INSERT into Person (Name,Surname,Age,isAlive) values ('{person._name}','{person._surname}',{person._age},{person._isAlive})";
            _sqlCommand = new SQLiteCommand(insertQuery, _sql);

            var result = _sqlCommand.ExecuteNonQuery();
            _sql.Close();

            return result;
        }



    }
}