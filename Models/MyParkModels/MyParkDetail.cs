using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MyParkModels
{
    public class MyParkDetail
    {
        [Required]
        public int MyParkID { get; set; }

        [Required]
        public int ParkID { get; set; }
        public string ParkName { get; set; }

        [Required]
        public int TrailID { get; set; }
        public string TrailName { get; set; }

        [Required]
        public MyTrailStatus MyTrailStatus { get; set; }

        [Required]
        public string TrailComment { get; set; }

        public override string ToString() => $"[{TrailID}] {TrailName}";

        public virtual Park Park { get; set; }
        public virtual Trail Trail { get; set; }
    }
}
