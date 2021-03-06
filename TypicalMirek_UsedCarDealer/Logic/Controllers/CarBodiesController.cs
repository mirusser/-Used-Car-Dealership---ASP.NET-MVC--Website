﻿using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TypicalMirek_UsedCarDealer.Logic.Controllers.Strings;
using TypicalMirek_UsedCarDealer.Logic.Factories.Interfaces;
using TypicalMirek_UsedCarDealer.Logic.Managers;
using TypicalMirek_UsedCarDealer.Logic.Managers.Interfaces;
using TypicalMirek_UsedCarDealer.Models;
using TypicalMirek_UsedCarDealer.Models.ViewModels;

namespace TypicalMirek_UsedCarDealer.Logic.Controllers
{
    public class CarBodiesController : Controller
    {
        #region Properties
        private readonly ICarBodyManager carBodyManager;
        #endregion

        #region Constructors
        public CarBodiesController(IManagerFactory managerFactory)
        {
            carBodyManager = managerFactory.Get<CarBodyManager>();
        }
        #endregion

        public ActionResult List()
        {
            return View(carBodyManager.GetAll().ToList());
        }

        // GET: CarBodies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var body = carBodyManager.GetById(Convert.ToInt32(id));
            if (body == null)
            {
                return HttpNotFound();
            }
            return View(body);
        }

        // GET: CarBodies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarBodies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Body body)
        {
            if (ModelState.IsValid)
            {
                if (carBodyManager.Add(body) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(body);
                }
                return RedirectToAction($"List");
            }

            return View(body);
        }

        // GET: CarBodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var body = carBodyManager.GetById(Convert.ToInt32(id));
            if (body == null)
            {
                return HttpNotFound();
            }
            return View(body);
        }

        // POST: CarBodies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Body body)
        {
            if (ModelState.IsValid)
            {
                if (carBodyManager.Modify(body) == null)
                {
                    ModelState.AddModelError(string.Empty, ControllerStrings.NameIsTaken);
                    return View(body);
                }
                return RedirectToAction($"List");
            }
            return View(body);
        }

        // GET: CarBodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var body = carBodyManager.GetById(Convert.ToInt32(id));
            if (body == null)
            {
                return HttpNotFound();
            }
            return View(body);
        }

        // POST: CarBodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (carBodyManager.Delete(id))
            {
                return RedirectToAction($"List");
            }
            else
            {
                var relatedDataDeleteErrorViewModel = new RelatedDataDeleteErrorViewModel
                {
                    ControllerName = "CarBodies",
                    ModelName = nameof(Body)
                };

                return View("RelatedDataDeleteError", relatedDataDeleteErrorViewModel);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                carBodyManager.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
