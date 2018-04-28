using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MovieManager.Core.Domain;

namespace MovieManager.Persistence.EntityConfig
{
    public class GeneroConfiguration : EntityTypeConfiguration<Genero>
    {
        public GeneroConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Ativo)
                .IsRequired();
        }


    }
}