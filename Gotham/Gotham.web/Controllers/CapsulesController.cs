﻿using System;
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
    public class CapsulesController : Controller
    {
        private readonly IRepository<Capsule> _repository;

        public CapsulesController(IRepository<Capsule> repository)
        {
            _repository = repository;
        }

        // GET: Capsules
        public async Task<IActionResult> Index()
        {
            return View(await _repository.GetAll());
        }

        // GET: Capsules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capsule = await _repository.GetById(id);
            if (capsule == null)
            {
                return NotFound();
            }

            return View(capsule);
        }

        // GET: Capsules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Capsules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titre,Texte,VideoUrl,Publié,Id")] Capsule capsule)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(capsule);
                return RedirectToAction(nameof(Index));
            }
            return View(capsule);
        }

        // GET: Capsules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capsule = await _repository.GetById(id);
            if (capsule == null)
            {
                return NotFound();
            }
            return View(capsule);
        }

        // POST: Capsules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Titre,Texte,Lien,Publié,VideoUrl,Id")] Capsule capsule)
        {
            if (id != capsule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(capsule);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapsuleExists(capsule.Id))
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
            return View(capsule);
        }

        // GET: Capsules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capsule = await _repository.GetById(id);
            if (capsule == null)
            {
                return NotFound();
            }

            return View(capsule);
        }

        // POST: Capsules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var capsule = await _repository.GetById(id);
            await _repository.Delete(capsule);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Publish(int id, [Bind("Titre,Texte,Lien,Publié,VideoUrl,Id")] Capsule capsule)
        {
            if (id != capsule.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Capsule oldCapsule = await _repository.GetById(capsule.Id);
                    capsule.Titre = oldCapsule.Titre;
                    capsule.Texte = oldCapsule.Texte;
                    capsule.Publié = true;
                    capsule.VideoUrl = oldCapsule.VideoUrl;
                    await _repository.Update(capsule);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapsuleExists(capsule.Id))
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
           return View(capsule);
        }

        public async Task<IActionResult> Publish(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var capsule = await _repository.GetById(id);
            if (capsule == null)
            {
                return NotFound();
            }
            return View(capsule);
        }

        public async Task<IActionResult> Withdraw(int id, [Bind("Id")] Capsule capsule)
        {
            if (id != capsule.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Capsule oldCapsule = await _repository.GetById(capsule.Id);
                    capsule.Titre = oldCapsule.Titre;
                    capsule.Texte = oldCapsule.Texte;
                    capsule.Publié = false;
                    capsule.VideoUrl = oldCapsule.VideoUrl;
                    await _repository.Update(capsule);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CapsuleExists(capsule.Id))
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
            return View(capsule);
        }


        private bool CapsuleExists(int id)
        {
            var capsule = _repository.GetById(id);
            if (capsule != null)
            {
                return true;
            }
            return false;
        }
    }
}
