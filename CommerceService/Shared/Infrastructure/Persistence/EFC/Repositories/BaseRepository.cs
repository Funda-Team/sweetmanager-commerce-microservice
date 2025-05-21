using CommerceService.Shared.Infrastructure.Persistence.EFC.Configuration;
using IamService.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CommerceService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public abstract class BaseRepository<TEntity>(CommerceContext context) : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly CommerceContext Context = context;
        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

        public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();

        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

        public void Update(TEntity entity) => Context.Set<TEntity>().Update(entity);
    }
}