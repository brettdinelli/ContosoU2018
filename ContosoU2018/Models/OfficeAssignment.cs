using System.ComponentModel.DataAnnotations;

namespace ContosoU2018.Models
{
    public class OfficeAssignment
    {
        [Key]
        public int InstructorID { get; set; } // pk and fk to instructor

        /*
            there is a one-to-zero-or-one relationship between Instructor and 
            OfficeAssignment entities. an OfficeAssignment only exists in relation
            to the instructor it is assigned to, and therefore its PK is also the 
            FK to the Instructor entity.

            problem: entity framework cannot automatically recognize InstructorID as 
            the PK of this entity because its name doesn't follow the ID or ClassNameID 
            naming convention. 

            fix: use the Key attribute to identify InstructorID as the key (this would not 
            work in a composite key situation)
        */

        [StringLength(65)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        // navigation property
        public virtual Instructor Instructor { get; set; }

    }
}