﻿using System;
using System.Linq;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Repositories;
using TypicalMirek_UsedCarDealer.Logic.Repositories.Interfaces;
using TypicalMirek_UsedCarDealer.Models;

namespace TypicalMirek_UsedCarDealer.Logic.Managers
{
    public class EmailConfigurationManager : Manager, IEmailConfigurationManager
    {
        private readonly IEmailConfigurationRepository emailConfigurationRepository;

        public EmailConfigurationManager() { }

        public EmailConfigurationManager(IRepositoryFactory repositoryFactory)
        {
            emailConfigurationRepository = repositoryFactory.Get<EmailConfigurationRepository>();
        }

        public EmailConfiguration Add(EmailConfiguration emailConfiguration)
        {
            if (emailConfiguration == null)
            {
                return null;
            }

            var configurationWithTheSameId = emailConfigurationRepository.GetAll().FirstOrDefault(it => it.Id == emailConfiguration.Id);

            if (configurationWithTheSameId != null)
            {
                return null;
            }

            if (emailConfiguration.Active == true)
            {
                var currentActive = GetActive();

                if (currentActive != null)
                {
                    currentActive.Active = false;
                    Modify(currentActive);
                }
            }

            emailConfigurationRepository.Add(emailConfiguration);
            emailConfigurationRepository.Save();

            return emailConfiguration;
        }

        public EmailConfiguration GetActive()
        {
            return emailConfigurationRepository.GetAll().FirstOrDefault(it => it.Active == true);
        }

        public EmailConfiguration Modify(EmailConfiguration emailConfiguration)
        {
            var emailConfigurationToModify = emailConfigurationRepository.GetById(emailConfiguration.Id);
            if (emailConfigurationToModify == null)
            {
                return null;
            }

            emailConfigurationToModify.EnableSsl = emailConfiguration.EnableSsl;
            emailConfigurationToModify.From = emailConfiguration.From;
            emailConfigurationToModify.Host = emailConfiguration.Host;
            emailConfigurationToModify.Password = emailConfiguration.Password;
            emailConfigurationToModify.Port = emailConfiguration.Port;
            emailConfigurationToModify.To = emailConfiguration.To;
            emailConfigurationToModify.Username = emailConfiguration.Username;

            emailConfigurationRepository.Save();

            return emailConfiguration;
        }

        public bool Delete(EmailConfiguration emailConfiguration)
        {
            if (emailConfiguration == null)
            {
                return false;
            }

            if (emailConfigurationRepository.GetAll().Count() == 1)
            {
                throw new Exception("Can't delete last configuration");
            }

            if (emailConfigurationRepository.GetById(emailConfiguration.Id).Active == true)
            {
                throw new Exception("Can't delete active configuration");
            }

            emailConfigurationRepository.Delete(emailConfiguration);
            emailConfigurationRepository.Save();
            return true;
        }

        public void SetActive(int id)
        {
            var toSetActive = GetById(id);
            if (toSetActive == null)
            {
                return;
            }

            var currentActive = GetActive();
            if (currentActive != null)
            {
                currentActive.Active = false;
            }

            toSetActive.Active = true;
            Modify(toSetActive);
        }

        public EmailConfiguration GetById(int id)
        {
            return emailConfigurationRepository.GetById(id);
        }

        public IQueryable<EmailConfiguration> GetAll()
        {
            return emailConfigurationRepository.GetAll();
        }

        public void Dispose()
        {
            emailConfigurationRepository.Dispose();
        }
    }
}