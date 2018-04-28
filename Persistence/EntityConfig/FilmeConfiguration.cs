using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MovieManager.Core.Domain;

namespace MovieManager.Persistence.EntityConfig
{
    public class FilmeConfiguration : EntityTypeConfiguration<Filme>
    {
        public FilmeConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Ativo)
                .IsRequired();

        }
    }
}