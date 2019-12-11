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
    public class PreventionsController : Controller
    {
        private readonly IRepository<Prevention> _repository;

        public PreventionsController(IRepository<Prevention> repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var Preventions = await _repository.GetAll();
            if (Preventions == null)
            {
                return NotFound();
            }

            return View(Preventions);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titre,Texte,Mois,Publie")] Prevention prevention)
        {
            if(ModelState.IsValid)
            {
                await _repository.Add(prevention);
                return RedirectToAction(nameof(Index));
            }
            return View(prevention);
        }

        public async Task<IActionResult> Detail(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var prevention = await _repository.GetById(Id);
            if(prevention == null)
            {
                return NotFound();
            }
            return View(prevention);
        }

        public async Task<IActionResult> Edit(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var prevention = await _repository.GetById(Id);
            if (prevention == null)
            {
                return NotFound();
            }
            return View(prevention);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,Titre,Texte,Mois,Publie")] Prevention prevention)
        {
            if (Id != prevention.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                try
                {
                    await _repository.Update(prevention);
                }
                catch(DbUpdateConcurrencyException)

                {
                    if(!PreventionExists(prevention.Id))
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
            return View(prevention);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var prevention = await _repository.GetById(Id);
            if (prevention == null)
            {
                return NotFound();
            }
            return View(prevention);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var prevention = await _repository.GetById(Id);
            await _repository.Delete(prevention);
            return RedirectToAction(nameof(Index));
        }

        /*public async Task<IActionResult> Publie(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var prevention = await _repository.GetById(Id);
            if (prevention == null)
            {
                return NotFound();
            }
            return View(prevention);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Publish(int id, [Bind("Id,Titre,Texte,Mois,Publié")] Prevention prevention)
        {
            if (id != prevention.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Prevention preventionOld = await _repository.GetById(prevention.Id);
                    prevention.Titre = preventionOld.Titre;
                    prevention.Texte = preventionOld.Texte;
                    prevention.Mois = preventionOld.Mois;
                    prevention.Publie = preventionOld.Publie;
                    await _repository.Update(prevention);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PreventionExists(prevention.Id))
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
            return View(prevention);
        }*/

        private bool PreventionExists(int Id)
        {
            var prevention = _repository.GetById(Id);
            if(prevention != null)
            {
                return true;
            }
            return false;
        }
        /*public PreventionsController(GothamwebContext context)
{
   _context = context;
}

// GET: Preventions
public async Task<IActionResult> Index()
{
   return View(await _context.Prevention.ToListAsync());
}

// GET: Preventions/Details/5
public async Task<IActionResult> Details(int? id)
{
   if (id == null)
   {
       return NotFound();
   }

   var prevention = await _context.Prevention
       .FirstOrDefaultAsync(m => m.Id == id);
   if (prevention == null)
   {
       return NotFound();
   }

   return View(prevention);
}

// GET: Preventions/Create
public IActionResult Create()
{
   return View();
}

// POST: Preventions/Create
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Create([Bind("Titre,Texte,Mois,Publie,Id")] Prevention prevention)
{
   if (ModelState.IsValid)
   {
       _context.Add(prevention);
       await _context.SaveChangesAsync();
       return RedirectToAction(nameof(Index));
   }
   return View(prevention);
}

// GET: Preventions/Edit/5
public async Task<IActionResult> Edit(int? id)
{
   if (id == null)
   {
       return NotFound();
   }

   var prevention = await _context.Prevention.FindAsync(id);
   if (prevention == null)
   {
       return NotFound();
   }
   return View(prevention);
}

// POST: Preventions/Edit/5
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Titre,Texte,Mois,Publie,Id")] Prevention prevention)
{
   if (id != prevention.Id)
   {
       return NotFound();
   }

   if (ModelState.IsValid)
   {
       try
       {
           _context.Update(prevention);
           await _context.SaveChangesAsync();
       }
       catch (DbUpdateConcurrencyException)
       {
           if (!PreventionExists(prevention.Id))
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
   return View(prevention);
}

// GET: Preventions/Delete/5
public async Task<IActionResult> Delete(int? id)
{
   if (id == null)
   {
       return NotFound();
   }

   var prevention = await _context.Prevention
       .FirstOrDefaultAsync(m => m.Id == id);
   if (prevention == null)
   {
       return NotFound();
   }

   return View(prevention);
}

// POST: Preventions/Delete/5
[HttpPost, ActionName("Delete")]
[ValidateAntiForgeryToken]
public async Task<IActionResult> DeleteConfirmed(int id)
{
   var prevention = await _context.Prevention.FindAsync(id);
   _context.Prevention.Remove(prevention);
   await _context.SaveChangesAsync();
   return RedirectToAction(nameof(Index));
}

private bool PreventionExists(int id)
{
   return _context.Prevention.Any(e => e.Id == id);
}*/
    }
}
