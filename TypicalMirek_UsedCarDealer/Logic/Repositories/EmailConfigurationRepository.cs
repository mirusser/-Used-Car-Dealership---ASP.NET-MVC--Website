﻿using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Context;

namespace TypicalMirek_UsedCarDealer.Logic.Repositories
{
    public class EmailConfigurationRepository : BaseRepository<EmailConfiguration, TypicalMirekEntities>, IEmailConfigurationRepository
    {
        public EmailConfigurationRepository()
        {

        }

        public EmailConfigurationRepository(TypicalMirekEntities entities) : base(entities)
        {

        }
    }
}