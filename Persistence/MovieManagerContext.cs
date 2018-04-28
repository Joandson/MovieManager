using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieManager.Core.Domain;
using MovieManager.Persistence.EntityConfig;
using TrackerEnabledDbContext.Identity;

namespace MovieManager.Persistence
{
    public class MovieManagerContext : TrackerIdentityContext<ApplicationUser>
    {
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Filme> Filmes { get; set; }

        public MovieManagerContext()
            : base("DefaultConnection")
        {
        }

        public static MovieManagerContext Create()
        {
            return new MovieManagerContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new FilmeConfiguration());
        }
        public override int SaveChanges()
        {
            //This prevents the need to keep setting and re-setting this value in adding and updating actions
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataDeCriacao") == null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataDeCriacao").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataDeCriacao").IsModified = false;
                }
            }
            return base.SaveChanges();
        }


    }
}