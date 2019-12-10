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
    public class MockSignalementsRepository : IRepository<Signalement>
    {
        public List<Signalement> _signalements;

        public MockSignalementsRepository()
        {
            _signalements = new List<Signalement>()
            {
                new Signalement()
                {
                    Id = 1,
                    Nature = "Vol",
                    Secteur = "Limoilou",
                    Heure = "8:59",
                    Commentaires = "C'est horrible"
                },
                new Signalement()
                {
                    Id = 2,
                    Nature = "Assassin",
                    Secteur = "Charny",
                    Heure = "23:44",
                    Commentaires = "Le monde est rendu fou"
                },
            };
        }

        public Task Add(Signalement entity)
        {
            _signalements.Add(entity);
            return Task.CompletedTask;
        }

        public Task Delete(Signalement entity)
        {
            _signalements.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<IQueryable<Signalement>> GetAll()
        {
            IQueryable<Signalement> list = _signalements.AsQueryable();
            return await Task.Run(() => list);
        }

        public async Task<Signalement> GetById(int? id)
        {
            return await Task.Run(() => _signalements.Find(i => i.Id == id));
        }

        public Task Update(Signalement entity)
        {
            foreach (Signalement cur in _signalements)
            {
                if (cur.Id == entity.Id)
                {
                    cur.Nature = entity.Nature;
                    cur.Secteur = entity.Secteur;
                    cur.Heure = entity.Heure;
                    cur.Commentaires = entity.Commentaires;
                    break;
                }
            }
            return Task.CompletedTask;
        }
    }
}
