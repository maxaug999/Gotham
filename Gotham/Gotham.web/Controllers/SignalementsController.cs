using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gotham.domain;
using Gotham.persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gotham.web.Controllers
{
    public class SignalementsController : Controller
    {
        private readonly IRepository<Signalement> _repository;

        public SignalementsController(IRepository<Signalement> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var signalements = await _repository.GetAll();
            if (signalements == null)
            {
                return NotFound();
            }

            return View(signalements);
        }

        // GET: Nouvelles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signalements = await _repository.GetById(id);

            if (signalements == null)
            {
                return NotFound();
            }

            return View(signalements);
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
        public async Task<IActionResult> Create([Bind("Nature,Secteur,Heure,Commentaires,Id")] Signalement signalement)
        {
            if (ModelState.IsValid)
            {
                await _repository.Add(signalement);
                return RedirectToAction(nameof(Index));
            }
            return View(signalement);
        }
        
        // GET: Nouvelles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signalement = await _repository.GetById(id);
            if (signalement == null)
            {
                return NotFound();
            }
            return View(signalement);
        }
        
        // POST: Nouvelles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nature,Secteur,Heure,Commentaires,Id")] Signalement signalement)
        {
            if (id != signalement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(signalement);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SignalementExists(signalement.Id))
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
            return View(signalement);
        }
        
        // GET: Nouvelles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var signalement = await _repository.GetById(id);
            if (signalement == null)
            {
                return NotFound();
            }

            return View(signalement);
        }
        
        // POST: Nouvelles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var signalement = _repository.GetById(id).Result;
            await _repository.Delete(signalement);
            return RedirectToAction(nameof(Index));
        }

        private bool SignalementExists(int id)
        {
            Signalement signalement = _repository.GetById(id).Result;

            if (signalement == null)
                return false;
            else
                return true;
        }
    }
}
