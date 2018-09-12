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
            throw new NotImplementedException();
        }

        public TrailDetail GetTrailByID(int TrailID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTrail(TrailEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
