namespace Wunderlist.DataAccess.Interfaces
{
    public Interfaces IMapper<TEntity, TDal>
    {
        TEntity ToEntity(TDal item);
        TDal ToDal(TEntity item);
        void CopyFields(TDal dalEntity, TEntity entity);
    }
}