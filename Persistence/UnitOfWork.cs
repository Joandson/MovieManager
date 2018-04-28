using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieManager.Core;
using MovieManager.Core.Repositories;
using MovieManager.Persistence.Repositories;

namespace MovieManager.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieManagerContext _context;

        //here the unit of work will instaniate the repositories and use it across all of the application
        public UnitOfWork(MovieManagerContext context)
        {
            _context = context;
            //Example Below
            Filmes = new FilmeRepository(_context);
            Generos = new GeneroRepository(_context);

        }
        //The repositories used in the application must be set here , Example Below
        public IFilmeRepository Filmes { get; set; }
        public IGeneroRepository Generos { get; set; }


        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {

            _context.Dispose();
        }
    }
}