using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.MyParkModels
{
    public class MyParkEdit
    {
        [Required]
        public int MyParkID { get; set; }

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
        public MyTrailStatus MyTrailStatus { get; set; }

        [Required]
        [Display(Name = "Trail Comment")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string TrailComment { get; set; }
    }
}
