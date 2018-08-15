using System;
using System.Linq;
using System.Linq.Expressions;
using ApPetWeb.Models;

namespace ApPet.Services
{
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Filters a sequence of actives values.
        /// </summary>
        public static IQueryable<TEntity> Where<TEntity, TKey>
            (this IQueryable<TEntity> tEntity) 
            where TEntity : Base<TKey>
        {
            return tEntity.Where(ts => ts.IsActive);
        }

        /// <summary>
        /// Filters a sequence of actives values based on a predicate.
        /// </summary>
        public static IQueryable<TEntity> Where<TEntity, TKey>
            (this IQueryable<TEntity> tEntity, Expression<Func<Base<TKey>, bool>> predicate)
            where TEntity : Base<TKey>
        {
            return tEntity.Where(ts => ts.IsActive).Where(predicate);
        }
                

    }
}
