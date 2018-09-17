using Contracts;
using Data;
using Models.MyParkModels;
using ParksAndTech.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MyParkService : IMyParkService
    {
        private readonly Guid _userID;
        private ParkService _parkService;
        private TrailService _trailService;

        public MyParkService(Guid userID)
        {
            _userID = userID;
            _parkService = new ParkService(_userID);
            _trailService = new TrailService(_userID);
        }

        public bool CreateMyPark(MyParkCreate model)
        {
            var entity =
                new MyPark()
                {
                    OwnerID = _userID,
                    ParkID = model.ParkID,
                    TrailID = model.TrailID,
                    MyTrailStatus = model.MyTrailStatus,
                    TrailComment = model.TrailComment
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MyParks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMyPark(int MyParkID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MyParks
                        .Single(e => e.MyParkID == MyParkID && e.OwnerID == _userID);

                ctx.MyParks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MyParkListItem> GetMyPark()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                     ctx
                         .MyParks
                         .Where(e => e.OwnerID == _userID)
                         .Include(e => e.ParkID)
                         .Include(e => e.TrailID)
                         .Select(
                             e =>
                                new MyParkListItem
                                {
                                    MyParkID = e.MyParkID,
                                    ParkID = e.ParkID,
                                    ParkName = e.Park.ParkName,
                                    TrailID = e.TrailID,
                                    TrailName = e.Trail.TrailName,
                                    MyTrailStatus = e.MyTrailStatus,
                                    TrailComment = e.TrailComment
                                }
                         );

                return query.ToArray();
            }
        }

        public MyParkDetail GetMyParkByID(int MyParkID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MyParks
                        .Single(e => e.MyParkID == MyParkID && e.OwnerID == _userID);
                return
                    new MyParkDetail
                    {
                        MyParkID = entity.MyParkID,
                        ParkID = entity.ParkID,
                        ParkName = entity.Park.ParkName,
                        TrailID = entity.TrailID,
                        TrailName = entity.Trail.TrailName,
                        MyTrailStatus = entity.MyTrailStatus,
                        TrailComment = entity.TrailComment
                    };
            }
        }

        public bool UpdateMyPark(MyParkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MyParks
                        .Single(e => e.MyParkID == model.MyParkID && e.OwnerID == _userID);

                entity.MyParkID = model.MyParkID;
                entity.ParkID = model.ParkID;
                entity.TrailID = model.TrailID;
                entity.MyTrailStatus = entity.MyTrailStatus;
                entity.TrailComment = entity.TrailComment;

                return ctx.SaveChanges() == 1;
            };
        }
    }
}
