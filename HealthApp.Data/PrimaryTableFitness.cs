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
        [Display(Name = "Your Fitness Plan!")]
        public Guid MyFitnessPlan { get; set; }
        [Required]
        [Display(Name = "Your Workout! Own it!")]
        [MaxLength(150, ErrorMessage = "There are to many characters in this field.")]
        public string TypeOfWorkout { get; set; }
        [Required]
        [Display(Name = "This is the total number of calories burned!")]
        public int CaloriesBurned { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
