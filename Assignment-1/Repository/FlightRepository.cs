using Assignment_1.Data;
using Assignment_1.Models;
using Assignment_1.Repository.IRepository;

namespace Assignment_1.Repository
{
	public class FlightRepository : IFlightRepository

	{

		private readonly ApplicationDbContext _db;
		public FlightRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public void createFlight(Flight entity)
		{
			_db.Add(entity);
			_db.SaveChanges();
		}

		public void deleteFlight(Flight entity)
		{
			_db.Remove(entity);
			_db.SaveChanges();
		}

		public List<Flight> GetAllFlights()
		{
			return _db.Flight.ToList();
		}

		public Flight GetFlight(int id)
		{
			return _db.Flight.FirstOrDefault(u => u.Id == id);
		}

		public void updateFlight(Flight entity)
		{
		  _db.Update(entity);
			_db.SaveChanges();
		}
	}
}
