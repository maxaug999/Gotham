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
        private readonly List<Prevention> _alertes;

        public MockPreventionRepository()
        {
            _alertes = new List<Prevention>()
            {
                new Prevention(){Id=1, Titre = "Accident", Mois = "Janvier", Texte = "Aucun", Publié = false},
                new Prevention(){Id=2, Titre = "Accident2", Mois = "Fevrier", Texte = "Plein", Publié = true},
            };
        }
        public Task Add(Prevention entity)
        {
            _alertes.Add(entity);
            var items = _alertes.AsQueryable();
            return Task.Run(() => items);
        }

        public Task Delete(Prevention entity)
        {
            _alertes.Remove(entity);
            var items = _alertes.AsQueryable();
            return Task.Run(() => items);
        }

        public async Task<IQueryable<Prevention>> GetAll()
        {
            var items = _alertes.AsQueryable();
            return await Task.Run(() => items);
        }

        public Task<Prevention> GetById(int? id)
        {
            Prevention alertToReturn = null;
            foreach (Prevention prevention in _alertes)
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
            foreach (Prevention prevention in _alertes)
            {
                if (prevention.Id == entity.Id)
                {
                    prevention.Mois = entity.Mois;
                    prevention.Publié = entity.Publié;
                    prevention.Titre = entity.Titre;
                    prevention.Texte = entity.Texte;
                    break;
                }
            }

            var items = _alertes.AsQueryable();
            return Task.Run(() => items);
        }
    }
}
