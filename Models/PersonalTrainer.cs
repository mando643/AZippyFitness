using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace A10.Models
{
    public class PersonalTrainer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int trainerId { get; set; }
        [StringLength(25, MinimumLength = 2)]
        public String trainerFirstName { get; set; }
        [StringLength(25, MinimumLength = 2)]
        public String trainerLastName { get; set; }
        public String trainerGender { get; set;}
        public String trainerSpecialities { get; set; }
        public int trainerPrimaryLocationId { get; set; }
    }
}
