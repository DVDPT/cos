using System.Collections.Generic;

namespace BrandAnalytics.Database.Mappers
{
    public interface IEntityMapper<TKey,TEntity>
    {
        TEntity Get(TKey key);
        TKey Add(TEntity obj);
        void Delete(TEntity obj);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity value);
    }
}