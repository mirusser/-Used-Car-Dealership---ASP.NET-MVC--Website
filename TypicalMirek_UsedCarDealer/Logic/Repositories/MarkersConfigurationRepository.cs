﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class MarkersConfigurationRepository : BaseRepository<MarkersConfiguration, TypicalMirekEntities>, IMarkersConfigurationRepository
    {
        public MarkersConfigurationRepository()
        {

        }

        public MarkersConfigurationRepository(TypicalMirekEntities entities) : base(entities)
        {

        }
    }
}