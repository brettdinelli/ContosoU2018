using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoU2018.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        /*
            you can turn off identity (on by default) by using the option above
            you have the following 3 options
            1. none - database does not generate a value (chosen above)
            2. identity - database generates a value when a row is inserted
            3. computed - database generates a value when a row is inserted or updated

            we're doing it in this case because we want the courses to number starting 
            with 101, 102, etc. rather than 1, 2, 3...
        */

        public int CourseID { get; set; }   // PK because we're using the ClassNameID pattern
        public string Title { get; set; }
        public int Credits { get; set; }

        // navigation properties
        // one course to many enrollments
        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}