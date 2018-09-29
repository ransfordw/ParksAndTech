using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum Difficulty { Easy =1, Moderate, Challenging}
    public enum Condition { Open =1, Closed, Construction, Weather}
    public class Trail
    {
        [Key]
        public int TrailID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public string TrailName { get; set; }
        [Required]
        public decimal TrailDistance { get; set; }
        [Required]
        public Difficulty TrailDifficulty { get; set; }
        [Required]
        public Condition TrailCondition { get; set; }
        [Required]
        public int ParkID { get; set; }

        public virtual Park Park { get; set; }
    }
}
