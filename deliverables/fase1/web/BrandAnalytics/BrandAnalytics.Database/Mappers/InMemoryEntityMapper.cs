using System;
using System.Collections.Generic;
using System.Linq;

namespace BrandAnalytics.Database.Mappers
{
    class InMemoryEntityMapper<TKey, TEntity> : List<TEntity>, IEntityMapper<TKey, TEntity> 
    {
        private readonly Func<TEntity, TKey> _entityKeyExtractor;



        public InMemoryEntityMapper(Func<TEntity, TKey> entityKeyExtractor)
        {
            _entityKeyExtractor = entityKeyExtractor;
        }


        public TEntity Get(TKey key)
        {
            return this.FirstOrDefault(e => _entityKeyExtractor(e).Equals(key));
        }

        public TKey Add(TEntity obj)
        {
            base.Add(obj);
            return _entityKeyExtractor(obj);
        }

        public void Delete(TEntity obj)
        {
            Remove(obj);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this;
        }

        public void Update(TEntity value)
        {

        }
    }
}
