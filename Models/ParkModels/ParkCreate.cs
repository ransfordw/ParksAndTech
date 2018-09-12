using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ParkModels
{
    public class ParkCreate
    {
        [Required]
        [Display(Name = "Park Name")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string ParkName { get; set; }

        [Required]
        [Display(Name = "Cost")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public decimal ParkCost { get; set; }

        [Required]
        [Display(Name = "Address")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(200, ErrorMessage = "There are too many characters in this field.")]
        public string ParkAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ParkCity { get; set; }

        [Required]
        [Display(Name = "State")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public State ParkState { get; set; }

        [Required]
        [Display(Name = "Zip")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public int ParkZip { get; set; }

        [Required]
        [Display(Name = "Phone")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string ParkPhone { get; set; }

        [Required]
        [Display(Name = "Website")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(500, ErrorMessage = "There are too many characters in this field.")]
        public string ParkWebsite { get; set; }

        [Required]
        [Display(Name = "Description")]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        public string ParkDescription { get; set; }

        public override string ToString() => ParkName;
    }
}
