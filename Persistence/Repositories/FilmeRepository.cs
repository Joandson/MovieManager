using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieManager.Core.Domain;
using MovieManager.Core.Repositories;

namespace MovieManager.Persistence.Repositories
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(MovieManagerContext context) : base(context)
        {
        }
        public MovieManagerContext MovieManagerContext
        {
            get { return Context as MovieManagerContext; }
        }
    }
}