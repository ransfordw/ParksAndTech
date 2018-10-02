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
        [Required]
        public int ParkID { get; set; }

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

        public override string ToString() => $"[{ParkID}] {ParkName}";
    }
}
