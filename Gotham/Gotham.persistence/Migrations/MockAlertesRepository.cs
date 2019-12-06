﻿using Gotham.domain;
using Gotham.persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gotham.web.Data
{
    public class MockAlertesRepository : IRepository<Alerte>
    {
        private readonly List<Alerte> _alertes;

        public MockAlertesRepository()
        {
            _alertes = new List<Alerte>()
            {
                new Alerte(){Id=1, Nature = "Accident", Secteur = "Québec", Risque = "Aucun", Ressource = "Bateau", Conseil = "Aucun", Publié = false},
                new Alerte(){Id=2, Nature = "Accident2", Secteur = "Montréal", Risque = "Plein", Ressource = "Aucune", Conseil = "Courrir", Publié = true},
            };
        }
        public Task Add(Alerte entity)
        {
            _alertes.Add(entity);
            var items = _alertes.AsQueryable();
            return Task.Run(()=> items);
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

        public Task<Alerte> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Alerte entity)
        {
            throw new NotImplementedException();
        }
    }
}
