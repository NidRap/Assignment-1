using Assignment_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_1.Data
{
	public class ApplicationDbContext:DbContext
	{
		public ApplicationDbContext 
			(DbContextOptions<ApplicationDbContext> options) : base(options) { 
		}
		public DbSet<User> User { get; set; }

		public DbSet<Airline> AirlineTable { get; set; }

		public DbSet<Flight> Flight{ get; set; }

		public DbSet<Journey> Journeys { get; set; }


	}
}
