using System;

namespace Wunderlist.DataAccess.Interfaces
{
    public Interfaces IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
