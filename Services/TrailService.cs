using Contracts;
using Data;
using Models.TrailModels;
using ParksAndTech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TrailService : ITrailService
    {
        private readonly Guid _userId;

        public TrailService(Guid userID)
        {
            _userId = userID;
        }

        public bool CreateTrail(TrailCreate model)
        {
            var entity =
                new Trail()
                {
                    OwnerID = _userId,
                    TrailID = model.TrailID,
                    TrailName = model.TrailName,
                    TrailDifficulty =model.TrailDifficulty,
                    TrailDistance = model.TrailDistance,
                    IsOpen = model.IsOpen,
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
                        .Single(e => e.TrailID == TrailID && e.OwnerID == _userId);

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
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new TrailListItem
                                {
                                    TrailID = e.TrailID,
                                    OwnerID = _userId,
                                    ParkID = e.ParkID,
                                    TrailName = e.TrailName,
                                    TrailDifficulty = e.TrailDifficulty,
                                    TrailDistance = e.TrailDistance,
                                    IsOpen = e.IsOpen,
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
                        .Single(e => e.TrailID == TrailID && e.OwnerID == _userId);
                return
                    new TrailDetail
                    {
                        TrailID = entity.TrailID,
                        OwnerID = _userId,
                        ParkID = entity.ParkID,
                        TrailName = entity.TrailName,
                        TrailDifficulty = entity.TrailDifficulty,
                        TrailDistance = entity.TrailDistance,
                        IsOpen = entity.IsOpen,

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
                        .Single(e => e.TrailID == model.TrailID && e.OwnerID == _userId);

                entity.TrailID = model.TrailID;
                entity.ParkID = model.ParkID;
                entity.OwnerID = model.OwnerID;
                entity.TrailName = model.TrailName;
                entity.TrailDifficulty = model.TrailDifficulty;
                entity.TrailDistance = model.TrailDistance;
                entity.IsOpen = model.IsOpen;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
