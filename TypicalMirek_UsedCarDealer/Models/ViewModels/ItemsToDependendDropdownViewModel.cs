﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TypicalMirek_UsedCarDealer.Models.ViewModels
{
    public class Output
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public struct ItemsToDependendDropdownViewModel
    {
        public List<Output> output { get; set; }
        public string selected { get; set; }
    }
}