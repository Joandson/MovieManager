using System;
using MovieManager.Core.Repositories;

namespace MovieManager.Core
{
    public interface IUnitOfWork : IDisposable
    {
        //Add Concrete repositories here example
        IFilmeRepository Filmes { get; }
        IGeneroRepository Generos { get; }
        int Complete();
    }
}