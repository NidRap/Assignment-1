using Assignment_1.Models;
using Assignment_1.Models.DTO;
using AutoMapper;

namespace Assignment_1
{
	public class MappingConfig : Profile
	{
		public MappingConfig() { 
		
			CreateMap<User , UserDTO>();
			CreateMap<UserDTO, User>();


			CreateMap<Airline, AirlineDTO>().ReverseMap();
			CreateMap<AirlineDTO, Airline>().ReverseMap();

			CreateMap<Flight, FlightDTO>().ReverseMap();
			CreateMap<FlightDTO, Flight>().ReverseMap();

            CreateMap<Journey, JourneyDTO>().ReverseMap();
            CreateMap<JourneyDTO, Journey>().ReverseMap();

        }
    }
}
