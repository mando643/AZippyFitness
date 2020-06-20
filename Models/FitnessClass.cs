using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace A10.Models
{
    public class FitnessClass
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int fitnessclassId { get; set; }
        public String fitnessclassTitle { get; set; }
        public String fitnessclassDescription { get; set; }
        [Range(0, 120)]
        public int fitnessclassDuration { get; set; }
        public int fitnessclassCaloriesBurnedApprox { get; set; }
        [Range(0, 21)]
        public int fitnessclassMaxEnrollees { get; set; }
        [Range(0, 51)]
        public double fitnessclassFee { get; set; }
        }
    }


