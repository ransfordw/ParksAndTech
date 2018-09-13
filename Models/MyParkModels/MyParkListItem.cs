using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MyParkModels
{
    public class MyParkListItem
    {
        [Required]
        [Display(Name = "Park Name")]
        public int ParkID { get; set; }
        public string ParkName { get; set; }
        public virtual Park Park { get; set; }

        [Required]
        [Display(Name = "Trail Name")]
        public int TrailID { get; set; }
        public string TrailName { get; set; }
        public virtual Trail Trail { get; set; }

        [Required]
        [Display(Name = "My Trail Status")]
        public MyTrailStatus MyTrailStatus { get; set; }

        [Required]
        [Display(Name = "Trail Comment")]
        public string TrailComment { get; set; }

        public override string ToString() => TrailName;
    }
}
