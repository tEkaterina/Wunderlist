using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using DAL.Expression;
using DAL.Interfaces;

namespace DAL.Repository
{
    public class Repository<TEntity, TDal> : IRepository<TDal>
        where TEntity : class
        where TDal : IDalEntity
    {
        private readonly DbContext _context;
        private readonly IMapper<TEntity, TDal> _mapper;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context, IMapper<TEntity, TDal> mapper)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (mapper == null) throw new ArgumentNullException("mapper");
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
        }
        public void Create(TDal item)
        {
            _dbSet.Add(_mapper.ToEntity(item));
        }

        public void Delete(TDal item)
        {
            TEntity entity = _dbSet.Find(item.Id);
            if (entity != null)
                _dbSet.Remove(entity);
        }

        public void Update(TDal item)
        {
            TEntity itemToUpdate = _dbSet.Find(item.Id);
            _mapper.CopyFields(item, itemToUpdate);
        }

        public IEnumerable<TDal> GetAll()
        {
            return _dbSet.AsEnumerable().Select(c => _mapper.ToDal(c));
        }

        public TDal GetById(int id)
        {
            return _mapper.ToDal(_dbSet.Find(id));
        }

        public TDal GetByPredicate(Expression<Func<TDal, bool>> predicate)
        {
            return _mapper.ToDal(_dbSet.FirstOrDefault(ExpressionMapper<TDal, TEntity, bool>.Map(predicate)));
        }
    }
}
