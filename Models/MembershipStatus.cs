using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace A10.Models
{
    public class MembershipStatus
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int membershipStatusId { get; set; }
        public String membershipStatusDescription { get; set; }
    }
}
