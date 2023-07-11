using Assignment_1.Data;
using Assignment_1.Models;
using Assignment_1.Models.DTO;
using Assignment_1.Repository;
using Assignment_1.Repository.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_1.Controllers
{
	[Route("api/UserAPI")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IMapper _mapper;
		private readonly IUserRepository _userRepository;
		public UserController(IMapper mapper, IUserRepository userRepository)
		{
			_mapper = mapper;
			_userRepository = userRepository;
		}
		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public IEnumerable<User> Get()
		{
			return _userRepository.GetAll().ToList();



		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<User> GetIndividual(int id)
		{
			if (id == null)
			{
				return BadRequest();
			}


			User model = _userRepository.Get(id);

			return Ok(model);

		}


		[HttpPost]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]


		public ActionResult<UserDTO> CreateUser([FromBody] UserDTO userDTO)
		{
			if (userDTO == null)
			{
				return BadRequest(userDTO);
			}


			User model = _mapper.Map<User>(userDTO);
			_userRepository.Create(model);

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


			User model = _userRepository.Get(id);
			_userRepository.Remove(model);
			return Ok(model);

		}


		[HttpPut("{id:int}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]

		public ActionResult<User> update(int id , [FromBody] UserDTO userDTO)
		{
			if (userDTO == null || id != userDTO.Id)
			{
				return BadRequest();
			}
			var model = 
			_mapper.Map<User>(userDTO);
			_userRepository.Update(model);
			return Ok(model);

		}
	}
}
