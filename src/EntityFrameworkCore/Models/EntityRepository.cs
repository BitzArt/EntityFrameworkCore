using BitzArt.EntityFrameworkCore.Exceptions;
using BitzArt.EntityFrameworkCore.Extensions;
using BitzArt.Pagination.EntityFrameworkCore;
using BitzArt.Pagination.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BitzArt.EntityFrameworkCore.Models
{
    public class EntityRepository<TEntity, TDbContext>
        where TEntity : class
        where TDbContext : DbContext
    {
        protected TDbContext Data { get; set; }

        public DbSet<TEntity> DbSet => Data.Set<TEntity>();

        public EntityRepository(TDbContext dbContext)
        {
            Data = dbContext;
        }

        public virtual async Task<TEntity> Find<TId>(TId id)
        {
            var result = await DbSet.FindAsync(id);

            if (result == null)
                throw new NotFoundException<TEntity>();

            return result;
        }

        public virtual async Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> criteria) => await DbSet.FirstOrDefaultAsync(criteria);

        public virtual IQueryable<TEntity> AsQueriable() => DbSet.AsQueryable();

        public virtual async Task<List<TEntity>> GetMultiple(Expression<Func<TEntity, bool>> criteria) => await DbSet.Where(criteria).ToListAsync();

        public virtual async Task<PageResult<TEntity>> GetPageAsync(PageRequest request) => await AsQueriable().ToPageAsync(request);

        public virtual async Task<PageResult<TEntity>> GetPageAsync(int skip, int take) => await AsQueriable().ToPageAsync(skip, take);

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var obj = Data.Add(entity);

            await Data.SaveChangesAsync();

            return obj.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var obj = Data.Update(entity);

            await Data.SaveChangesAsync();

            return obj.Entity;
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            Data.Remove(entity);

            await Data.SaveChangesAsync();

            return;
        }
    }

    public class EntityRepository<TEntity, TDbContext, TUserManager> : EntityRepository<TEntity, TDbContext>
        where TEntity : class
        where TDbContext : DbContext
        where TUserManager : UserManager<IdentityUser>
    {
        protected TUserManager Users { get; set; }

        public EntityRepository(TDbContext dbContext, TUserManager userManager) : base(dbContext)
        {
            Users = userManager;
        }

        public override Task<TEntity> AddAsync(TEntity entity)
        {
            //if (entity.GetType().IsSubclassOfRawGeneric(typeof(EntityCreated<object>)))
            //TODO: Get UserId
            //    (entity as EntityCreated<object>).CreatedBy = Users.

            return base.AddAsync(entity);
        }
    }
}
