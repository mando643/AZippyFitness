using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace A10.Models
{
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int memberId { get; set; }
        public String lastName { get; set; }
        public String firstName { get; set; }
        public String streetAddress { get; set; }
        public String city { get; set; }
        public String state { get; set; }
        public Int32 zipCode { get; set; }
        public String emailAddress { get; set; }
        public String phoneHome { get; set; }
        public String phoneCell { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int membershipTypeId { get; set; }
        public String employerCompanyName { get; set; }
        public string employerPhoneNumber { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int membershipStatusId { get; set; }
        public String emergencyContactName { get; set; }
        public String emergencyContactPhone { get; set; }
        public String emergencyContactRelationship { get; set; }
        public double currentAmountOwed { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int primaryLocationId { get; set; }
        public MembershipType MembershipType { get; set; }
        public Location primaryLocation { get; set; }
        public MembershipStatus MembershipStatus { get; set; }

    }
}
