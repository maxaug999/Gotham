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

        public async Task<IActionResult> Details(int? Id)
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

        

        private bool PreventionExists(int Id)
        {
            var prevention = _repository.GetById(Id);
            if(prevention != null)
            {
                return true;
            }
            return false;
        }
        
    }
}
