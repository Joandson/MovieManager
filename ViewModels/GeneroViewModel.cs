using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieManager.ViewModels
{
    public class GeneroViewModel : AuditableEntityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}