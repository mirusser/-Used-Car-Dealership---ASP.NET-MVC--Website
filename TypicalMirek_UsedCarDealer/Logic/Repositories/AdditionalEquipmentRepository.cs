﻿using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class AdditionalEquipmentRepository : BaseRepository<AdditionalEquipment, TypicalMirekEntities>, IAdditionalEquipmentRepository
    {
        public AdditionalEquipmentRepository()
        {
            
        }

        public AdditionalEquipmentRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}