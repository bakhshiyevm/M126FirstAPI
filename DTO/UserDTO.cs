using System;

namespace DTO
{
	public class UserDTO
    {
        public int Id { get; set; }
		public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
    }
}
