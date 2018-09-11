using Models.TrailModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ITrailService
    {
        bool CreateTrail(TrailCreate model);
        bool UpdateTrail(TrailEdit model);
        bool DeleteTrail(int TrailID);
        IEnumerable<TrailListItem> GetTrail();
        TrailDetail GetTrailByID(int TrailID);
    }
}
