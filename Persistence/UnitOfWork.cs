using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieManager.Core;

namespace MovieManager.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Mvc5BoilerPlateContext _context;

        //here the unit of work will instaniate the repositories and use it across all of the application
        public UnitOfWork(Mvc5BoilerPlateContext context)
        {
            _context = context;
            //Example Below
            //People = new PersonRepository(_context);

        }
        //The repositories used in the application must be set here , Example Below
        //public IPersonRepository People { get; private set; }


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