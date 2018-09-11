using Contracts;
using Models.MyParkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MyParkService : IMyParkService
    {
        public bool CreateMyPark(MyParkCreate model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteMyPark(int MyParkID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MyParkListItem> GetMyPark()
        {
            throw new NotImplementedException();
        }

        public MyParkDetail GetMyParkByID(int MyParkID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateMyPark(MyParkEdit model)
        {
            throw new NotImplementedException();
        }
    }
}
