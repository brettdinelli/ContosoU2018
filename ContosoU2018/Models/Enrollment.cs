using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace ContosoU2018.Models
{
    public class Enrollment
    {
        /*
            the EnrollmentID will be the primary key - this entity uses the 
            ClassNameID pattern instead of the ID by itself that you have 
            in the Student entity. 
        */
        public int EnrollmentID { get; set; }   // PK


        public int CourseID { get; set; }       // FK with corresponding navigation property Course


        public int StudentID { get; set; }      // FK with corresponding navigation property Student

        // display some text when the grade is null
        [DisplayFormat(NullDisplayText = "There is no grade recorded as of yet.")]
        public Grade? Grade { get; set; }       // ? meaning is nullable because we don't start with a grade

        // navigation property - each enrollment must be for one student
        public virtual Student Student { get; set; }

        public virtual Course Course { get; set; }

    }

    // grade enumeration
    public enum Grade
    {
        A, B, C, D, F
    }
}
