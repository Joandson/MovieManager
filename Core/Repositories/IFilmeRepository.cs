﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MovieManager.Core.Domain;

namespace MovieManager.Core.Repositories
{
    public interface IFilmeRepository : IRepository<Filme>
    {
        IEnumerable<Filme> GetAllNotDeleted();
        Filme GetByIdNotDeleted(int? id);
        IEnumerable<SelectListItem> GetGenresSL();
    }
}
