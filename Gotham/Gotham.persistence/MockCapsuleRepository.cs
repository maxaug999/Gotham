using Gotham.domain;
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
                    Publie = true,
                    VideoUrl = "https://www.youtube.com/watch?v=acTzyrKL9yo"
                },
                new Capsule()
                {
                    Id = 2,
                    Titre = "Assassin",
                    Lien = "haiti news",
                    Texte = "gwos chef bandit",
                    Publie = false,
                    VideoUrl = "https://www.youtube.com/watch?v=RRGhryMxifo"
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
                    capsule.Lien = entity.Lien;
                    capsule.Publie = entity.Publie;
                    capsule.VideoUrl = entity.VideoUrl;
                    break;
                }
            }            
            return Task.CompletedTask;
        }
    }
}
