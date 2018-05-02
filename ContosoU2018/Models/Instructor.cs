using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU2018.Models
{
    public class Instructor : Person // instructor inherites from person
    {
        // instructor-specific properties
        [Display(Name = "Hire Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }

        // add navigation properties
        // an instructor can teach any number of courses, so Courses is defined
        // as a collection of the CourseAssignment Entity
        public virtual ICollection<CourseAssignment> Courses { get; set; }

        // an instructor can only have, at most, one office, so the OfficeAssignment
        // property holds a single OfficeAssignment Entity, which may be null if no 
        // office is assigned
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}
