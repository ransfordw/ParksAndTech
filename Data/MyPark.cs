using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public enum MyTrailStatus { Completed =1, Wishlist, Favorite, [Display(Name = "Would like to do it again")]Redo}
    public class MyPark
    {
        [Key]
        public int MyParkID { get; set; }
        [Required]
        public Guid OwnerID { get; set; }
        [Required]
        public int ParkID { get; set; }
        [Required]
        public int TrailID { get; set; }
        [Required]
        public MyTrailStatus MyTrailStatus { get; set; }
        [Required]
        public string TrailComment { get; set; }
        
        public virtual Park Park { get; set; }
        public virtual Trail Trail { get; set; }
    }
}
