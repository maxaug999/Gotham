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

    public class MockAlertesRepository : IRepository<Alerte>
    {
        private readonly List<Alerte> _alertes;

        public MockAlertesRepository()
        {
            _alertes = new List<Alerte>()
            {
                new Alerte(){Id=1, Nature = "Accident", Secteur = "Quebec", Risque = "Aucun", Ressource = "Bateau", Conseil = "Aucun", Publié = false},
                new Alerte(){Id=2, Nature = "Accident2", Secteur = "Montreal", Risque = "Plein", Ressource = "Aucune", Conseil = "Courrir", Publié = true},
            };
        }
        public Task Add(Alerte entity)
        {
            _alertes.Add(entity);
            var items = _alertes.AsQueryable();
            return Task.Run(() => items);
        }

        public Task Delete(Alerte entity)
        {
            _alertes.Remove(entity);
            var items = _alertes.AsQueryable();
            return Task.Run(() => items);
        }

        public async Task<IQueryable<Alerte>> GetAll()
        {
            var items = _alertes.AsQueryable();
            return await Task.Run(() => items);
        }

        public async Task<Alerte> GetById(int? id)
        {
            return await Task.Run(() => _alertes.Find(i => i.Id == id));
        }

        public Task Update(Alerte entity)
        {
            foreach(Alerte alerte in _alertes)
            {
                if (alerte.Id == entity.Id)
                {
                    alerte.Nature = entity.Nature;
                    alerte.Publié = entity.Publié;
                    alerte.Ressource = entity.Ressource;
                    alerte.Risque = entity.Risque;
                    alerte.Secteur = entity.Secteur;
                    alerte.Conseil = entity.Conseil;
                    break;
                }
            }

            var items = _alertes.AsQueryable();
            return Task.Run(() => items);
        }
    }
}
