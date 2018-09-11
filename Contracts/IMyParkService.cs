using Models.MyParkModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IMyParkService
    {
        bool CreateMyPark(MyParkCreate model);
        bool UpdateMyPark(MyParkEdit model);
        bool DeleteMyPark(int MyParkID);
        IEnumerable<MyParkListItem> GetMyPark();
        MyParkDetail GetMyParkByID(int MyParkID);
    }
}
