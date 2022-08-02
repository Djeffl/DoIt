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


		public DoItContext(DbContextOptions<DoItContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Todo>().ToTable("Todo", schema: "dbo");
			modelBuilder.Entity<Goal>()
                        .ToTable("Goals", schema: "dbo")
                        .HasMany<Todo>(x => x.Todos).WithOne(x => x.Goal).OnDelete(DeleteBehavior.Cascade);
			modelBuilder.Entity<Idea>().ToTable("Ideas", schema: "dbo");
		}
	}
}
