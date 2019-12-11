using Gotham.domain;
using Gotham.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gotham.persistence
{
    public class MockPreventionRepository : IRepository<Prevention>
    {
        public List<Prevention> PreventionList;

        public MockPreventionRepository()
        {
            PreventionList = new List<Prevention>()
            {
                new Prevention(){Id=1, Titre = "Accident", Mois = "Janvier", Texte = "Aucun", Publie = "Non"},
                new Prevention(){Id=2, Titre = "Accident2", Mois = "Fevrier", Texte = "Plein", Publie = "Oui"},
            };
        }
        public Task Add(Prevention entity)
        {
            PreventionList.Add(entity);
            var items = PreventionList.AsQueryable();
            return Task.Run(() => items);
        }

        public Task Delete(Prevention entity)
        {
            PreventionList.Remove(entity);
            var items = PreventionList.AsQueryable();
            return Task.Run(() => items);
        }

        public async Task<IQueryable<Prevention>> GetAll()
        {
            var items = PreventionList.AsQueryable();
            return await Task.Run(() => items);
        }

        public Task<Prevention> GetById(int? id)
        {
            Prevention alertToReturn = null;
            foreach (Prevention prevention in PreventionList)
            {
                if (prevention.Id == id)
                {
                    alertToReturn = prevention;
                    break;
                }
            }

            return Task.Run(() => alertToReturn);
        }

        public Task Update(Prevention entity)
        {
            foreach (Prevention prevention in PreventionList)
            {
                if (prevention.Id == entity.Id)
                {
                    prevention.Mois = entity.Mois;
                    prevention.Publie = entity.Publie;
                    prevention.Titre = entity.Titre;
                    prevention.Texte = entity.Texte;
                    break;
                }
            }

            var items = PreventionList.AsQueryable();
            return Task.Run(() => items);
        }
    }
}
