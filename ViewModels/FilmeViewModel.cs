using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieManager.Core.Domain;

namespace MovieManager.ViewModels
{
    public class FilmeViewModel : AuditableEntityViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public bool Ativo { get; set; }
        public int GeneroId { get; set; }
        public ICollection<Genero> Genero { get; set; }
    }
}