using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Data
{
    public class PrimaryTableFitness
    {
        [Key]
        public int WorkoutId { get; set; }
        public Guid OwnerId { get; set; }
        //[Required]
        //public ICollection <Excersises> : ExcersiseTabele I need to be able to connect this to the sub fitness tables 
        [Required]
        public int TotalCaloriesBurned { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
