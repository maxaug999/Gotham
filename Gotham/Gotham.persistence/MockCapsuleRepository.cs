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
    public class MockCapsuleRepository : IRepository<Capsule>
    {
        public List<Capsule> _capsules;

        public MockCapsuleRepository()
        {
            _capsules = new List<Capsule>()
            {
                new Capsule()
                {
                    Id = 1,
                    Titre = "Vol armé",
                    Lien = "https//:tva.com",
                    Texte = "blablabla",
                    Status = "Publiée"
                },
                new Capsule()
                {
                    Id = 2,
                    Titre = "Assassin",
                    Lien = "haiti news",
                    Texte = "gwos chef bandit",
                    Status = "En attente"
                },
            };
        }

        public Task Add(Capsule entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Capsule entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Capsule>> GetAll()
        {
            IQueryable<Capsule> list = _capsules.AsQueryable();
            return await Task.Run(() => list);
        }

        public Task<Capsule> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Capsule entity)
        {
            throw new NotImplementedException();
        }
    }
}
