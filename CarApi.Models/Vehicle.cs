using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleApi.Models
{
    public class Vehicle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Range(1950, 2050)] 
        public int Year { get; set; }
        [Required]
        [MinLength(3)]
        public string Make { get; set; }
        [Required]
        [MinLength(1)]
        public string Model { get; set; }
    }
}
