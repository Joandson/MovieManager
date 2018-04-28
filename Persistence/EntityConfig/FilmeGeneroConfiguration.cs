using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using MovieManager.Core.Domain;

namespace MovieManager.Persistence.EntityConfig
{
    public class FilmeGeneroConfiguration : EntityTypeConfiguration<FilmeGenero>
    {
        public FilmeGeneroConfiguration()
        {
            HasKey(table => new { table.FilmeId, table.GeneroId });

        }
    }
}

