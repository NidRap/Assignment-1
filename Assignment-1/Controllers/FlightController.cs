using Assignment_1.Data;
using Assignment_1.Models;
using Assignment_1.Models.DTO;
using Assignment_1.Repository;
using Assignment_1.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Serilog;

namespace Assignment_1.Controllers
{

	[Route("api/FlightAPI")]
	[ApiController]
	public class FlightController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IFlightRepository _flightRepository;
		private readonly ApplicationDbContext _db;

		public FlightController(IMapper mapper, IFlightRepository flightRepository , ApplicationDbContext db)
		{
			_mapper = mapper;
		
			_flightRepository = flightRepository;
			_db = db;
		}



		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]


		public IEnumerable<Flight> GetFlights()
		{
			return _flightRepository.GetAllFlights();
		}



		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<FlightDTO> CreateFlight([FromBody] FlightDTO flightDTO)
		{
			if (flightDTO == null)
			{
				return BadRequest();
			}

			var code = _db.AirlineTable.FirstOrDefault(u => u.AirlineCode == flightDTO.AirlineCode);
			if (code == null)
			{
				 ModelState.AddModelError("Custom Error","AirlineCode of both must be same!!");
				return BadRequest(ModelState);

			}
			
				Flight model = _mapper.Map<Flight>(flightDTO);
				_flightRepository.createFlight(model);

				return Ok(model);
			
			
		}

		[Authorize(Roles="Admin")]
		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<FlightDTO> Remove( int id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			if (id <= 0)
			{
				return NotFound();
			}
			Flight model = _flightRepository.GetFlight(id);
		          _flightRepository.deleteFlight(model);
			return Ok(model);
		}

		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]


		public ActionResult<Flight>Update(int id,[FromBody] FlightDTO flightDTO)
		{
			if (id == null || id != flightDTO.Id)
			{
				return BadRequest();
			}
			var model = _mapper.Map<Flight>(flightDTO);
			_flightRepository.updateFlight(model);
			return Ok(model);




		}
	}
}
