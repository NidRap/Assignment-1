using Assignment_1.Models;

namespace Assignment_1.Repository.IRepository
{
	public interface IAirlineRepository
	{
		List<Airline> GetAllAirlines();
		Airline GetAirline(int Id);
		void CreateAirline(Airline entity);
		void RemoveAirline(Airline entity);

		void UpdateAirline(Airline entity);
	}
}
