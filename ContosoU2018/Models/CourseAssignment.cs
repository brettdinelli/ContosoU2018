namespace ContosoU2018.Models
{
    public class CourseAssignment
    {
        // creating a more complex data model
        // composite pk, fk to Instructor entity
        public int InstructorID { get; set; }
        
        // composite pk, fk to Instructor entity
        public int CourseID { get; set; }

        /*
            note: the only way to identify composite primary keys to Entity Framework
            is by using the fluent API within the SchoolContext class. it cannot be 
            done with attributes
        */

        // navigation properties
        // one course, many course assignments (each assigned course belongs to one Course)
        // one instructor, many course assignments (each assigned instructor belongs to one Instructor)
        public virtual Instructor Instructor { get; set; }

        public virtual Course Course { get; set; }


    }
}