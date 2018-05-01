using ContosoU2018.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU2018.Data
{
    public class DbInitializer
    {
        public static void Initialize(SchoolContext context)
        {
            // EnsureCreate method will automatically create the database
            // if it doesn't already exist. 
            context.Database.EnsureCreated();

            // =================== students ====================
            // first, look for any students
            if(context.Students.Any())
            {
                // database has already been seeded (populated) with students
                return; // exits
            }

            // if we're here, students do not already exist - need to seed (populate)
            var students = new Student[]
            {
                new Student
                {
                    FirstName = "Carson",
                    LastName = "Alexander",
                    Email = "calexander@contoso.com",
                    EnrollmentDate = DateTime.Parse("2017-09-01"),
                    Address = "4 Flanders Court",
                    City = "Moncton",
                    Province = "NB",
                    PostalCode = "E1C 0K6"
                },
                new Student
                {
                    FirstName = "Meridith",
                    LastName = "Alonso",
                    Email = "malonso@contoso.com",
                    EnrollmentDate = DateTime.Parse("2017-09-01"),
                    Address = "205 Argyle Street",
                    City = "Moncton",
                    Province = "NB",
                    PostalCode = "E1C 8V2"
                }
            }; // end students array

            // loop the students array and add each student to database context
            foreach(Student s in students)
            {
                context.Students.Add(s);
            }

            // save the context
            context.SaveChanges();


            // =================== instructors ====================
            // now for the instructors
            var instructors = new Instructor[]
            {
                new Instructor
                {
                    FirstName = "Brett",
                    LastName = "Dinelli", 
                    Email = "brettdinelli@contoso.com",
                    HireDate = DateTime.Parse("1996-01-31"),
                    Address = "778 Centrale",
                    City = "Dieppe",
                    Province = "NB",
                    PostalCode = "E1A 5Z5"
                },
                new Instructor
                {
                    FirstName = "Frank",
                    LastName = "Bekkering",
                    Email = "fbekkering@contoso.com",
                    HireDate = DateTime.Parse("1996-01-31"),
                    Address = "456 Main Street",
                    City = "Moncton",
                    Province = "NB",
                    PostalCode = "E1A 5Z5"
                }
            }; // end instructors array
            
            foreach(Instructor i in instructors)
            {
                context.Instructors.Add(i);
            }

            // save it
            context.SaveChanges();

            // ================== courses ==================
            var courses = new Course[]
            {
                new Course
                {
                    CourseID = 1050,
                    Title = "Chemistry",
                    Credits = 3
                },
                new Course
                {
                    CourseID = 4022,
                    Title = "MicroEconomics", 
                    Credits = 3
                }
            };

            foreach(Course c in courses)
            {
                context.Add(c);
            }

            context.SaveChanges();

            // ================== enrollments ==================
            var enrollments = new Enrollment[]
            {
                new Enrollment
                {
                    CourseID = 1050,
                    StudentID = students.Single(s => s.LastName == "Alexander").ID,
                    Grade = Grade.A
                },
                new Enrollment
                {
                    CourseID = 4022,
                    StudentID = students.Single(s => s.LastName == "Alonso").ID,
                    Grade = Grade.B
                }
            };

            foreach(Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }

            context.SaveChanges();

        } // end Initialize method
    } // end class
} // end namespace
