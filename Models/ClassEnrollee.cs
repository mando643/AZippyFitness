using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace A10.Models
{
    public class ClassEnrollee
    {
        [Key]
        public int enrolledRegistrationId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? classSessionId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int? memberId { get; set; } 
        public ClassSession ClassSession { get; set; }
        public Member Member { get; set;}
    }
}
