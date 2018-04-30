using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieManager.Core.Domain;

namespace MovieManager.ViewModels
{
    public class FilmeViewModel : AuditableEntityViewModel
    {
        public const int MaxixmumLenght = 249;
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public bool Ativo { get; set; }
        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "O campo Categoria é obrigatório.")]
        public int GeneroId { get; set; }
        public IEnumerable<SelectListItem> GeneroSL { get; set; }
        public Genero Genero { get; set; }

        public FilmeViewModel()
        {
            Ativo = true;
        }
    }
}