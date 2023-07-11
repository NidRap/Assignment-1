using Assignment_1.Models;
using Assignment_1.Models.DTO;
using Assignment_1.Repository;
using Assignment_1.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{
	[Route("api/AirlinesAPI")]
	[ApiController]
	public class AirlineController : ControllerBase
	{
		private readonly IMapper  _mapper;
		private readonly IAirlineRepository _airlineRepository;

			public  AirlineController(IMapper mapper , IAirlineRepository airlineRepository)
		{
			_mapper = mapper;
			_airlineRepository = airlineRepository;

		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public IEnumerable<Airline> Get()
		{
			return _airlineRepository.GetAllAirlines().ToList();

		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public ActionResult<AirlineDTO> CreateAirline([FromBody] AirlineDTO airlineDTO)
		{
			if (airlineDTO == null)
			{
				return BadRequest(airlineDTO);
			}


			Airline model = _mapper.Map<Airline>(airlineDTO);
			_airlineRepository.CreateAirline(model);
			

			return Ok();


		}
		[HttpDelete("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<User> Remove(int id)
		{
			if (id == null)
			{
				return BadRequest();
			}


			Airline model = _airlineRepository.GetAirline(id);
			_airlineRepository.RemoveAirline(model);
			return Ok(model);

		}

		[HttpPut("{Id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<Airline> update(int Id, [FromBody] AirlineDTO airlineDTO)
		{
			if (airlineDTO == null || Id != airlineDTO.Sno)
			{
				return BadRequest();
			}
		
			var model =
			_mapper.Map<Airline>(airlineDTO);
			_airlineRepository.UpdateAirline(model);
			return Ok(model);

		}

	}
}
