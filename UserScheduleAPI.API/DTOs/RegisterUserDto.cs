namespace UserScheduleAPI.API.DTOs
{
    public class RegisterUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public int? Age { get; set; }
    }
}
