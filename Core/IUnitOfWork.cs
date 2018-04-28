using System;

namespace MovieManager.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Add Concrete repositories here example
        //IPersonRepository People { get; }
        int Complete();
    }
}