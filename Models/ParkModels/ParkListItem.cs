using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ParkModels
{
    public class ParkListItem
    {
        [Display(Name = "Park ID")]
        public int ParkID { get; set; }

        [Display(Name = "Park Name")]
        public string ParkName { get; set; }

        [Display(Name = "Cost")]
        public decimal ParkCost { get; set; }

        [Display(Name = "Address")]
        public string ParkAddress { get; set; }

        [Display(Name = "City")]
        public string ParkCity { get; set; }

        [Display(Name = "State")]
        public State ParkState { get; set; }

        [Display(Name = "Zip")]
        public int ParkZip { get; set; }

        [Display(Name = "Phone")]
        public string ParkPhone { get; set; }

        [Display(Name = "Website")]
        public string ParkWebsite { get; set; }

        [Display(Name = "Description")]
        public string ParkDescription { get; set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
