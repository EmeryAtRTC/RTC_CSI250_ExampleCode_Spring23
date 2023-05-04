using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccess
{
    internal class Repository
    {
        //We use a connection string to connect an app to a database
        //Data Source is the server name
        //initial catalog is the database name
        const string CONNECTION_STRING = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolDB";
        //SQL Connection Object
        SqlConnection connection;
        //SQL command
        SqlCommand command;
        //SQL Data Reader
        SqlDataReader reader;

        public Repository()
        {
            connection = new SqlConnection(CONNECTION_STRING);
        }
        //Im gonna make a method that gets all of the courses
        public List<Course> GetAllCourses()
        {
            //We need the actual SQL statement as a string
            string sql = "SELECT * FROM COURSE";
            List<Course> courses = new List<Course>();
            //try to run this
            try
            {
                //Open the connection
                connection.Open();
                //assign the command
                //first parameter is the query we run, 2nd is the connection to run query on
                command = new SqlCommand(sql, connection);
                //call executereader
                reader = command.ExecuteReader();
                //.Read() method gives you the records that came back
                while (reader.Read())
                {
                    courses.Add(new Course
                    {
                        CourseId = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Credits = reader.GetInt32(2),
                        DepartmentID = reader.GetInt32(3),
                    });
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return courses;
        }
        public Course GetCourseById(int id)
        {
            //We need the actual SQL statement as a string
            string sql = "SELECT * FROM COURSE WHERE CourseId = " + id;
            Course course = new Course();
            //try to run this
            try
            {
                //Open the connection
                connection.Open();
                //assign the command
                //first parameter is the query we run, 2nd is the connection to run query on
                command = new SqlCommand(sql, connection);
                //call executereader
                reader = command.ExecuteReader();
                //.Read() method gives you the records that came back
                while (reader.Read())
                {

                    course.CourseId = reader.GetInt32(0);
                    course.Title = reader.GetString(1);
                    course.Credits = reader.GetInt32(2);
                    course.DepartmentID = reader.GetInt32(3);

                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return course;
        }
    }
}
