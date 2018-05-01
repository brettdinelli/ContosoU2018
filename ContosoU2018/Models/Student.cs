using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU2018.Models
{
    public class Student : Person // student inherits from person
    {
        // student-specific property
        [Display(Name = "Enrollment Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

        // 1 student: many enrollments - this is the navigation property between 
        // student and enrollments
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        /*
            the enrollments property is a navigation property (EF Core). navigation properties
            hold other entities that are related to this entity. in this case, the enrollments 
            property of a student entity will hold all of the enrollments that are related to 
            that student. 

            in other words, if a given student row in the database has two related enrollment 
            rows (rows that contain that student's PK value in their foreign key column), that 
            student entity's enrollment navigation property will contain those two enrollment
            entities. 

            navigation properties are typically defined as virtual so they can take advantage
            of certain EF functionality such as lazy loading. 

            note: lazy loading is not yet available in EF Core, but it is in EF 5, 6...

            lazy loading is not enabled by default, so that means when a particular student
            entity is instantiated, it will automatically load all related entities.
        */


    } // end class
} // end namespace
