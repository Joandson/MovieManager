using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieManager.ViewModels
{
    public class GeneroViewModel : AuditableEntityViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        public string Name { get; set; }
        public DateTime? DataDeCriacao { get; set; }
        public bool Ativo { get; set; }

        public GeneroViewModel()
        {
            Ativo = true;
        }
    }
}