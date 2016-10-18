﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class PositionOfSteeringWheel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [MinLength(3)]
        [Required]
        public string Position { get; set; }
    }
}