using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Models.PrimaryTableFitness
{
    public class PrimaryTableFitnessEdit
    {
        public Guid MyFitnessPlan { get; set; }
        public string TypeOfWorkout { get; set; }
        public int CaloriesBurned { get; set; }
    }
}
