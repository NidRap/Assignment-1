using Assignment_1.Data;
using Assignment_1.Models;
using Assignment_1.Models.DTO;
using Assignment_1.Repository;
using Assignment_1.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{
    [Route("api/JourneyAPI")]
    [ApiController]
    public class JourneyController :ControllerBase
    {
        private readonly IJourneyRepository _journeyRepository;
        private readonly IMapper _mapper;
        public ApplicationDbContext _db;
        public JourneyController(IMapper mapper, IJourneyRepository journeyRepository, ApplicationDbContext db)
        {
            _mapper = mapper;
            _journeyRepository = journeyRepository;
            _db = db;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public IEnumerable<Journey> Getjourneys()
        {
            return _journeyRepository.GetAllJourney();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<JourneyDTO> CreateJourney([FromBody] JourneyDTO journeyDTO)
        {
            if (journeyDTO == null)
            {
                return BadRequest();
            }

            var code = _db.AirlineTable.FirstOrDefault(u => u.Sno == journeyDTO.AirlineID);
            var code1 = _db.Flight.FirstOrDefault(u => u.Id == journeyDTO.FlightID);

            if (code == null || code1 == null)
            {
                ModelState.AddModelError("Custom Error", "AirlineID & FlightID of both must be same!!");
                return BadRequest(ModelState);

            }

            var model = _mapper.Map<Journey>(journeyDTO);
            _journeyRepository.createJourney(model);

            return Ok(model);
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<JourneyDTO> RemoveJourney(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            if (id <= 0)
            {
                return NotFound();
            }
            Journey model = _journeyRepository.GetJourney(id);
            _journeyRepository.deleteJourney(model);
            return Ok(model);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public ActionResult<Journey> GetIndividual(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }


            Journey model = _journeyRepository.GetJourney(id);

            return Ok(model);

        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public ActionResult<Journey> Update(int id, [FromBody] JourneyDTO journeyDTO)
        {
            if (id == null || id != journeyDTO.Id)
            {
                return BadRequest();
            }
            var model = _mapper.Map<Journey>(journeyDTO);
            _journeyRepository.updateJourney(model);
            return Ok(model);




        }

    }
}
