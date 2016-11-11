﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.SqlServer.Server;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.Enums;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class AdminController : Controller
    {
        #region Constructors
        public AdminController()
        {

        }
        #endregion

        // GET: Admin
        public ActionResult Admin(ParametersToAdminMenu parametersToAdminMenu)
        {
            if (ModelState.IsValid)
            {
                if (parametersToAdminMenu.Id == null)
                {
                    parametersToAdminMenu.Id = 0;
                }
                return parametersToAdminMenu == null ? View(new ParametersToAdminMenu
                {
                    Chose = SidebarChoose.Nothing,
                    Id = parametersToAdminMenu.Id
                }) : View(new ParametersToAdminMenu
                {
                    Chose = parametersToAdminMenu.Chose,
                    Id = parametersToAdminMenu.Id
                });
            }

            //TODO
            return View(/*info about validation errot*/parametersToAdminMenu);
        }

        public ActionResult CreateCar()
        {
            return RedirectToAction("Create", "CarManagement");
        }
    }
}