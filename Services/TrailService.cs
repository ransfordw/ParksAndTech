using Contracts;
using Models.TrailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TrailService : ITrailService
    {
        public bool CreateTrail(TrailCreate model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTrail(int TrailID)
        {
            throw new NotImplementedException();
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
