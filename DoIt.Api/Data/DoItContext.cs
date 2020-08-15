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

		public DoItContext(DbContextOptions<DoItContext> options) : base(options)
		{

		}

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//	optionsBuilder.UseSqlServer(
		//		@"Server=DESKTOP-GJ7Q92P;Database=DoIt;Trusted_Connection=True;MultipleActiveResultSets=true");
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Todo>().ToTable("Todo");
		}
	}
}
