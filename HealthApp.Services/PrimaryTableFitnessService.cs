using HealthApp.Models.PrimaryTableFitness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthApp.Services
{
    public class PrimaryTableFitnessService
    {
        private readonly Guid _userId;
        public PrimaryTableFitnessService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePrimaryFitnessTable(PrimaryTableFitnessCreate model)
        {
            var entity =
                new PrimaryTableFitness()
                {
                    OwnerId = _userId,
                    Workout = model.TypeOfWorkout,
                    DailyCaloriesBurned = model.CaloriesBurned,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FitnessTables.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PrimaryTableFitnessListItem> GetPrimaryTableFitness()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FitnessTables
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e => 
                        new PrimaryTableFitnessListItem
                        {
                            MyFitnessPlan = e.MyFitnessPlan,
                            TypeOfWorkout = e.TypeOfWorkout,
                            CaloriesBurned = e.CaloriesBurned, 
                            CreatedUtc = e.CreatedUtc
                        }
                    );
                return query.ToArray();
            }
        }
    }
}
