using System;
using System.ComponentModel.DataAnnotations;

namespace MovieManager.Core.Domain
{
    [TrackChanges]
    public class Genero : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DataDeCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}