using System;
using System.ComponentModel.DataAnnotations;

namespace crudelicious.Models
{
    public class Dish
    {
        // Primary Key
        [Key] 
        public int DishId { get; set; }

        [Required]
        [Display(Name = "Name of Dish")] 
        [MinLength(2, ErrorMessage = "Must be at least 2 charactes.")]
        [MaxLength(45, ErrorMessage = "Must be less than 45 charactes.")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Chef's Name")] 
        [MinLength(2, ErrorMessage = "Must be at least 2 charactes.")]
        [MaxLength(45, ErrorMessage = "Must be less than 45 charactes.")]
        public string Chef { get; set; }
        
        [Required]
        [Range(1,5)]
        [Display(Name = "Tastiness")]
        public int Tastiness { get; set; }
        
        [Required]
        [Range(0,Int32.MaxValue)]
        [Display(Name = "# of Calories")] 
        public int Calories { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // if you add your own constructor then you need to also add a parameterless constructor
        public Dish() { }
    }
}