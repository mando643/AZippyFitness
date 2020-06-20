using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace A10.Models
{
    public class ClassSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int classSessionId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fitnessClassId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dddd MM/dd/yy hh:mm tt}")]
        public DateTime ClassSessionStartTime { get; set; }
       
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int locationId { get; set; }
        public FitnessClass FitnessClass { get; set; }
        public Location Location { get; set; }
    }
}
