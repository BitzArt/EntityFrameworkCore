using BitzArt.EntityFrameworkCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BitzArt.EntityFrameworkCore.Extensions
{
    public static class EntityRepositoryExtension
    {
        public static EntityRepository<TEntity, DbContext> Repository<TEntity>(this DbContext dbContext)
            where TEntity : class
        {
            return new EntityRepository<TEntity, DbContext>(dbContext);
        }

        public static EntityRepository<TEntity, DbContext, UserManager<IdentityUser>> Repository<TEntity>(this DbContext dbContext, UserManager<IdentityUser> userManager)
            where TEntity : class
        {
            return new EntityRepository<TEntity, DbContext, UserManager<IdentityUser>>(dbContext, userManager);
        }
    }
}
