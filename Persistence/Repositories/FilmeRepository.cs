using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieManager.Core.Domain;
using MovieManager.Core.Repositories;
using MovieManager.ViewModels;

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

        public IEnumerable<Filme> GetAllNotDeleted()
        {
            return Context.Filmes.Where(x => x.Deleted == false).Include(fx => fx.Genero).ToList();
        }

        public Filme GetByIdNotDeleted(int? id)
        {
            return Context.Filmes.Where(filter => filter.Id == id).FirstOrDefault(x => x.Deleted == false);
        }

        public IEnumerable<SelectListItem> GetGenresSL()
        {

            var collectionOfGenres = Context.Generos.ToList();
            var selectList = new List<SelectListItem>();
            var mappedSelectList = AutoMapper.Mapper.Map<List<Genero>, List<GeneroViewModel>>(collectionOfGenres);


            foreach (var element in mappedSelectList)
            {
                selectList.Add(new SelectListItem
                {
                    Text = element.Name,
                    Value = element.Id.ToString()
                });
            }

            return selectList.ToList();
        }


    }
}