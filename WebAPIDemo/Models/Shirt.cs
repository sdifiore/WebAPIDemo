﻿using System.ComponentModel.DataAnnotations;

using WebAPIDemo.Models.Validations;

namespace WebAPIDemo.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }

        [Required]
        public string? Brand { get; set; }

        [Required]
        public string? Color { get; set; }

        [ShirtEnsureCorrectSizing]
        public int? Size { get; set; }

        [Required]
        public string? Gender { get; set; }

        public double? Price { get; set; }
        // Additional properties can be added as needed
    }
}