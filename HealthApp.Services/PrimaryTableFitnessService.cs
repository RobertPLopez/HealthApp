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
                new PrimaryTableFitnessCreate()
                {
                    TypeOfWorkout = model.TypeOfWorkout,
                    CaloriesBurned = model.CaloriesBurned,
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

        public GetPrimaryTableFitnessById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessTables
                    .Single(e => e.MyFitnessPlan == id && e.OwnerId == _userId);

                return
                    new PrimaryTableFitnessDetail
                    { 
                        MyFitnessPlan = entity.MyFitnessPlay,
                        TypeOfWorkout = entity.TypeOfWorkout,
                        CaloriesBurned = entity.CaloriesBurned,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc,
                    };
            }
        }

        public bool UpdatePrimaryTableFitness (PrimaryTableFitnessEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .FitnessTables
                        .Single(e => e.MyFitnessPlan == model.MyFitnessPlan && e.OwnerId == _userId);

                entity.TypeOfWorkout = model.TypeOfWorkout;
                entity.CaloriesBurned = model.CaloriesBurned;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool PrimaryTableFitnessDelete (int MyFitnessPlan)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FitnessTables
                    .Single(e => e.MyFitnessPlan == MyFitnessPlan && e.OwnerId == _userId);
                ctx.FitnessTables.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
