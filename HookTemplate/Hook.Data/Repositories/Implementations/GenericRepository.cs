using Hook.Core.Entities;
using Hook.Core.Repositories;
using Hook.Data.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Data.Repositories.Implementations
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly HookDbContext _context;

        public GenericRepository(HookDbContext context)
        {
            _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);

            return expression is not null ? await query.Where(expression).ToListAsync() : await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes)
        {
            var query = GetQuery(includes);

            return expression is not null ? await query.Where(expression).FirstOrDefaultAsync() : await query.FirstOrDefaultAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private IQueryable<TEntity> GetQuery(params string[]? includes)
        {
            var query = Table.AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query.Include(include);
                }
            }

            return query;
        }
    }
}
