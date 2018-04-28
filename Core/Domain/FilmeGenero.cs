using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Razor;

namespace MovieManager.Core.Domain
{
    public class FilmeGenero
    {
        public int FilmeId { get; set; }
        public int GeneroId { get; set; }
        public Filme Filme { get; set; }
        public Genero Genero { get; set; }
    }
}