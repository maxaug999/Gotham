﻿using Gotham.domain;
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
                    Titre = "Vol",
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

        public async Task<Nouvelle> GetById(int? id)
        {
            return await Task.Run(() => _nouvelles.Find(i => i.Id == id));
        }

        public Task Update(Nouvelle entity)
        {
            foreach (Nouvelle cur in _nouvelles)
            {
                if (cur.Id == entity.Id)
                {
                    cur.Titre = entity.Titre;
                    cur.Texte = entity.Texte;
                    cur.Lien = entity.Lien;
                    cur.Status = entity.Status;
                    break;
                }
            }
            return Task.CompletedTask;
        }
    }
}
