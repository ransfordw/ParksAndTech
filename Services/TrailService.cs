using Contracts;
using Data;
using Models.TrailModels;
using ParksAndTech.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TrailService : ITrailService
    {
        private readonly Guid _userID;
        private ParkService _parkService;

        public TrailService(Guid userID)
        {
            _userID = userID;
            _parkService = new ParkService(_userID);
        }

        public bool CreateTrail(TrailCreate model)
        {
            var entity =
                new Trail()
                {
                    OwnerID = _userID,
                    TrailName = model.TrailName,
                    TrailDifficulty =model.TrailDifficulty,
                    TrailDistance = model.TrailDistance,
                    TrailCondition = model.TrailCondition,
                    ParkID = model.ParkID
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trails.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTrail(int TrailID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trails
                        .Single(e => e.TrailID == TrailID && e.OwnerID == _userID);

                ctx.Trails.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TrailListItem> GetTrail()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Trails
                        .Where(e => e.OwnerID == _userID)
                        .Include(e => e.ParkID)
                        .Select(
                            e =>
                                new TrailListItem
                                {
                                    TrailID = e.TrailID,
                                    ParkID = e.ParkID,
                                    ParkName = e.Park.ParkName,
                                    TrailName = e.TrailName,
                                    TrailDifficulty = e.TrailDifficulty,
                                    TrailDistance = e.TrailDistance,
                                    TrailCondition = e.TrailCondition,
                                }
                        );

                return query.ToArray();
            }
        }

        public TrailDetail GetTrailByID(int TrailID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trails
                        .Single(e => e.TrailID == TrailID && e.OwnerID == _userID);
                return
                    new TrailDetail
                    {
                        TrailID = entity.TrailID,
                        ParkID = entity.ParkID,
                        ParkName = entity.Park.ParkName,
                        TrailName = entity.TrailName,
                        TrailDifficulty = entity.TrailDifficulty,
                        TrailDistance = entity.TrailDistance,
                        TrailCondition = entity.TrailCondition,

                    };
            }
        }

        public bool UpdateTrail(TrailEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trails
                        .Single(e => e.TrailID == model.TrailID && e.OwnerID == _userID);

                entity.TrailID = model.TrailID;
                entity.ParkID = model.ParkID;
                entity.TrailName = model.TrailName;
                entity.TrailDifficulty = model.TrailDifficulty;
                entity.TrailDistance = model.TrailDistance;
                entity.TrailCondition = model.TrailCondition;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
