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
    public class MockNouvellesRepository : IRepository<Nouvelle>
    {
        public List<Nouvelle> _nouvelles;

        public MockNouvellesRepository()
        {
            _nouvelles = new List<Nouvelle>()
            {
                new Nouvelle()
                {
                    Id = 1,
                    Titre = "Vol armé",
                    Lien = "https//:tva.com",
                    Texte = "blablabla",
                    Status = 0
                },
                new Nouvelle()
                {
                    Id = 2,
                    Titre = "Assassin",
                    Lien = "haiti news",
                    Texte = "gwos chef bandit",
                    Status = 1
                },
            };
        }

        public Task Add(Nouvelle entity)
        {
            _nouvelles.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(Nouvelle entity)
        {
            _nouvelles.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IQueryable<Nouvelle>> GetAll()
        {
            IQueryable<Nouvelle> list = _nouvelles.AsQueryable();
            return await Task.Run(() => list);
        }

        public Task<Nouvelle> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Nouvelle entity)
        {
            throw new NotImplementedException();
        }
    }
}
