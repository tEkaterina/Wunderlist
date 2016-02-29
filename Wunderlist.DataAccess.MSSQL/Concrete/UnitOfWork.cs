using System;
using System.Data.Entity;
using Wunderlist.DataAccess.Interfaces;

namespace Wunderlist.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private bool _isDisposed;

        public UnitOfWork(DbContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _context = context;
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
