﻿using System.Collections.Generic;
using System.Linq;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Models
{
    public class ParametersToHome
    {
        public IList<CarPhotoViewModel> Slider { get; set; }
        public IList<CarPhotoViewModel> HotCars { get; set; }
        public IList<CarPhotoViewModel> NewCars { get; set; }
        public IQueryable<string> BrandList { get; set; }
        public IQueryable<string> FuelTypeList { get; set; }
    }
}