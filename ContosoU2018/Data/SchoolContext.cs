using ContosoU2018.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU2018.Data
{
    public class SchoolContext : DbContext
    {
        // constructor
        public SchoolContext(DbContextOptions<SchoolContext> options):base(options)
        {

        }

        // specify the entity sets - corresponding to the database tables
        // each entity corresponds to a row in a table 

        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        /* 
            plural names will be used in this case because the EF will create
            a database with the table names matching the DBSet property names. 
            
            property names for collections are typically plural (Students rather than Student), 
            but many developers disagree about whether table names should be plural or not.
            later, we will override the naming of the tables
        */
         
    }
}
