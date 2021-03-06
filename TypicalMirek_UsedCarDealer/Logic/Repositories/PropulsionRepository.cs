﻿using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class PropulsionRepository : BaseRepository<Propulsion, TypicalMirekEntities>, IPropulsionRepository
    {
        public PropulsionRepository()
        {
            
        }

        public PropulsionRepository(TypicalMirekEntities entities) : base(entities)
        {
            
        }
    }
}