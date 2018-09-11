using Contracts;
using Models.ParkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ParkService : IParkService
    {
        public bool CreatePark(ParkCreate model)
        {
            throw new NotImplementedException();
        }

        public bool DeletePark(int ParkID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParkListItem> GetPark()
        {
            throw new NotImplementedException();
        }

        public ParkDetail GetParkByID(int ParkID)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePark(ParkEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
