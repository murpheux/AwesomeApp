using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using AwesomeApp.Models;

namespace AwesomeApp.Data
{
	public class StudentDatabase
	{
		readonly SQLiteAsyncConnection database;

		public StudentDatabase(string databasePath)
		{
			database = new SQLiteAsyncConnection(databasePath);
			database.CreateTableAsync<Student>().Wait();
		}

        public Task<List<Student>> GetStudentsAsync()
        {
            //Get all Students.
            return database.Table<Student>().ToListAsync();
        }

        public Task<Student> GetStudentAsync(int id)
        {
            // Get a specific student.
            return database.Table<Student>()
                            .Where(i => i.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveStudentAsync(Student student)
        {
            if (student.Id != 0)
            {
                // Update an existing student.
                return database.UpdateAsync(student);
            }
            else
            {
                // Save a new student.
                return database.InsertAsync(student);
            }
        }

        public Task<int> DeleteStudentAsync(Student student)
        {
            // Delete a student.
            return database.DeleteAsync(student);
        }
    }
}

