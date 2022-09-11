namespace DataAccess.Entities
{
    public class User : BaseEntity
    {
		public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Username { get; set; }
        public string Salt { get; set; }
        public string PasswordHash { get; set; }
    }
}
