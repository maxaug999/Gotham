﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gotham.domain;
using Gotham.persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gotham.web.Controllers
{
    public class NouvellesController : Controller
    {
        private readonly IRepository<Nouvelle> _repository;

        public NouvellesController(IRepository<Nouvelle> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var nouvelles = await _repository.GetAll();
            if (nouvelles == null)
            {
                return NotFound();
            }

            return View(nouvelles);
        }

        // GET: Nouvelles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nouvelle = await _repository.GetById(id);

            if (nouvelle == null)
            {
                return NotFound();
            }

            return View(nouvelle);
        }
        
        // GET: Nouvelles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nouvelles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titre,Texte,Lien,Status,Id")] Nouvelle nouvelle)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(nouvelle);
                return RedirectToAction(nameof(Index));
            }
            return View(nouvelle);
        }
        
        // GET: Nouvelles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nouvelle = await _repository.GetById(id);
            if (nouvelle == null)
            {
                return NotFound();
            }
            return View(nouvelle);
        }
        
        // POST: Nouvelles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Titre,Texte,Lien,Status,Id")] Nouvelle nouvelle)
        {
            if (id != nouvelle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(nouvelle);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NouvelleExists(nouvelle.Id))
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
            return View(nouvelle);
        }
        
        // GET: Nouvelles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nouvelle = await _repository.GetById(id);
            if (nouvelle == null)
            {
                return NotFound();
            }

            return View(nouvelle);
        }
        
        // POST: Nouvelles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nouvelle = _repository.GetById(id).Result;
            await _repository.Delete(nouvelle);
            return RedirectToAction(nameof(Index));
        }

        private bool NouvelleExists(int id)
        {
            Nouvelle nouvelle = _repository.GetById(id).Result;

            if (nouvelle == null)
                return false;
            else
                return true;
        }
    }
}
