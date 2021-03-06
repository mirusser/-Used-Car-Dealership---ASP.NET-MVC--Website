﻿using System.ComponentModel.DataAnnotations;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}