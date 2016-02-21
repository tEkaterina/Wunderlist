using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Interfaces;
using Ninject;

namespace DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly IKernel _kernel;
        private readonly Dictionary<Type, object> _repos;
        private bool _isDisposed;

        public UnitOfWork(DbContext context, IKernel kernel)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (kernel == null) throw new ArgumentNullException("kernel");
            _context = context;
            _kernel = kernel;
            _repos = new Dictionary<Type, object>();
        }

        public IRepository<T> GetRepository<T>()
            where T : class, IDalEntity
        {
            object repo;
            if (!_repos.TryGetValue(typeof(T), out repo))
                _repos.Add(typeof(T), repo = _kernel.Get<IRepository<T>>());
            return repo as IRepository<T>;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                    _context.Dispose();
            }
            _isDisposed = true;
        }
    }
}
