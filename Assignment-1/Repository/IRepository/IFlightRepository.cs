using Assignment_1.Models;

namespace Assignment_1.Repository.IRepository
{
	public interface IFlightRepository
	{
		List<Flight>GetAllFlights();

		Flight GetFlight(int id);
		void createFlight(Flight entity);
		void updateFlight(Flight entity);
		void deleteFlight(Flight entity);
	}
}
