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
                    Status = "Publiée"
                },
                new Nouvelle()
                {
                    Id = 2,
                    Titre = "Assassin",
                    Lien = "haiti news",
                    Texte = "gwos chef bandit",
                    Status = "En attente"
                },
            };
        }

        public Task Add(Nouvelle entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Nouvelle entity)
        {
            throw new NotImplementedException();
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
