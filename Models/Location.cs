using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace A10.Models
{
    public class Location
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locationId { get; set; }
        public String locationStreetAddress { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        [Range(500, 99951)]
        public Int32 zipCode { get; set; }
        public String locationShortName { get; set; }
        public String locationphoneNumber { get; set; }

    }
}
