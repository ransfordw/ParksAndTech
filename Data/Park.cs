using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum State { AL =1, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY }

    public class Park
    {
        [Key]
        public int ParkID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string ParkName { get; set; }
        [Required]
        public decimal ParkCost { get; set; }
        [Required]
        public string ParkAddress { get; set; }
        [Required]
        public string ParkCity { get; set; }
        [Required]
        public State ParkState { get; set; }
        [Required]
        public int ParkZip { get; set; }
        [Required]
        public string ParkPhone { get; set; }
        [Required]
        public string ParkWebsite { get; set; }
        [Required]
        public string ParkDescription { get; set; }
    }
}
