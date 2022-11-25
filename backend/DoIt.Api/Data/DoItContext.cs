using DoIt.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoIt.Api.Data
{
    public class DoItContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public DbSet<Goal> Goals { get; set; }

        public DbSet<Idea> Ideas { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DoItContext(DbContextOptions<DoItContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().ToTable("Todo", schema: "dbo");
            
            var goalEntityBuilder = modelBuilder.Entity<Goal>()
                        .ToTable("Goals", schema: "dbo");
            //goalEntityBuilder.HasOne<Idea>(x => x.Idea).WithOne(x => x.Goal);
            goalEntityBuilder.HasMany<Category>(c => c.Categories).WithMany(i => i.Goals); 
            goalEntityBuilder.HasMany<Todo>(x => x.Todos).WithOne(x => x.Goal).OnDelete(DeleteBehavior.Cascade);
            goalEntityBuilder.Ignore(x => x.CompletionPercentage);

            var ideaEntityBuilder = modelBuilder.Entity<Idea>().ToTable("Ideas", schema: "dbo");
            ideaEntityBuilder.HasMany<Category>(c => c.Categories).WithMany(i => i.Ideas);
            ideaEntityBuilder.HasOne<Goal>(x => x.Goal).WithOne(x => x.Idea).HasForeignKey<Goal>(x => x.IdeaId);

            modelBuilder.Entity<Category>().ToTable("Categories", "dbo");
        }
    }
}
