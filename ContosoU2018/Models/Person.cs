using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU2018.Models
{
    public abstract class Person
    {
        // person properties
        /*
            these properties will become database fields within the Person table
            by using the Entity Framework Core
            the ID property will become the primary key column of the database table
            that corresponds to this class (Person)
            by default the Entity Framework interprets property that is named ID
            or ClassNameID as the PK
            for example: 
                - ID
                - PersonID
        */

        public int ID { get; set; }

        [Display(Name = "First Name")]
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }


        [Display(Name = "Last Name")]
        [Required]
        [StringLength(65, ErrorMessage = "Last name cannot be longer than 65 characters.")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(150)] // this is the default error message, talks about a string, shouldn't leave it there like that
        public string Address { get; set; }

        [Required]
        [StringLength(60)]
        public string City { get; set; }

        [Display(Name = "Postal Code")]
        [Required]
        [StringLength(7)]
        [Column(TypeName = "nchar(7)")]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(2)]
        [Column(TypeName = "nchar(2)")]
        public string Province { get; set; }


        // read only properties
        [Display(Name = "Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string IDFullName
        {
            get
            {
                return "(" + ID + ") " + LastName + ", " + FirstName;
            }
        }

    } // end class
} // end namespace
