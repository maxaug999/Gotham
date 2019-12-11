using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gotham.domain;
using Gotham.web.Models;
using Gotham.persistence;

namespace Gotham.web.Controllers
{
    public class AlertesController : Controller
    {
        private readonly IRepository<Alerte> _repository;

        public AlertesController(IRepository<Alerte> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var alertes = await _repository.GetAll();
            if (alertes == null)
            {
                return NotFound();
            }

            return View(alertes);
        }

        // GET: Alertes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alerte = await _repository.GetById(id);

            if (alerte == null)
            {
                return NotFound();
            }

            return View(alerte);
        }

        // GET: Alertes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alerte = await _repository.GetById(id);
            if (alerte == null)
            {
                return NotFound();
            }
            return View(alerte);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nature,Secteur,Risque,Ressource,Conseil,Publié,Id")] Alerte alerte)
        {
            if (id != alerte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(alerte);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlerteExists(alerte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alerte);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Publish(int id, [Bind("Nature,Secteur,Risque,Ressource,Conseil,Publié,Id")] Alerte alerte)
        {
            if (id != alerte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Alerte oldAlert = await _repository.GetById(alerte.Id);
                    alerte.Nature = oldAlert.Nature;
                    alerte.Ressource = oldAlert.Ressource;
                    alerte.Risque = oldAlert.Risque;
                    alerte.Secteur = oldAlert.Secteur;
                    alerte.Conseil = oldAlert.Conseil;
                    alerte.Publié = true;
                    await _repository.Update(alerte);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlerteExists(alerte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alerte);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Withdraw(int id, [Bind("Id")] Alerte alerte)
        {
            if (id != alerte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Alerte oldAlert = await _repository.GetById(alerte.Id);
                    alerte.Publié = false;
                    alerte.Nature = oldAlert.Nature;
                    alerte.Ressource = oldAlert.Ressource;
                    alerte.Risque = oldAlert.Risque;
                    alerte.Secteur = oldAlert.Secteur;
                    alerte.Conseil = oldAlert.Conseil;
                    await _repository.Update(alerte);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlerteExists(alerte.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(alerte);
        }

        public async Task<IActionResult> Publish(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alerte = await _repository.GetById(id);
            if (alerte == null)
            {
                return NotFound();
            }
            return View(alerte);
        }

        // GET: Alertes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alertes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nature,Secteur,Risque,Ressource,Conseil,Publié,Id")] Alerte alerte)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(alerte);
                return RedirectToAction(nameof(Index));
            }
            return View(alerte);
        }

        private bool AlerteExists(int id)
        {
            Alerte alerte = _repository.GetById(id).Result;

            if (alerte == null)
                return false;
            else
                return true;
        }
    }
}
