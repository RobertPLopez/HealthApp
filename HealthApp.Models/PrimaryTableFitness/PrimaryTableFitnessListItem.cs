using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableFitness
{
    public class PrimaryTableFitnessListItem
    {
        public Guid MyFitnessPlan { get; set; }
        public string TypeOfWorkout { get; set; }
        public int CaloriesBurned { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
