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

        /*
        private readonly GothamwebContext _context;

        public AlertesController(GothamwebContext context)
        {
            _context = context;
        }

        // GET: Alertes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alerte.ToListAsync());
        }

        // GET: Alertes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alerte = await _context.Alerte
                .FirstOrDefaultAsync(m => m.Id == id);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nature,Secteur,Risque,Ressource,Conseil,Publication,Id")] Alerte alerte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(alerte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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

            var alerte = await _context.Alerte.FindAsync(id);
            if (alerte == null)
            {
                return NotFound();
            }
            return View(alerte);
        }

        // POST: Alertes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nature,Secteur,Risque,Ressource,Conseil,Publication,Id")] Alerte alerte)
        {
            if (id != alerte.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alerte);
                    await _context.SaveChangesAsync();
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

        // GET: Alertes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alerte = await _context.Alerte
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alerte == null)
            {
                return NotFound();
            }

            return View(alerte);
        }

        // POST: Alertes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alerte = await _context.Alerte.FindAsync(id);
            _context.Alerte.Remove(alerte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlerteExists(int id)
        {
            return _context.Alerte.Any(e => e.Id == id);
        }*/
    }
}
