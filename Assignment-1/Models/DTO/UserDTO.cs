﻿using System.ComponentModel.DataAnnotations;

namespace Assignment_1.Models.DTO
{
	public class UserDTO
	{
		[Required]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }

      

    }
}