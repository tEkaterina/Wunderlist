using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IMapper<TEntity, TDal>
    {
        TEntity ToEntity(TDal item);
        TDal ToDal(TEntity item);
        IEnumerable<TDal> ToDalCollection(IEnumerable<TEntity> entity);
        void CopyFields(TDal dalEntity, TEntity entity);
    }
}
