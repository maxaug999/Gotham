using Gotham.domain;
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
                    Titre = "Vol arme",
                    Texte = "blablabla",
                    Publié = true,
                    VideoUrl = new Uri("https://www.youtube.com/watch?v=nmDcybRn4HQ")
                },
                new Capsule()
                {
                    Id = 2,
                    Titre = "Assassin",
                    Texte = "gwos chef bandit",
                    Publié = false,
                    VideoUrl = new Uri("https://www.youtube.com/watch?v=RRGhryMxifo")
                },
            };
        }

        public Task Add(Capsule entity)
        {
            _capsules.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(Capsule entity)
        {
            var index = 0;
            foreach (var capsule in _capsules)
            {
                if (capsule.Id == entity.Id)
                {
                    break;
                }
                index++;
            }
            _capsules.RemoveAt(index);
            return Task.CompletedTask;
        }

        public async Task<IQueryable<Capsule>> GetAll()
        {
            IQueryable<Capsule> list = _capsules.AsQueryable();
            return await Task.Run(() => list);
        }

        public async Task<Capsule> GetById(int? id)
        {
            foreach (var capsule in _capsules)
            {
                if (capsule.Id == id)
                {
                    return await Task.Run(() => capsule);
                }
            }
            return null;
        }

        public Task Update(Capsule entity)
        {
            foreach (var capsule in _capsules)
            {
                if (capsule.Id == entity.Id)
                {
                    capsule.Titre = entity.Titre;
                    capsule.Texte = entity.Texte;
                    capsule.Publié = entity.Publié;
                    capsule.VideoUrl = entity.VideoUrl;
                    break;
                }
            }            
            return Task.CompletedTask;
        }
    }
}
