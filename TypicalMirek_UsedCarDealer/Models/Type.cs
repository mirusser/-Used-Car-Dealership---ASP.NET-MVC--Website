﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class Type
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}