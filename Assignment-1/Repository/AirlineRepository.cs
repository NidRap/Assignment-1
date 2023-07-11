using Assignment_1.Data;
using Assignment_1.Models;
using Assignment_1.Repository.IRepository;

namespace Assignment_1.Repository
{
	public class AirlineRepository : IAirlineRepository
	{

		private readonly ApplicationDbContext _db;
		public AirlineRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public void CreateAirline(Airline entity)
		{
			_db.AirlineTable.Add(entity);
			_db.SaveChanges();

		}

		public Airline GetAirline(int Id)
		{


			return _db.AirlineTable.FirstOrDefault(u => u.Sno == Id);



			}

			public List<Airline> GetAllAirlines()
		{
			return _db.AirlineTable.ToList();
		}

		public void RemoveAirline(Airline entity)
		{
			_db.Remove(entity);
			_db.SaveChanges();
		}

	
		public void UpdateAirline(Airline entity)
		{
			_db.Update(entity);
			_db.SaveChanges();
		}
	}
}
