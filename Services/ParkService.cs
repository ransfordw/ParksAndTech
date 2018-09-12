using Contracts;
using Data;
using Models.ParkModels;
using ParksAndTech.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ParkService : IParkService
    {
        private readonly Guid _userID;

        public ParkService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePark(ParkCreate model)
        {
            var entity =
                new Park()
                {
                    OwnerID = _userID,
                    ParkName = model.ParkName,
                    ParkCost = model.ParkCost,
                    ParkAddress = model.ParkAddress,
                    ParkCity = model.ParkCity,
                    ParkState = model.ParkState,
                    ParkZip = model.ParkZip,
                    ParkPhone = model.ParkPhone,
                    ParkWebsite = model.ParkWebsite,
                    ParkDescription = model.ParkDescription,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Parks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdatePark(ParkEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkID == model.ParkID && e.OwnerID == _userID);

                entity.ParkName = model.ParkName;
                entity.ParkCost = model.ParkCost;
                entity.ParkAddress = model.ParkAddress;
                entity.ParkCity = model.ParkCity;
                entity.ParkState = model.ParkState;
                entity.ParkZip = model.ParkZip;
                entity.ParkPhone = model.ParkPhone;
                entity.ParkWebsite = model.ParkWebsite;
                entity.ParkDescription = model.ParkDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePark(int ParkID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkID == ParkID && e.OwnerID == _userID);

                ctx.Parks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ParkListItem> GetPark()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Parks
                        .Select(
                            e =>
                                new ParkListItem
                                {
                                    ParkID = e.ParkID,
                                    ParkName = e.ParkName,
                                    ParkCost = e.ParkCost,
                                    ParkAddress = e.ParkAddress,
                                    ParkCity = e.ParkCity,
                                    ParkState = e.ParkState,
                                    ParkZip = e.ParkZip,
                                    ParkPhone = e.ParkPhone,
                                    ParkWebsite = e.ParkWebsite,
                                    ParkDescription = e.ParkDescription,
                                }
                        );

                return query.ToArray();
            }
        }

        public ParkDetail GetParkByID(int parkID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Parks
                        .Single(e => e.ParkID == parkID);
                return
                    new ParkDetail
                    {
                        ParkID = entity.ParkID,
                        ParkName = entity.ParkName,
                        ParkCost = entity.ParkCost,
                        ParkAddress = entity.ParkAddress,
                        ParkCity = entity.ParkCity,
                        ParkState = entity.ParkState,
                        ParkZip = entity.ParkZip,
                        ParkPhone = entity.ParkPhone,
                        ParkWebsite = entity.ParkWebsite,
                        ParkDescription = entity.ParkDescription,
                    };
            }
        }
    }
}
