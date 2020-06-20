using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace A10.Models
{
    public class MembershipType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int membershipTypeId { get; set; }
        public String membershipTypeDescription { get; set; }
        public double membershipMonthlyRate { get; set; }

    }
}
