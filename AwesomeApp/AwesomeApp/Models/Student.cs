using System;
using SQLite;

namespace AwesomeApp.Models
{
	public class Student
	{
		public Student()
		{
		}

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

