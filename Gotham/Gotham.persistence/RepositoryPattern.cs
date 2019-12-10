using Gotham.domain;
using Gotham.web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Gotham.persistence
{
    public class RepositoryPattern<T> : IRepository<T> where T : Entity
    {
        private readonly IServiceScopeFactory scopeFactory;

        public RepositoryPattern(IServiceScopeFactory scopeFactory)
        {
            this.scopeFactory = scopeFactory;
        }

        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<T>> GetAll()
        {
            using (var scope = scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<GothamwebContext>();
                var items = await dbContext.Set<T>().ToListAsync();
                return items.AsQueryable();
            }
        }

        public Task<T> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}