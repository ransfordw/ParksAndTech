using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ParkModels
{
    public class ParkDetail
    {
        public int ParkID { get; set; }

        public string ParkName { get; set; }

        public decimal ParkCost { get; set; }

        public string ParkAddress { get; set; }

        public string ParkCity { get; set; }

        public State ParkState { get; set; }

        public int ParkZip { get; set; }

        public string ParkPhone { get; set; }

        public string ParkWebsite { get; set; }

        public string ParkDescription { get; set; }

        public override string ToString() => $"[{ParkID}] {ParkName}";

    }
}
