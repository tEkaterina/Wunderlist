using System;

namespace Wunderlist.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
