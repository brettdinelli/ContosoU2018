using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

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
