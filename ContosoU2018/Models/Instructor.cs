using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoU2018.Models
{
    public class Instructor : Person // instructor inherites from person
    {
        // instructor-specific properties
        public DateTime HireDate { get; set; }

    }
}
